
namespace ubcs_server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class HomeController : ApiController
    {
        public ActionResult Get()
        {
            return Ok("Works");
        }
    }
}
