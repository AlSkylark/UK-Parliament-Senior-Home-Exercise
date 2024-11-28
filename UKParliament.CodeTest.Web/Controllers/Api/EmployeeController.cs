using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Requests;
using UKParliament.CodeTest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UKParliament.CodeTest.Web.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IPersonService personService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> Search([FromQuery] SearchRequest? request)
    {
        return Ok(personService.Search(request));
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
