using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Data.Repositories.Interfaces;

public interface IPersonRepository<T>
{
    Task<T?> Create(T person);
    Task<T?> View(int id);
    IList<T> Search(SearchRequest? request);
    Task<T?> Update(T person);
    Task Delete(int id);
}
