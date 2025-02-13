using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Validator for the SaleItem entity.
/// </summary>
public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(i => i.Product)
            .NotEmpty().WithMessage("Product name is required.");

        RuleFor(i => i.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
            .LessThanOrEqualTo(20).WithMessage("Cannot sell more than 20 identical items.");

        RuleFor(i => i.UnitPrice)
            .GreaterThan(0).WithMessage("Unit price must be greater than zero.");
    }
}
