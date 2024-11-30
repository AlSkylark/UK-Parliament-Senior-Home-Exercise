namespace UKParliament.CodeTest.Data.Models;

public class Person : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly? DoB { get; set; }
    public EmployeeTypeEnum EmployeeType { get; set; }

    public int? AddressId { get; set; }
    public Address? Address { get; set; }
}
