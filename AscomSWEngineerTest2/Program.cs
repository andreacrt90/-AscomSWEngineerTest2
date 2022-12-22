using AscomSWEngineerTest2.Helpers;
using AscomSWEngineerTest2.Interfaces;
using AscomSWEngineerTest2.Models;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAuthentication("BasicAuthentication").
            AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
            ("BasicAuthentication", null);

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes("BasicAuthentication")
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddHangfire(config =>
{
    config.UseMemoryStorage();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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


app.UseHangfireDashboard();
app.UseHangfireServer();

app.Run();
