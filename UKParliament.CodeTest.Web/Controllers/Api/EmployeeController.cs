using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Web.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController() : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Object>> Search([FromQuery] SearchRequest? request)
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public string View(int id)
    {
        return "value";
    }

    [HttpPost]
    public void Create([FromBody] string value) { }

    [HttpPut("{id}")]
    public void Update(int id, [FromBody] string value) { }

    [HttpDelete("{id}")]
    public void Delete(int id) { }
}
