using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Data.Repositories.Interfaces;

public interface IPersonRepository : IBasePersonRepository<Person>
{
    IQueryable<Person> SearchAll(SearchRequest? request);
}
