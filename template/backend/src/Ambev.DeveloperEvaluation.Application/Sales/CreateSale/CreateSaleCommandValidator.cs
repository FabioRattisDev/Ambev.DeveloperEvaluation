using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validation for the sales creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.Customer).NotEmpty();
        RuleFor(sale => sale.TotalAmount).GreaterThan(0);
        RuleFor(sale => sale.Items).NotEmpty();
        RuleForEach(sale => sale.Items).SetValidator(new SaleItemValidator());
    }
}

/// <summary>
/// Validation for sale items.
/// </summary>
public class SaleItemValidator : AbstractValidator<SaleItemDto>
{
    public SaleItemValidator()
    {
        RuleFor(item => item.Product).NotEmpty();
        RuleFor(item => item.Quantity).GreaterThan(0);
        RuleFor(item => item.UnitPrice).GreaterThan(0);
    }
}
