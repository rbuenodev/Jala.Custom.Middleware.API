namespace Jala.Custom.Middleware.API.Middlewares
{
    public class RouteValueMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public RouteValueMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Handler(context);
            await _requestDelegate(context);
        }

        private void Handler(HttpContext context)
        {
            var value = context.Request.QueryString.Value;
            if (!string.IsNullOrEmpty(value))
            {
                Console.WriteLine(value);
            }
        }
    }

    public static class RouteValueMiddlewareClass
    {
        public static IApplicationBuilder UseRouteValueMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RouteValueMiddleware>();

        }
    }
}
