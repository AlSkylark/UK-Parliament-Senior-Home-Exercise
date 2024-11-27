using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Data.Repositories.Interfaces;

public interface IPersonRepository
{
    Person? Create(Person person);
    Person? View(int id);
    IEnumerable<Person> Search(string searchText);
    Person? Update(Person person);
    void Delete(int id);
}
