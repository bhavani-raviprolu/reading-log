using Microsoft.AspNetCore.Mvc;

namespace MySchool.ReadingLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
    }
}