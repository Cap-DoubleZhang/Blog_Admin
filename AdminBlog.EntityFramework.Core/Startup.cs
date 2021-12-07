using Furion;
using Furion.DatabaseAccessor;
using Zack.EFCore.Batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdminBlog.EntityFramework.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                options.AddDbPool<DefaultDbContext>(providerName: default, optionBuilder: opt =>
                {
                    opt.UseBatchEF_MSSQL();
                });
            }, "AdminBlog.Database.Migrations");
        }
    }
}