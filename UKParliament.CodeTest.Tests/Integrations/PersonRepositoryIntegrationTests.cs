using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.Models;
using UKParliament.CodeTest.Data.Repositories.Interfaces;
using Xunit;

namespace UKParliament.CodeTest.Tests.Integrations;

[Collection("Database collection")]
public class PersonRepositoryIntegrationTests
{
    private readonly PersonManagerContext _db;
    private readonly BaseIntegrationTests _base;

    public PersonRepositoryIntegrationTests(BaseIntegrationTests @base)
    {
        _base = @base;
        _db = @base.Db;
        @base.ResetDatabase();
    }

    [Fact]
    public async Task View_ReturnsById_Person()
    {
        var eg = _base.Scope.ServiceProvider.GetService<IPersonRepository<Person>>();
        var person = new Person
        {
            FirstName = "Test",
            LastName = "Erino",
            Address = new Address { Address1 = "123", Postcode = "EGH" },
        };
        _db.People.Add(person);
        await _db.SaveChangesAsync();

        var result = eg!.View(person.Id);

        Assert.Multiple(() =>
        {
            result.Should().NotBeNull();
            result!.FirstName.Should().NotBeNull().And.Be("Test");
        });
    }
}
