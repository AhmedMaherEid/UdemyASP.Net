using LoginUsingMiddleware.Middlewares;

namespace LoginUsingMiddleware.Extensions
{
    public static class LoginMiddlewareExtension
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoginMiddleware>();
        }
    }
}
