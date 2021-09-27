using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Mvc;

namespace MySchool.ReadingLog.API.Filters
{
    public class RequestBasedAuthorizationFilter : AuthorizeAttribute
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //context.Result = 
        }
    }
}