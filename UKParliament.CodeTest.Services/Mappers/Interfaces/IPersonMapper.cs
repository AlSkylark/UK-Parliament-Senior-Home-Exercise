using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.ViewModels;

namespace UKParliament.CodeTest.Services.Mappers.Interfaces;

public interface IPersonMapper
{
    PersonViewModel Map(Person person);
    Person MapToDb(PersonViewModel vm);
}
