﻿using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.Helpers;
using UKParliament.CodeTest.Services.Mappers.Interfaces;
using UKParliament.CodeTest.Services.Services.Interfaces;

namespace UKParliament.CodeTest.Services.Mappers;

public class EmployeeMapper(ILookUpService lookUpService) : IEmployeeMapper
{
    public EmployeeViewModel Map(Employee person)
    {
        var vm = new EmployeeViewModel
        {
            Id = person.Id,
            CreatedAt = person.CreatedAt,
            UpdatedAt = person.UpdatedAt,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DoB = person.DoB,
            Department = person.Department?.Name,
            PayBand = person.PayBand?.Name,
            EmployeeType = person.EmployeeType.GetDescription(),
            HasManager = person.ManagerId > 0,
            Address = person.Address,
            Inactive = person.DateLeft is not null,
            Salary = person.Salary,
            BankAccount = person.BankAccount,
            DateJoined = person.DateJoined,
            DateLeft = person.DateLeft,
        };

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

    public Employee MapForSave(EmployeeViewModel vm, Employee existing)
    {
        var payBand = lookUpService.SearchPayBands(vm.PayBand);
        var department = lookUpService.SearchDepartments(vm.Department);

        var employee = new Employee
        {
            Id = vm.Id ?? existing.Id,
            FirstName = vm.FirstName ?? existing.FirstName,
            LastName = vm.LastName ?? existing.LastName,
            DoB = vm.DoB ?? existing.DoB,
            Address = vm.Address ?? existing.Address,
            Salary = vm.Salary ?? existing.Salary,
            BankAccount = vm.BankAccount ?? existing.BankAccount,
            DateJoined = vm.DateJoined ?? existing.DateJoined,
            DateLeft = vm.DateLeft ?? existing.DateLeft,
            PayBand = payBand.FirstOrDefault() ?? existing.PayBand,
            Department = department.FirstOrDefault() ?? existing.Department,
            ManagerId = vm.ManagerId ?? existing.ManagerId,
        };

        return employee;
    }

    public Employee MapForCreate(EmployeeViewModel vm)
    {
        var payBand = lookUpService.SearchPayBands(vm.PayBand);
        var department = lookUpService.SearchDepartments(vm.Department);

        var employee = new Employee
        {
            Id = vm.Id ?? 0,
            FirstName = vm.FirstName!,
            LastName = vm.LastName!,
            DoB = vm.DoB,
            Address = vm.Address,
            Salary = vm.Salary ?? 0,
            BankAccount = vm.BankAccount,
            DateJoined = vm.DateJoined ?? DateOnly.FromDateTime(DateTime.Now),
            DateLeft = vm.DateLeft,
            PayBand = payBand.FirstOrDefault(),
            Department = department.FirstOrDefault(),
            ManagerId = vm.ManagerId,
        };

        return employee;
    }
}