//var builder = WebApplication.CreateBuilder(args).Inject();
//var app = builder.Build();
//app.Run();

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
                    //.UseUrls("http://127.0.0.1:5000")
                    .UseStartup<Startup>();
                });
    }
}