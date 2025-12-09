using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Model;
using System.Data.SqlClient;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyDBController : ControllerBase
    {
        IConfiguration config;
        public MyDBController(IConfiguration config)
        {
            this.config = config;
        }
        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            using (var db = new SqlConnection(config["db"]))
            {
                var data = db.Query<CityModel>("select id, name, year from city");
                return Ok(data);
            }
        }

        [HttpGet("GetDataByName/{name}")]
        public IActionResult GetDataByName(string name)
        {
            using (var db = new SqlConnection(config["db"]))
            {
                var data = db.Query<CityModel>($"select id, name, year from city where name like '%{name}%'");
                return Ok(data);
            }
        }

        [HttpPost("AddNewCity")]
        public IActionResult AddNewCity(CityModel model)
        {
            using (var db = new SqlConnection(config["db"]))
            {
                var count = db.Execute($"insert into city (name, year) values('{model.name}', {model.year})");
                return Ok("Added: " + count);
            }
        }

        [HttpPut("EditCity/{id}")]
        public IActionResult EditCity(string id, CityModel model)
        {
            using (var db = new SqlConnection(config["db"]))
            {
                var count = db.Execute($"update city set name = '{model.name}', year = {model.year} where id = {id}");
                return Ok("Updated: " + count);
            }
        }

        [HttpDelete("DeleteCity/{id}")]
        public IActionResult DeleteCity(string id)
        {
            using (var db = new SqlConnection(config["db"]))
            {
                var count = db.Execute($"delete from city where id = {id}");
                return Ok("Deleted: " + count);
            }
        }


        [HttpPost("GetCitiesByIds")]
        public IActionResult GetCitiesByIds(Ids model)
        {
            using (var db = new SqlConnection(config["db"]))
            {
                var data = db.Query<CityModel>($"select id, name, year from city where id in ({model.ids})");
                return Ok(data);
            }
        }
    }
}
