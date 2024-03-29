using HealthSync.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Recuperar a string de conexao do arquivo appsettings.json
var conn = builder.Configuration.GetConnectionString("conexao");

//Configurar o servi�o de inje��o de depend�ncia do DbContext
builder.Services.AddDbContext<HealthSyncContext>(op => op.UseSqlServer(conn));

var app = builder.Build();
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
