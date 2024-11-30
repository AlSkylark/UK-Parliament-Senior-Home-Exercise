using UKParliament.CodeTest.Data.HATEOAS;
using UKParliament.CodeTest.Data.HATEOAS.Interfaces;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Repositories.Interfaces;
using UKParliament.CodeTest.Data.Requests;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.HATEOAS.Interfaces;
using UKParliament.CodeTest.Services.Mappers.Interfaces;
using UKParliament.CodeTest.Services.Services.Interfaces;

namespace UKParliament.CodeTest.Services.Services;

public class PersonService(
    IPersonRepository personRepository,
    IPersonMapper<Person, PersonViewModel> mapper,
    IPaginatorService paginatorService
) : IPersonService
{
    const string PATH = "person";

    public async Task<PersonViewModel?> Create(PersonViewModel model)
    {
        var mappedRequest = mapper.MapForCreate(model);

        var result = await personRepository.Create(mappedRequest);
        var mappedResult = mapper.Map(result);

        return mappedResult;
    }

    public async Task Delete(int id)
    {
        await personRepository.Delete(id);
    }

    public async Task<IResourceCollection<PersonViewModel>> Search(SearchRequest? request)
    {
        var defaultRequest = request ?? new();
        var query = personRepository.SearchAll(request);

        var data = paginatorService.Paginate(query, defaultRequest);
        var pagination = await paginatorService.CreateAsync(query, defaultRequest, PATH);

        var results = data.Select(mapper.Map);

        var collection = new ResourceCollection<PersonViewModel>
        {
            Pagination = pagination,
            Results = results,
        };

        return collection;
    }

    public async Task<PersonViewModel?> Update(PersonViewModel model)
    {
        var existing = await personRepository.GetById(model.Id ?? 0);
        if (existing is null || existing.EmployeeType != EmployeeTypeEnum.Guest)
        {
            return null;
        }

        var mappedRequest = mapper.MapForSave(model, existing);
        var updated = await personRepository.Update(mappedRequest);

        var updatedMapped = mapper.Map(updated);
        if (updatedMapped is null)
        {
            return null;
        }

        return updatedMapped;
    }

    public async Task<PersonViewModel?> View(int id)
    {
        var person = await personRepository.GetById(id);
        if (person is null)
        {
            return null;
        }

        var mapped = mapper.Map(person);
        return mapped;
    }
}
