﻿using UKParliament.CodeTest.Data.HATEOAS.Interfaces;

namespace UKParliament.CodeTest.Services.HATEOAS.Interfaces;

public interface IResourceService<T>
{
    IResource<IResourceCollection<T>> GenerateCollectionResource(
        IResourceCollection<T> collection,
        string path
    );
    IResource<T> GenerateResource(T data, string path);
}