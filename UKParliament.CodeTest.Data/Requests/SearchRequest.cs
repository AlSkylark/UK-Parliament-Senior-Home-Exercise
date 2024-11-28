using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Data.Requests;

public class SearchRequest
{
    public string? TextSearch { get; set; }
    public PersonTypeEnum PersonType { get; set; } = PersonTypeEnum.Guest;
}
