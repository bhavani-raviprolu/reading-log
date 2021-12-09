using Microsoft.AspNetCore.Http;
using MySchool.ReadingLog.Domain;
using System.Security.Claims;

namespace MySchool.ReadingLog.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetEmail(this HttpContext context)
        {
            return context.User.Get("emailaddress");
        }

        public static User GetUser(this ClaimsPrincipal context)
        {
            return new User
            {
                FirstName = context.Get("givenname"),
                LastName = context.Get("surname"),
                EmailAddress = context.Get("emailaddress")
            };
        }

        public static string Get(this ClaimsPrincipal principal, string claim)
        {
            var result = principal.FindFirst(c => c.Type.Contains(claim));
            return result?.Value ?? null;
        }
    }
}