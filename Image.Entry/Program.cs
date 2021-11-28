var builder = WebApplication.CreateBuilder(args).Inject();
var app = builder.Build();
//定向到HTTPS
//app.UseHttpsRedirection();
//启用静态文件浏览
app.UseStaticFiles();
//跨域限制
app.UseCorsAccessor();

app.UseInject(string.Empty);
app.Run();
