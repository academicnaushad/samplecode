using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        // GET: api/<HealthCheckController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public string HealthCheckStatus()
        {
            try
            {
                return "SUCCESS";
            }
            catch (Exception)
            {

                return "Failed";
            }
           
        }


        // GET api/<HealthCheckController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HealthCheckController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HealthCheckController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HealthCheckController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
