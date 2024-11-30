using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Data.Repositories.Interfaces;

public interface IBasePersonRepository<T> : IBaseRepository<T>
    where T : Person
{
    IQueryable<T> Search(SearchRequest? request);
}
