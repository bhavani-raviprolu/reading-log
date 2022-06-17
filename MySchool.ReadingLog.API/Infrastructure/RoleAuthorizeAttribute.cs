using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySchool.ReadingLog.API.Extensions;
using MySchool.ReadingLog.Domain;
using MySchool.ReadingLog.Services.Interfaces;
using System.Threading.Tasks;

namespace MySchool.ReadingLog.API.Infrastructure
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly Role _requiredRole;

        public RoleAuthorizeAttribute(Role requiredRole)
        {
            this._requiredRole = requiredRole;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var email = context.HttpContext.GetEmail();

            var service = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;

            var user = await service.GetAsync(email);

            if (user == null || (user.Role & _requiredRole) == Role.None)
            {
                context.Result = new ForbidResult();
                return;
            }

           

            return;
        }
    }
}