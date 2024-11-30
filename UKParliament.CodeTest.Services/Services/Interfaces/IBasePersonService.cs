using UKParliament.CodeTest.Data.HATEOAS.Interfaces;
using UKParliament.CodeTest.Data.Requests;

namespace UKParliament.CodeTest.Services.Services.Interfaces;

public interface IBasePersonService<TViewModel>
{
    Task<IResource<TViewModel>> Create(TViewModel model);
    Task<IResource<TViewModel>?> View(int id);
    Task<IResource<IResourceCollection<TViewModel>>> Search(SearchRequest? request);
    Task<IResource<TViewModel>?> Update(TViewModel model);
    Task Delete(int id);
}
