using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Repositories.Interfaces;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Data.Repositories;

public class PersonRepository(PersonManagerContext db)
    : BasePersonRepository<Person>(db),
        IPersonRepository
{
    /// <summary>
    /// Searches ALL People indiscriminately and includes all details except managerial info.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public IQueryable<Person> SearchAll(SearchRequest? request)
    {
        var query = CreateSearchQuery(request);
        query = query
            .Include(p => (p as Employee)!.PayBand)
            .Include(p => (p as Employee)!.Department);

        if (request is not null)
        {
            query = SearchByPayBand(query, request);
            query = SearchByDepartment(query, request);
        }

        return query;
    }

    private static IQueryable<Person> SearchByPayBand(
        IQueryable<Person> query,
        SearchRequest request
    )
    {
        if (!string.IsNullOrWhiteSpace(request.PayBand))
        {
            query = query.Where(p =>
                string.Compare((p as Employee)!.PayBand!.Name, request.PayBand, true) == 0
            );
        }
        return query;
    }

    private static IQueryable<Person> SearchByDepartment(
        IQueryable<Person> query,
        SearchRequest request
    )
    {
        if (!string.IsNullOrWhiteSpace(request.Department))
        {
            query = query.Where(p =>
                string.Compare((p as Employee)!.Department!.Name, request.Department, true) == 0
            );
        }
        return query;
    }
}
