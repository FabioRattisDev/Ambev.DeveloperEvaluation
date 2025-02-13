using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Validator for the Sale entity.
/// </summary>
public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(s => s.Customer)
            .NotEmpty().WithMessage("Customer is required.");

        RuleFor(s => s.Branch)
            .NotEmpty().WithMessage("Branch is required.");

        RuleFor(s => s.Items)
            .NotEmpty().WithMessage("At least one item is required.");
    }
}
