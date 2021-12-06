using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Net;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.API.Infrastructure
{
    public class RoleAuthorizeAttribute : ActionFilterAttribute, IAsyncAuthorizationFilter
    {
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var hasheader = context.HttpContext.Request.Headers.TryGetValue("X-apiuser", out StringValues header);

            if (!hasheader || !header.Equals("bhavani"))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return context.HttpContext.Response.CompleteAsync();

            }


            return Task.CompletedTask;
        }
    }
}