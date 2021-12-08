using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySchool.ReadingLog.API.Extensions;

namespace MySchool.ReadingLog.API.Controllers
{
    
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        protected string GetMail()
        {
            return this.HttpContext.GetEmail();
        }
    }
}