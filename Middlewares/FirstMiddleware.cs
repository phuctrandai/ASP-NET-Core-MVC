namespace ASP_NET_Core_MVC.Middlewares
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            await context.Response.WriteAsync("Value from First Middleware");
        }
    }

    public static class FirstMiddlewareExtensionMethod
    {
        public static IApplicationBuilder AddFirstMiddleware(this IApplicationBuilder application)
        {
            return application.UseMiddleware<FirstMiddleware>();
        }
    }
}
