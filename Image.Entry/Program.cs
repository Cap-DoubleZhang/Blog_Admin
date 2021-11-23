var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//定向到HTTPS
app.UseHttpsRedirection();
//启用静态文件浏览
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run();
