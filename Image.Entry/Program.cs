var builder = WebApplication.CreateBuilder(args).Inject();
var app = builder.Build();
//app.Run("http://*:5004");
app.Run();