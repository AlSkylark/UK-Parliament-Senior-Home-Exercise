namespace UKParliament.CodeTest.Data.Repositories.Interfaces;

public interface IPersonRepository<T, TSearch>
{
    Task<T?> Create(T person);
    Task<T?> View(int id);
    IList<T> Search(TSearch? request);
    Task<T?> Update(T person);
    Task Delete(int id);
}
