using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Data.Repositories;

public class PersonRepository(PersonManagerContext db) : BasePersonRepository<Person>(db) { }
