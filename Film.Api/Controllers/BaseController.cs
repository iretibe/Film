using Microsoft.AspNetCore.Mvc;

namespace Film.Api.Controllers
{
    [ApiController]    
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {
    }
}
