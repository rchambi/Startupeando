using Microsoft.AspNetCore.Http;

namespace Startupeando.Services
{
    public class GreetingService: IGreetingService
    {
        ///services.AddHttpContextAccessor(); colocar en startup o startUpDevelopment
        private readonly IHttpContextAccessor contextAccessor;

        public GreetingService(IHttpContextAccessor contextAccessor) =>
            this.contextAccessor = contextAccessor;

        public string Greeting()
        {
            var httpContext = contextAccessor.HttpContext;
            if (httpContext.User.Identity.IsAuthenticated == false)
            {
                return "Hello there!!!";
            }

            var username = httpContext.User.FindFirst("username")?.Value;
            return $"Hello {username}!!!";
        }
    }
}