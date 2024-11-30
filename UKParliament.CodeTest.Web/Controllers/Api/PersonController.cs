using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data.Requests;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.Services.Interfaces;

namespace UKParliament.CodeTest.Web.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class PersonController(IPersonService personService, IValidator<PersonViewModel> validator)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonViewModel>>> Get(
        [FromQuery] SearchRequest request
    )
    {
        var results = await personService.Search(request);
        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonViewModel>> Get(int id)
    {
        var result = await personService.View(id);
        if (result is null)
        {
            return BadRequest("Person not found");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonViewModel>> Post([FromBody] PersonViewModel person)
    {
        var validation = await validator.ValidateAsync(person);
        if (!validation.IsValid)
        {
            return BadRequest(validation);
        }

        var result = await personService.Create(person);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PersonViewModel>> Put([FromBody] PersonViewModel person)
    {
        var validation = await validator.ValidateAsync(person);
        if (!validation.IsValid)
        {
            return BadRequest(validation);
        }

        var result = await personService.Update(person);
        if (result is null)
        {
            return BadRequest("Person not found");
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await personService.Delete(id);

        return NoContent();
    }
}
