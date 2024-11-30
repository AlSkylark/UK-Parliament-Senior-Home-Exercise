namespace UKParliament.CodeTest.Data.Models;

public class Person : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly DoB { get; set; }
    public EmployeeTypeEnum EmployeeType { get; set; }

    public Address? Address { get; set; }
}
