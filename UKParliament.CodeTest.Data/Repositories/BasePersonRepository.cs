using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Repositories.Interfaces;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Data.Repositories;

public class BasePersonRepository<T, TSearch>(PersonManagerContext db)
    : IPersonRepository<T, TSearch>
    where T : Person
    where TSearch : SearchRequest
{
    public async Task<T?> Create(T person)
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

    protected virtual IQueryable<T> CreateSearchQuery(TSearch? request)
    {
        var query = db.Set<T>().Include(p => p.Address).AsQueryable();
        if (request is not null && !string.IsNullOrWhiteSpace(request.TextSearch))
        {
            query = query.Where(p =>
                EF.Functions.Like(p.FirstName, $"%{request.TextSearch}%")
                || EF.Functions.Like(p.LastName, $"%{request.TextSearch}%")
            );
        }

        return query;
    }

    public IList<T> Search(TSearch? request)
    {
        var query = CreateSearchQuery(request);

        return [.. query.OfType<T>()];
    }

    public async Task<T?> Update(T person)
    {
        db.Update(person);
        await db.SaveChangesAsync();

        return person;
    }

    public async Task<T?> View(int id)
    {
        return await db.Set<T>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }
}
