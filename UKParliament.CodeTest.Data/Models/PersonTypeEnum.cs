using System.ComponentModel;

namespace UKParliament.CodeTest.Data.Models;

public enum EmployeeTypeEnum
{
    [Description("Guest")]
    Guest,

    [Description("Employee")]
    Employee,

    [Description("Manager")]
    Manager,
}
