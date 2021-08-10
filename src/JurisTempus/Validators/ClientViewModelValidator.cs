using System;
using FluentValidation;
using JurisTempus.ViewModels;

namespace JurisTempus.Validators
{
  public class ClientViewModelValidator : AbstractValidator<ClientViewModel>
  {
    public ClientViewModelValidator()
    {
      RuleFor(c => c.Name).NotEmpty()
                          .MinimumLength(5)
                          .MaximumLength(100);

      RuleFor(c => c.ContactName).MaximumLength(20);

      When(c => !string.IsNullOrEmpty(c.Phone) || !string.IsNullOrEmpty(c.ContactName),
        () =>
        {
          RuleFor(c => c.Phone).NotEmpty()
                               .WithMessage("Phone cannot be empty, if Contact Name is created");
          RuleFor(c => c.ContactName).NotEmpty()
                               .WithMessage("Contact Name cannot be empty, if Phone is created");
        });
    }
  }
}
