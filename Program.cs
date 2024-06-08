using BigonApp.Data;
using BigonApp.Data.Persistences;
using BigonApp.Infrastructure.Commons.Implements;
using BigonApp.Infrastructure.Services.Implements;
using BigonApp.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.InstallDataServices(builder.Configuration);

builder.Services.Configure<EmailOptions>(str =>
{
    builder.Configuration.GetSection("emailAccount").Bind(str);
});

builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IDatetimeService, DatetimeService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();


app.UseStaticFiles();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
app.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

app.Run();
