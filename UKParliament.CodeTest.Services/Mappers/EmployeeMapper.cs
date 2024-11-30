using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.Mappers.Interfaces;
using UKParliament.CodeTest.Services.Services.Interfaces;

namespace UKParliament.CodeTest.Services.Mappers;

public class EmployeeMapper(ILookUpService lookUpService)
    : BasicPersonMapper<Employee, EmployeeViewModel>,
        IEmployeeMapper
{
    public override EmployeeViewModel Map(Employee person)
    {
        var vm = BasicMap(person);
        vm.Salary = person.Salary;
        vm.BankAccount = person.BankAccount;
        vm.DateJoined = person.DateJoined;
        vm.DateLeft = person.DateLeft;

        if (person.Manager is not null)
        {
            vm.ManagerId = person.ManagerId;
            vm.Manager = MapManager(person.Manager);
        }

        return vm;
    }

    public ShortManagerViewModel MapManager(Employee manager)
    {
        return new ShortManagerViewModel
        {
            FirstName = manager.FirstName,
            LastName = manager.LastName,
            Id = manager.Id,
        };
    }

    public override Employee MapForSave(EmployeeViewModel vm, Employee existing)
    {
        var payBand = lookUpService.SearchPayBands(vm.PayBand);
        var department = lookUpService.SearchDepartments(vm.Department);

        var employee = BasicMapForSave(vm, existing);
        employee.Salary = vm.Salary ?? existing.Salary;
        employee.BankAccount = vm.BankAccount ?? existing.BankAccount;
        employee.DateJoined = vm.DateJoined ?? existing.DateJoined;
        employee.DateLeft = vm.DateLeft ?? existing.DateLeft;

        employee.PayBand = payBand.FirstOrDefault() ?? existing.PayBand;
        employee.Department = department.FirstOrDefault() ?? existing.Department;

        employee.ManagerId = vm.ManagerId ?? existing.ManagerId;

        return employee;
    }

    public override Employee MapForCreate(EmployeeViewModel vm)
    {
        var payBand = lookUpService.SearchPayBands(vm.PayBand);
        var department = lookUpService.SearchDepartments(vm.Department);

        var employee = BasicMapForCreate(vm);
        employee.Salary = vm.Salary ?? 0;
        employee.BankAccount = vm.BankAccount;
        employee.DateJoined = vm.DateJoined ?? DateOnly.FromDateTime(DateTime.Now);
        employee.DateLeft = vm.DateLeft;

        employee.PayBand = payBand.FirstOrDefault();
        employee.Department = department.FirstOrDefault();

        employee.ManagerId = vm.ManagerId;

        return employee;
    }
}
