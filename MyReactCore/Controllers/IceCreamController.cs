using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyReactCore.Abstract;

namespace MyReactCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IceCreamController : ControllerBase
    {
        ICream cream;
        public IceCreamController(ICream cream) 
        { 
            this.cream = cream;
        }

        [HttpGet("GetIceCream")]
        public ActionResult GetIceCream()
        {
            return Ok(cream.GetIceCream());
        }
    }
}
