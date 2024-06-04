using System.Configuration;

using AutoMapper;
using DomainModel.Models.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using NuGet.Packaging;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.AddControllersWithViews();

    

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));

//});


//services.AddAuthentication(options =>
//{
//    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//});



                                   var configuration = builder.Configuration;
Dependency.Dependency.dependency(services, configuration);

var x = configuration["ConnectionString"];
services.AddDbContext<ShikaShopContext>(optionsAction =>
{
    optionsAction.UseSqlServer(x);
}, ServiceLifetime.Scoped);






var app = builder.Build();
    

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapHub<PeerToPeerChatAlertHub>("/PeerToPeerChatAlert");
//    endpoints.MapHub<PeerToPeerChatHub>("/PeerToPeerChat");
//});








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
app.UseSession();


























app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();








// Configure the HTTP request pipeline.



