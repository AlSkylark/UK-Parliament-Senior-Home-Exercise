using UKParliament.CodeTest.Data.HATEOAS.Interfaces;
using UKParliament.CodeTest.Data.Requests;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.Services.Interfaces;

namespace UKParliament.CodeTest.Services.Services;

public class EmployeeService() : IEmployeeService
{
    public Task<IResource<EmployeeViewModel>> Create(EmployeeViewModel model)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IResource<IResourceCollection<EmployeeViewModel>>> Search(SearchRequest? request)
    {
        throw new NotImplementedException();
    }

    public Task<IResource<EmployeeViewModel>?> Update(EmployeeViewModel model)
    {
        throw new NotImplementedException();
    }

    public Task<IResource<EmployeeViewModel>?> View(int id)
    {
        throw new NotImplementedException();
    }
}
