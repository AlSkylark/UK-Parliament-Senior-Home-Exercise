using Microsoft.Extensions.Options;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.ViewModels;

namespace UKParliament.CodeTest.Services.HATEOAS;

public class EmployeeResourceService(IOptions<ApiConfiguration> config)
    : BasePersonResourceService<EmployeeViewModel>(config) { }
