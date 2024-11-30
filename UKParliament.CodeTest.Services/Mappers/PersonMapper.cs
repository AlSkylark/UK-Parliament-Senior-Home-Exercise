using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.Helpers;
using UKParliament.CodeTest.Services.Mappers.Interfaces;

namespace UKParliament.CodeTest.Services.Mappers;

public class PersonMapper : IPersonMapper
{
    public PersonViewModel Map(Person person)
    {
        var employee = person as Employee;
        return new PersonViewModel
        {
            Id = person.Id,
            CreatedAt = person.CreatedAt,
            UpdatedAt = person.UpdatedAt,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Department = employee?.Department?.Name,
            PayBand = employee?.PayBand?.Name,
            EmployeeType = person.EmployeeType.GetDescription(),
            HasManager = employee?.ManagerId > 0,
            Inactive = employee?.DateLeft is not null,
        };
    }

    public Person MapToDb(PersonViewModel vm)
    {
        return new Person
        {
            Id = vm.Id ?? 0,
            FirstName = vm.FirstName!,
            LastName = vm.LastName!,
            EmployeeType = EmployeeTypeEnum.Guest,
        };
    }
}
