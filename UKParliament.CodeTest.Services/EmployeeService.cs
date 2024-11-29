using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Repositories.Interfaces;
using UKParliament.CodeTest.Data.Requests;
using UKParliament.CodeTest.Services.Interfaces;

namespace UKParliament.CodeTest.Services;

public class EmployeeService(IPersonRepository<Employee, EmployeeSearchRequest> employeeRepository)
    : IEmployeeService
{
    public Employee Create()
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Employee> Search(EmployeeSearchRequest? request)
    {
        var data = employeeRepository.Search(request);
        return data;
    }

    public Employee Update()
    {
        throw new NotImplementedException();
    }

    public Employee View(int id)
    {
        throw new NotImplementedException();
    }
}
