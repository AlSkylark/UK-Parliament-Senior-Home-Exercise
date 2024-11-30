using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Repositories.Interfaces;
using UKParliament.CodeTest.Services.Services.Interfaces;

namespace UKParliament.CodeTest.Services.Services;

public class LookUpService(
    IBaseRepository<Department> departmentRepo,
    IBaseRepository<PayBand> payBandRepo
) : ILookUpService
{
    public async Task<Department?> GetDepartment(int id)
    {
        return await departmentRepo.GetById(id);
    }

    public async Task<PayBand?> GetPayBand(int id)
    {
        return await payBandRepo.GetById(id);
    }

    public IEnumerable<Department> SearchDepartments(string? name)
    {
        var departments = departmentRepo.Search();
        return departments
            .Where(d => string.Equals(d.Name, name, StringComparison.CurrentCultureIgnoreCase))
            .AsEnumerable();
    }

    public IEnumerable<PayBand> SearchPayBands(string? name)
    {
        var payBands = payBandRepo.Search();
        return payBands
            .Where(d => string.Equals(d.Name, name, StringComparison.CurrentCultureIgnoreCase))
            .AsEnumerable();
    }
}
