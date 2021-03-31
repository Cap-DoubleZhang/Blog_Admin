using Furion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Application
{
    [AppStartup(600)]
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<CurrentUserService>();
            //services.add<EncryptHelper>();
        }
    }
}
