using Microsoft.AspNetCore.Mvc;

namespace Kodius.Controllers
{
    [ApiController]
    [Route("xx")]
    public class HomeController : Controller
    {
        [HttpGet("index")]
        public String Index()
        {
            return "Hello";
        }
    }
}
