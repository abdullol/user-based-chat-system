using Microsoft.AspNetCore.Mvc;

namespace ubcs_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
