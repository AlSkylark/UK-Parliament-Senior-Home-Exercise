namespace UKParliament.CodeTest.Data.Models;

public class Person : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? BankAccount { get; set; }
    public DateOnly DateJoined { get; set; }
    public DateOnly DateLeft { get; set; }
    public DateOnly DoB { get; set; }
    public decimal Salary { get; set; }

    public required Address Address { get; set; }
    public PayBand? PayBand { get; set; }
    public Department? Department { get; set; }
}
