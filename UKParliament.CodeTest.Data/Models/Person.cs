namespace UKParliament.CodeTest.Data.Models;

public class Person : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly DoB { get; set; }
    public PersonTypeEnum PersonType { get; set; }

    public required Address Address { get; set; }
}
