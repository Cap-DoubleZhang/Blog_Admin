var builder = WebApplication.CreateBuilder(args).Inject();
var app = builder.Build();
//����HTTPS
//app.UseHttpsRedirection();
//���þ�̬�ļ����
app.UseStaticFiles();
//��������
app.UseCorsAccessor();

app.UseInject(string.Empty);
app.Run();
