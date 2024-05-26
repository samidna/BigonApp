using BigonApp.Helpers;
using BigonApp.Helpers.Services;
using BigonApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(str =>
{
    str.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

builder.Services.Configure<EmailOptions>(str =>
{
    builder.Configuration.GetSection("emailAccount").Bind(str);
});

builder.Services.AddSingleton<IEmailService, EmailService>();

var app = builder.Build();


app.UseStaticFiles();
app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

app.Run();
