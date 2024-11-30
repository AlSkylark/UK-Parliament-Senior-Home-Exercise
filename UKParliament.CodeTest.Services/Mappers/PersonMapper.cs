using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.ViewModels;

namespace UKParliament.CodeTest.Services.Mappers;

public class PersonMapper : BasicPersonMapper<Person, PersonViewModel>
{
    public override PersonViewModel Map(Person person)
    {
        return BasicMap(person);
    }

    public override Person MapForSave(PersonViewModel vm, Person existing)
    {
        var person = BasicMapForSave(vm, existing);
        person.EmployeeType = EmployeeTypeEnum.Guest;

        return person;
    }

    public override Person MapForCreate(PersonViewModel vm)
    {
        var person = BasicMapForCreate(vm);
        person.EmployeeType = EmployeeTypeEnum.Guest;

        return person;
    }
}
