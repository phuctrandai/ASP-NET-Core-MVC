
using ASP_NET_Core_MVC.Middlewares;
using Microsoft.AspNetCore.Http.Extensions;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Use(async (context, next) =>
{
    var queryBuilder = new QueryBuilder();

    queryBuilder.Add("param", "modifiedValue");

    context.Request.QueryString = queryBuilder.ToQueryString();

    await next();

    await context.Response.WriteAsync("Response from middleware");
});

app.AddFirstMiddleware();

app.Use(async (context, next) =>
{
    var cultureCookie = context.Request.Cookies["culture"];
    if (!string.IsNullOrEmpty(cultureCookie))
    {
        var culture = new CultureInfo(cultureCookie);
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
    }
    else
    {
        CultureInfo.CurrentCulture = new CultureInfo("vi-vn");
        CultureInfo.CurrentUICulture = new CultureInfo("vi-vn");
    }

    await next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();