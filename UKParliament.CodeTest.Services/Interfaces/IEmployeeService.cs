using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Services.Interfaces;

public interface IEmployeeService
{
    Employee Create(); //pass in some vm
    Employee View(int id);
    IEnumerable<Employee> Search(EmployeeSearchRequest? request);
    Employee Update(); //pass in some vm
    void Delete(int id);
}
