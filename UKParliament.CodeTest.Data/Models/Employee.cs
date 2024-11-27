namespace UKParliament.CodeTest.Data.Models;

public class Employee : Person
{
    public int ManagerId { get; set; }
    public Manager? Manager { get; set; }
}
