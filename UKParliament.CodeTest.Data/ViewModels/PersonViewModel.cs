﻿namespace UKParliament.CodeTest.Data.ViewModels;

public class PersonViewModel : BaseViewModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmployeeType { get; set; }
    public string? PayBand { get; set; }
    public string? Department { get; set; }
    public bool Inactive { get; set; }
    public bool HasManager { get; set; }
}