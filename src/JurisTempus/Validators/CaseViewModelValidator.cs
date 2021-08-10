using System;
using FluentValidation;
using JurisTempus.Data.Entities;
using JurisTempus.ViewModels;

namespace JurisTempus.Validators
{
  public class CaseViewModelValidator: AbstractValidator<CaseViewModel>
  {
    public CaseViewModelValidator()
    {
      RuleFor(c => c.FileNumber).NotEmpty()
                                .Matches(@"^\d{10}$")
                                .WithMessage("File Number must be digits");
      RuleFor(c => c.Status).IsInEnum()
                            .NotEqual(CaseStatus.Invalid)
                            .WithName("CaseStatus");
    }
  }
}
