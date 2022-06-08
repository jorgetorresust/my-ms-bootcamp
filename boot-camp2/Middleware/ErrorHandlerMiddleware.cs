using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace boot_camp2.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,ILogger<Program> logger)
        {
            try
            {
               await  _next(httpContext);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlerExtensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
