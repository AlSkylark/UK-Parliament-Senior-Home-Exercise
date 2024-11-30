using UKParliament.CodeTest.Data.HATEOAS.Interfaces;

namespace UKParliament.CodeTest.Services.HATEOAS.Interfaces;

public interface IPersonResourceService<T> : IResourceService<T>
{
    IResource<T> GeneratePersonResource(T data);
}
