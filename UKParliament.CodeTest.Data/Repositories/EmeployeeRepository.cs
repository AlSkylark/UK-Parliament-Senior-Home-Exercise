using Microsoft.EntityFrameworkCore;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Data.Repositories;

public class EmeployeeRepository(PersonManagerContext db)
    : BasePersonRepository<Employee, EmployeeSearchRequest>(db)
{
    protected override IQueryable<Employee> CreateSearchQuery(EmployeeSearchRequest? request)
    {
        var query = base.CreateSearchQuery(request);

        if (request is not null && !string.IsNullOrWhiteSpace(request.PayBand))
        {
            query = query.Where(e => e.PayBand != null && e.PayBand.Name == request.PayBand);
        }

        return query.Include(p => p.PayBand);
    }
}
