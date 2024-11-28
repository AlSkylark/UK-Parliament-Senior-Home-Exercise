using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Services;

public interface IPersonService
{
    Person Create(); //pass in some vm
    Person View(int id);
    IEnumerable<Person> Search(SearchRequest? request);
    Person Update(); //pass in some vm
    void Delete(int id);
}
