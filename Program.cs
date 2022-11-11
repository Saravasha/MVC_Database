using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_Database.Data;
using MVC_Database.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MVC_DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC_DatabaseContext") ?? throw new InvalidOperationException("Connection string 'MVC_DatabaseContext' not found.")));

builder.Services.AddMvc();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index" });
app.Run();
