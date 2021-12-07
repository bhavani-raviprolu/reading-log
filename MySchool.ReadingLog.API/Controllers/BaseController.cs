using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MySchool.ReadingLog.API.Controllers
{
    
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
    }
}