using FluentValidation;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services.Services.Interfaces;

namespace UKParliament.CodeTest.Services.Validators;

public class EmployeeValidator : AbstractValidator<EmployeeViewModel>
{
    public EmployeeValidator(ILookUpService lookUpService)
    {
        Include(new PersonValidator());

        RuleFor(e => e.PayBand)
            .Must(pb => lookUpService.SearchPayBands(pb).Any())
            .When(e => e.PayBand is not null)
            .WithMessage("The PayBand you've assigned couldn't be found");

        RuleFor(e => e.Salary)
            .Must((vm, salary) => lookUpService.SearchPayBands(vm.PayBand).Any())
            .When(e => e.Salary is not null)
            .WithMessage("You need to assign a PayBand to set a salary")
            .Must(
                (vm, salary) =>
                {
                    var payBand = lookUpService.SearchPayBands(vm.PayBand).FirstOrDefault();

                    return salary >= payBand!.MinPay && salary <= payBand!.MaxPay;
                }
            )
            .When(vm => vm.PayBand is not null)
            .WithMessage("Salary must be between PayBand min and max pay");
    }
}
