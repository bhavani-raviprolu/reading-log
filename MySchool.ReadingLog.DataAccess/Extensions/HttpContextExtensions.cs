using Microsoft.AspNetCore.Http;

namespace MySchool.ReadingLog.DataAccess.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetEmail(this IHttpContextAccessor httpContextAccessor)
        {
            var claim = httpContextAccessor.HttpContext.User.FindFirst(c => c.Type.Contains("emailaddress"));
            return claim?.Value ?? null;
        }
    }
}