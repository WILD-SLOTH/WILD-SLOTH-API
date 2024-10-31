using Microsoft.AspNetCore.Mvc;
using WILD.SLOTH.Domain.catalog;

namespace WILD.SLOTH.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok("Hello world.");
        }
    }
}
