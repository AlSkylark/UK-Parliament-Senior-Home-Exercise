using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Repositories.Interfaces;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Services;

public class PersonService(IPersonRepository<Person> personRepository) : IPersonService
{
    public Person Create()
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Person> Search(SearchRequest? request)
    {
        var data = personRepository.Search(request);
        return data;
    }

    public Person Update()
    {
        throw new NotImplementedException();
    }

    public Person View(int id)
    {
        throw new NotImplementedException();
    }
}
