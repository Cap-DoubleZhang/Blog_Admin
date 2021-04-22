using Furion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBlog.Common
{
    [AppStartup(800)]
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigurableOptions<PasswordSettingOptions>();
            services.AddConfigurableOptions<CurrentUserInfoOptions>();
            services.AddConfigurableOptions<UserInfoConstOptions>();
            services.AddConfigurableOptions<FilePathOptions>();
            //services.add<EncryptHelper>();
        }
    }
}
