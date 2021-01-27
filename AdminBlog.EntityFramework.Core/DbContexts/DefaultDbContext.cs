using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;

namespace AdminBlog.EntityFramework.Core
{
    [AppDbContext("ConnectionStrings:DbConnectionString", DbProvider.SqlServer)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public void OnCreated(ModelBuilder modelBuilder, EntityTypeBuilder entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            var expression = BuilderIsDeleteLambdaExpression(entityBuilder);
            if (expression == null) return;

            entityBuilder.HasQueryFilter(expression);
        }

        public void OnCreating(ModelBuilder modelBuilder, EntityTypeBuilder entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
        }

        /// <summary>
        /// 构建 u => EF.Property<bool>(u, "IsDeleted") == false 表达式
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
    }
}