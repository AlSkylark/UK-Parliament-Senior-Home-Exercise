using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.Helpers;
using UKParliament.CodeTest.Services.Mappers.Interfaces;

namespace UKParliament.CodeTest.Services.Mappers;

public abstract class BasicPersonMapper<T, TViewModel> : IPersonMapper<T, TViewModel>
    where T : Person, new()
    where TViewModel : PersonViewModel, new()
{
    public TViewModel BasicMap(T person)
    {
        var employee = person as Employee;
        var vm = new TViewModel
        {
            Id = person.Id,
            CreatedAt = person.CreatedAt,
            UpdatedAt = person.UpdatedAt,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DoB = person.DoB,
            Department = employee?.Department?.Name,
            PayBand = employee?.PayBand?.Name,
            EmployeeType = person.EmployeeType.GetDescription(),
            HasManager = employee?.ManagerId > 0,
            Address = person.Address,
            Inactive = employee?.DateLeft is not null,
        };

        return vm;
    }

    public T BasicMapForSave(TViewModel vm, T existing)
    {
        var person = new T
        {
            Id = vm.Id ?? existing.Id,
            FirstName = vm.FirstName ?? existing.FirstName,
            LastName = vm.LastName ?? existing.LastName,
            DoB = vm.DoB ?? existing.DoB,
            Address = vm.Address ?? existing.Address,
        };

        return person;
    }

    public T BasicMapForCreate(TViewModel vm)
    {
        var person = new T
        {
            Id = vm.Id ?? 0,
            FirstName = vm.FirstName!,
            LastName = vm.LastName!,
            DoB = vm.DoB,
            Address = vm.Address,
        };

        return person;
    }

    public abstract TViewModel Map(T person);

    public abstract T MapForSave(TViewModel vm, T existing);

    public abstract T MapForCreate(TViewModel vm);
}
