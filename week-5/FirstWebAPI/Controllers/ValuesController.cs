using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "Value1", "Value2" });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Value is {id}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"Inserted: {value}");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok($"Updated Id {id} with value {value}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleted Id {id}");
        }
    }
}