using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Services;

public interface IPersonService
{
    Person Create(); //pass in some vm
    Person View(int id);
    IEnumerable<Person> Search(string searchText);
    Person Update(); //pass in some vm
    void Delete(int id);
}
