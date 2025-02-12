using System.Net;

namespace LibraryManagementSystem.Utility
{
    public class ForbiddenResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ForbiddenResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"message\": \"You are not authorized to perform this action.\"}");
            }
        }
    }
}
