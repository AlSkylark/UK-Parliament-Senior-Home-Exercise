using UKParliament.CodeTest.Data.HATEOAS;
using UKParliament.CodeTest.Data.HATEOAS.Interfaces;
using UKParliament.CodeTest.Data.Repositories.Interfaces;
using UKParliament.CodeTest.Data.Requests;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.HATEOAS.Interfaces;
using UKParliament.CodeTest.Services.Mappers.Interfaces;
using UKParliament.CodeTest.Services.Services.Interfaces;

namespace UKParliament.CodeTest.Services.Services;

public class PersonService(
    IPersonRepository personRepository,
    IPersonMapper mapper,
    IPaginatorService paginatorService,
    IResourceService<PersonViewModel> resourceService
) : IPersonService
{
    const string PATH = "person";

    public async Task<IResource<PersonViewModel>> Create(PersonViewModel model)
    {
        var mappedRequest = mapper.MapToDb(model);
        try
        {
            var result = await personRepository.Create(mappedRequest);
            var mappedResult = mapper.Map(result);
            var resource = resourceService.GenerateResource(mappedResult, PATH);

            return resource;
        }
        catch (Exception e)
        {
            //TODO: We could add logging here
            throw e.GetBaseException();
        }
    }

    public async Task Delete(int id)
    {
        await personRepository.Delete(id);
    }

    public async Task<IResource<IResourceCollection<PersonViewModel>>> Search(
        SearchRequest? request
    )
    {
        var defaultRequest = request ?? new();
        var query = personRepository.SearchAll(request);

        var data = paginatorService.Paginate(query, defaultRequest);
        var pagination = await paginatorService.CreateAsync(query, defaultRequest, PATH);

        var results = data.Select(mapper.Map)
            .Select(m => resourceService.GenerateResource(m, PATH));

        var collection = new ResourceCollection<PersonViewModel>
        {
            Pagination = pagination,
            Results = results,
        };

        var resource = resourceService.GenerateCollectionResource(collection, PATH);

        return resource;
    }

    public async Task<IResource<PersonViewModel>?> Update(PersonViewModel model)
    {
        //var person = await personRepository.GetById((int)model.Id!);
        var mappedRequest = mapper.MapToDb(model);
        var updated = await personRepository.Update(mappedRequest);

        var updatedMapped = mapper.Map(updated);
        if (updatedMapped is null)
        {
            return null;
        }

        var resource = resourceService.GenerateResource(updatedMapped, PATH);
        return resource;
    }

    public async Task<IResource<PersonViewModel>?> View(int id)
    {
        var person = await personRepository.GetById(id);
        if (person is null)
        {
            return null;
        }

        var mapped = mapper.Map(person);
        var resource = resourceService.GenerateResource(mapped, PATH);
        return resource;
    }
}
