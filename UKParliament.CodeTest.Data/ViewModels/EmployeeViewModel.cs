namespace UKParliament.CodeTest.Data.ViewModels;

public class EmployeeViewModel : PersonViewModel
{
    public decimal? Salary { get; set; }
    public string? BankAccount { get; set; }

    public DateOnly? DateJoined { get; set; }
    public DateOnly? DateLeft { get; set; }

    public int? ManagerId { get; set; }
    public ShortManagerViewModel? Manager { get; set; }
}
