namespace UKParliament.CodeTest.Services.Mappers.Interfaces;

public interface IPersonMapper<T, TViewModel>
{
    TViewModel Map(T person);
    T MapForSave(TViewModel vm, T existing);
    T MapForCreate(TViewModel vm);
}
