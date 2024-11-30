using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data.HATEOAS;
using UKParliament.CodeTest.Data.HATEOAS.Interfaces;
using UKParliament.CodeTest.Data.Requests;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.HATEOAS.Interfaces;
using UKParliament.CodeTest.Services.Services.Interfaces;

namespace UKParliament.CodeTest.Web.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class PersonController(
    IPersonService personService,
    IPersonResourceService<PersonViewModel> resourceService,
    IValidator<PersonViewModel> validator
) : ControllerBase
{
    private string GetControllerName() =>
        ControllerContext.RouteData.Values["controller"]?.ToString()?.ToLower() ?? "";

    [HttpGet]
    public async Task<ActionResult<IResource<IResourceCollection<IResource<PersonViewModel>>>>> Get(
        [FromQuery] SearchRequest? request
    )
    {
        var results = await personService.Search(request);
        var collection = new ResourceCollection<IResource<PersonViewModel>>
        {
            Pagination = results.Pagination,
            Results = results.Results.Select(resourceService.GeneratePersonResource),
        };
        var resource = resourceService.GenerateCollectionResource(collection, GetControllerName());
        return Ok(resource);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IResource<PersonViewModel>>> Get(int id)
    {
        var result = await personService.View(id);
        if (result is null)
        {
            return BadRequest("Person not found");
        }

        var resource = resourceService.GeneratePersonResource(result);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<ActionResult<IResource<PersonViewModel>>> Post(
        [FromBody] PersonViewModel person
    )
    {
        var validation = await validator.ValidateAsync(person);
        if (!validation.IsValid)
        {
            return BadRequest(validation);
        }

        var result = await personService.Create(person);
        if (result is null)
        {
            return BadRequest("Failed to create person");
        }

        var resource = resourceService.GeneratePersonResource(result);
        return Ok(resource);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<IResource<PersonViewModel>>> Put(
        [FromBody] PersonViewModel person
    )
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

        var resource = resourceService.GeneratePersonResource(result);
        return Ok(resource);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await personService.Delete(id);

        return NoContent();
    }
}
