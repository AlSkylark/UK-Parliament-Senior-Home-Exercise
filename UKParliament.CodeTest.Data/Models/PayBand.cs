namespace UKParliament.CodeTest.Data.Models;

public class PayBand : BaseEntity
{
    public required string Name { get; set; }
    public decimal MinPay { get; set; }
    public decimal MaxPay { get; set; }
}
