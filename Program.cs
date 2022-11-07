
using ASP_NET_Core_MVC.Middlewares;
using Microsoft.AspNetCore.Http.Extensions;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Handle error
    app.UseExceptionHandler("/Error/ErrorHandler");

    // Handle status code
    //app.UseStatusCodePages();

    // Handle status code with format string
    //app.UseStatusCodePages(Text.Plain, "Status Code Page: {0}");

    // Handle status code with lambda
    //app.UseStatusCodePages(async statusCodeContext =>
    //{
    //    statusCodeContext.HttpContext.Response.ContentType = Text.Plain;

    //    await statusCodeContext.HttpContext.Response.WriteAsync($"UseStatusCodePages - Status Code Page: {statusCodeContext.HttpContext.Response.StatusCode}");
    //});

    // Handle status code with redirect and response 302 to client
    //app.UseStatusCodePagesWithRedirects("/Error/StatusCode?statusCode={0}");

    // Handle status code with redirect and response the original status code
    //app.UseStatusCodePagesWithReExecute("/Error/StatusCode", "?statusCode={0}");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Use(async (context, next) =>
//{
//    await next();

//    if (context.Response.StatusCode != 200)
//    {
//        context.Request.Path = "/Error/ErrorHandler";
//        await next();
//    }
//});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.Use(async (context, next) =>
//{
//    var queryBuilder = new QueryBuilder();

//    queryBuilder.Add("param", "modifiedValue");

//    context.Request.QueryString = queryBuilder.ToQueryString();

//    await next();

//    await context.Response.WriteAsync("Response from middleware");
//});

//app.AddFirstMiddleware();

//app.Use(async (context, next) =>
//{
//    var cultureCookie = context.Request.Cookies["culture"];
//    if (!string.IsNullOrEmpty(cultureCookie))
//    {
//        var culture = new CultureInfo(cultureCookie);
//        CultureInfo.CurrentCulture = culture;
//        CultureInfo.CurrentUICulture = culture;
//    }
//    else
//    {
//        CultureInfo.CurrentCulture = new CultureInfo("vi-vn");
//        CultureInfo.CurrentUICulture = new CultureInfo("vi-vn");
//    }

//    await next();
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();