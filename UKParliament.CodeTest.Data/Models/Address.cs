namespace UKParliament.CodeTest.Data.Models;

public class Address : BaseEntity
{
    public required string Address1 { get; set; }
    public string? Address2 { get; set; }
    public required string Postcode { get; set; }
    public string? County { get; set; }
}
