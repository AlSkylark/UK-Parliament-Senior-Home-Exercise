using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Repositories.Interfaces;

namespace UKParliament.CodeTest.Data.Repositories;

public class PersonRepository(PersonManagerContext db) : IPersonRepository
{
    public Person Create(Person person)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        var person = db.People.Where(p => p.Id == id).FirstOrDefault() ?? throw new Exception();
        db.Remove(person);
    }

    public IEnumerable<Person> Search(string searchText)
    {
        throw new NotImplementedException();
    }

    public Person Update(Person person)
    {
        throw new NotImplementedException();
    }

    public Person? View(int id)
    {
        return db.People.Where(p => p.Id == id).FirstOrDefault();
    }
}
