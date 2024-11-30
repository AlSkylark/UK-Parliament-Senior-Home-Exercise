using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.ViewModels;

namespace UKParliament.CodeTest.Services.Mappers.Interfaces;

public interface IEmployeeMapper : IPersonMapper<Employee, EmployeeViewModel>
{
    ShortManagerViewModel MapManager(Employee manager);
}
