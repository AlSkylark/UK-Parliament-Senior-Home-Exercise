using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Data.Repositories.Interfaces;

public interface IBasePersonRepository<T>
{
    Task<T> Create(T person);
    Task<T?> GetById(int id);
    IQueryable<T> Search(SearchRequest? request);
    Task<T> Update(T person);
    Task Delete(int id);
}
