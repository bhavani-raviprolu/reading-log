using Microsoft.AspNetCore.Mvc.Filters;
using MySchool.ReadingLog.API.Extensions;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.API.Infrastructure
{
    public class RoleAuthorizeAttribute : ActionFilterAttribute, IAsyncAuthorizationFilter
    {
        private readonly Role _requiredRole;

        public RoleAuthorizeAttribute(Role requiredRole)
        {
            this._requiredRole = requiredRole;
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var email = context.HttpContext.GetEmail();

            var service = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;

            var user = service.Get(email).Result;

            if (user == null || !user.Role.HasFlag(_requiredRole))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return context.HttpContext.Response.CompleteAsync();
            }

            return Task.CompletedTask;
        }
    }
}