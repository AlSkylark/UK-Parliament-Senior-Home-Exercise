namespace UKParliament.CodeTest.Data.Requests;

public class EmployeeSearchRequest : SearchRequest
{
    public string? PayBand { get; set; }
    public string? Department { get; set; }
}
