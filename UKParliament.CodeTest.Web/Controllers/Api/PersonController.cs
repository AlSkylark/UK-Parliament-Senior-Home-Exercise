using Microsoft.AspNetCore.Mvc;

namespace UKParliament.CodeTest.Web.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    // GET: api/<PersonController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<PersonController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<PersonController>
    [HttpPost]
    public void Post([FromBody] string value) { }

    // PUT api/<PersonController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) { }

    // DELETE api/<PersonController>/5
    [HttpDelete("{id}")]
    public void Delete(int id) { }
}
