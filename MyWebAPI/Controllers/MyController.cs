using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyWebAPI.Model;

namespace MyWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        [HttpGet("sayhello")]
        public ActionResult SayHello()
        {
            return Ok("Hello, World!");
        }

        [HttpGet("sayname/{name}")]
        public ActionResult SayName(string name)
        {
            return Ok($"Hello, {name}");
        }
        [HttpGet("sayfio/{lname}/{fname}")]
        public ActionResult SayFio(string lname, string fname)
        {
            return Ok($"Hello, {lname} {fname}");
        }

        [HttpPost("sayfio_post")]
        public ActionResult SayFioPost(FioModel model)
        {
            return Ok($"Hello, {model.lname} {model.fname}");
        }
    }
}
