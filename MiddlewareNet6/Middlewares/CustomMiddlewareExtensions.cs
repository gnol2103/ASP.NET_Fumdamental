namespace MiddlewareNet6.Middlewares
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder){
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}