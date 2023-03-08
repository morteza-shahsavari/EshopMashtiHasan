﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Shopping.Bootstrap;
using EshopMashtiHasan.Helper;

var builder = WebApplication.CreateBuilder(args);




builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Account/Login");
        o.LogoutPath = new PathString("/Account/Logout");
        o.AccessDeniedPath = new PathString("/Account/Login");
    });




// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();


var str = builder.Configuration["ConnectionString"];
var sSecurityConnectionString = builder.Configuration["SecurityConnectionString"];
BootStrap.WireUP(builder.Services,str);
Security.Bootstrap.SecurityBootstrap.WireUp(builder.Services, sSecurityConnectionString);

builder.Services.AddScoped<ICookieHelper, CookieHelper>();
//Session Management
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.HttpOnly = true;

    opt.Cookie.IsEssential = true;
});

builder.Services.AddScoped<CustomAuthenticator>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();