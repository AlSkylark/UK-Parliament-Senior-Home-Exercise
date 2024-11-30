using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Repositories.Interfaces;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Data.Repositories;

public abstract class BasePersonRepository<T>(PersonManagerContext db) : IBasePersonRepository<T>
    where T : Person
{
    public async Task<T> Create(T person)
    {
        db.Add(person);
        await db.SaveChangesAsync();

        return person;
    }

    public async Task Delete(int id)
    {
        var person =
            await db.People.Where(p => p.Id == id).FirstOrDefaultAsync() ?? throw new Exception();
        db.Remove(person);

        await db.SaveChangesAsync();
    }

    /// <summary>
    /// Allows modification of the main Search method, to, for example,
    /// add type specific includes. E.g: <c>Manager.Employees</c>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    protected virtual IQueryable<T> CreateSearchQuery(SearchRequest? request)
    {
        var query = db.Set<T>().AsQueryable();
        if (request is not null)
        {
            query = SearchByText(request, query);
            query = SearchByType(request, query);
        }

        return query.Include(p => p.Address).OrderBy(p => p.Id);
    }

    public IQueryable<T> Search(SearchRequest? request)
    {
        var query = CreateSearchQuery(request);

        return query.OfType<T>();
    }

    private static IQueryable<T> SearchByType(SearchRequest request, IQueryable<T> query)
    {
        if (request.EmployeeType.HasValue)
        {
            query = query.Where(p => p.EmployeeType == request.EmployeeType);
        }

        return query;
    }

    private static IQueryable<T> SearchByText(SearchRequest request, IQueryable<T> query)
    {
        if (!string.IsNullOrWhiteSpace(request.TextSearch))
        {
            query = query.Where(p =>
                EF.Functions.Like(p.FirstName, $"%{request.TextSearch}%")
                || EF.Functions.Like(p.LastName, $"%{request.TextSearch}%")
            );
        }

        return query;
    }

    public async Task<T> Update(T person)
    {
        db.Update(person);
        await db.SaveChangesAsync();

        return person;
    }

    public async Task<T?> GetById(int id)
    {
        return await db.Set<T>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }
}
