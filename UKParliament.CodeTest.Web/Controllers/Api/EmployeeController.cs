using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data.Requests;
using UKParliament.CodeTest.Services.Interfaces;

namespace UKParliament.CodeTest.Web.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Object>> Search([FromQuery] EmployeeSearchRequest? request)
    {
        var results = employeeService.Search(request);
        return Ok(
            results.Select(e => new
            {
                e.LastName,
                e.FirstName,
                e.PayBand,
            })
        );
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
