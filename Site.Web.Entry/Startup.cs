namespace Site.Web.Entry
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // 代码迁移至 Site.Web.Core/Startup.cs
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 代码迁移至 Site.Web.Core/Startup.cs
        }
    }
}
