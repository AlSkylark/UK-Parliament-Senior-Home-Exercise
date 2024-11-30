namespace UKParliament.CodeTest.Data.Models;

public class Employee : Person
{
    public string? BankAccount { get; set; }
    public DateOnly DateJoined { get; set; }
    public DateOnly? DateLeft { get; set; }
    public decimal Salary { get; set; }

    public PayBand? PayBand { get; set; }
    public Department? Department { get; set; }

    public int ManagerId { get; set; }
    public Manager? Manager { get; set; }
}
