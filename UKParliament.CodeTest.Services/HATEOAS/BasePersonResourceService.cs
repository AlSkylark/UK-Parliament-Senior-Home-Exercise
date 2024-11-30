using Microsoft.Extensions.Options;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Data.HATEOAS;
using UKParliament.CodeTest.Data.HATEOAS.Interfaces;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.HATEOAS.Interfaces;
using UKParliament.CodeTest.Services.Helpers;

namespace UKParliament.CodeTest.Services.HATEOAS;

public abstract class BasePersonResourceService<T>(IOptions<ApiConfiguration> config)
    : BaseResourceService<T>(config),
        IPersonResourceService<T>
    where T : PersonViewModel
{
    public IResource<T> GeneratePersonResource(T data)
    {
        var path = data.EmployeeType switch
        {
            "Guest" => "person",
            _ => data.EmployeeType?.ToLower() ?? "",
        };

        return new Resource<T>
        {
            Data = data,
            Links =
            [
                Link.GenerateLink(
                    "self",
                    UrlHelpers.Generate(_config.BaseUrl, path, $"{data.Id}"),
                    "GET",
                    "PUT",
                    "DELETE"
                ),
            ],
        };
    }
}
