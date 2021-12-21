//var builder = WebApplication.CreateBuilder(args).Inject();
//var app = builder.Build();
////app.Run();
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AdminBlog.Web.Entry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .Inject()
                    .UseUrls("http://*:5000")
                    .UseStartup<Startup>();
                });
    }
}