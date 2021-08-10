using System;
using FluentValidation;
using JurisTempus.ViewModels;

namespace JurisTempus.Validators
{
  public class ContactViewModelValidator: AbstractValidator<ContactViewModel>
  {
    public ContactViewModelValidator()
    {
      RuleFor(c => c.Email).NotEmpty()
                           .EmailAddress();
      RuleFor(c => c.Subject).NotEmpty()
                             .MaximumLength(100);
      RuleFor(c => c.Message).NotEmpty()
                             .MaximumLength(4000);
    }
  }
}
