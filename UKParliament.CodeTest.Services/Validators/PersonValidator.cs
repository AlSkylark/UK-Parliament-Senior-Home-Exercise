using FluentValidation;
using UKParliament.CodeTest.Data.ViewModels;

namespace UKParliament.CodeTest.Services.Validators;

public class PersonValidator : AbstractValidator<PersonViewModel>
{
    public PersonValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(p => p.LastName).NotEmpty().MinimumLength(2);
    }
}
