using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Data.Repositories;

public class PersonRepository(PersonManagerContext db)
    : BasePersonRepository<Person, SearchRequest>(db) { }
