var builder = WebApplication.CreateBuilder(args).Inject();
var app = builder.Build();
//app.Run("http://*:5000");
app.Run();