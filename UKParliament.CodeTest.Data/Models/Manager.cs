namespace UKParliament.CodeTest.Data.Models;

public class Manager : Person
{
    public IEnumerable<Employee> Employees { get; set; } = [];
}
