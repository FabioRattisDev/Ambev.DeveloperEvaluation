using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Validation for the sales creation command.
/// </summary>
public class DeleteSaleCommandValidator : AbstractValidator<DeleteSaleCommand>
{
    public DeleteSaleCommandValidator()
    {
        RuleFor(sale => sale.SaleId).NotEmpty();
    }
}
