using AdminBlog.Application;
using AdminBlog.Core;
using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using System.Linq.Expressions;
using Yitter.IdGenerator;

namespace AdminBlog.EntityFramework.Core
{
    [AppDbContext("ConnectionStrings:DbConnectionString", DbProvider.SqlServer)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>, IModelBuilderFilter
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public void OnCreated(ModelBuilder modelBuilder, EntityTypeBuilder entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            var expression = base.FakeDeleteQueryFilterExpression(entityBuilder, dbContext);
            if (expression == null) return;

            entityBuilder.HasQueryFilter(expression);
        }

        public void OnCreating(ModelBuilder modelBuilder, EntityTypeBuilder entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
        }

        /// <summary>
        /// 构建 u => EF.Property<bool>(u, "IsDeleted") == false 表达式(不用，用来学习)
        /// </summary>
        /// <param name="entityBuilder"></param>
        /// <returns></returns>
        private LambdaExpression BuilderIsDeleteLambdaExpression(EntityTypeBuilder entityBuilder)
        {
            // 获取实体构建器元数据
            var metadata = entityBuilder.Metadata;
            if (metadata.FindProperty(nameof(Entity.IsDeleted)) == null) return default;

            // 创建表达式元素
            var parameter = Expression.Parameter(metadata.ClrType, "u");
            var properyName = Expression.Constant(nameof(Entity.IsDeleted));
            var propertyValue = Expression.Constant(false);

            // 构建表达式 u => EF.Property<bool>(u, "IsDeleted") == false
            var expressionBody = Expression.Equal(Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(bool) }, parameter, properyName), propertyValue);
            var expression = Expression.Lambda(expressionBody, parameter);
            return expression;
        }

        /// <summary>
        /// 保存到数据库前拦截器
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        protected override void SavingChangesEvent(DbContextEventData eventData, InterceptionResult<int> result)
        {
            // 获取当前事件对应上下文
            var dbContext = eventData.Context;

            // 获取所有新增和更新的实体
            var entities = dbContext.ChangeTracker.Entries()
                        .Where(u => u.State == EntityState.Added || u.State == EntityState.Modified);

            var userManager = App.GetService<CurrentUserService>();
            var userId = string.IsNullOrWhiteSpace(userManager.UserName) ? 0 : userManager?.UserId;

            foreach (var entity in entities)
            {
                var obj = entity.Entity as EntityExtend;
                switch (entity.State)
                {
                    // 自动设置新增属性
                    case EntityState.Added:
                        obj.Id = YitIdHelper.NextId();
                        obj.CreatedTime = DateTime.UtcNow;
                        obj.CreateBy = userId;
                        break;
                    // 自动设置编辑属性
                    case EntityState.Modified:
                        obj.UpdatedTime = DateTimeOffset.Now;
                        obj.UpdateBy = userId;
                        break;
                }
            }
        }
    }
}