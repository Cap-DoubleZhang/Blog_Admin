using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace AdminBlog.SignalRApplication
{
    [AppStartup(600)]
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //注册服务
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEndpoints(x =>
            {
                x.MapHub<SignalRHub>("/communication");
            });
        }

    }
}
