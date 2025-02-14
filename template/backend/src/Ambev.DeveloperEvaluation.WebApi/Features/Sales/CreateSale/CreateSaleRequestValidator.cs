namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    using FluentValidation;

    /// <summary>
    /// Validator for CreateSaleRequest.
    /// </summary>
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(sale => sale.Product).NotEmpty().MaximumLength(100);
            RuleFor(sale => sale.Quantity).GreaterThan(0);
            RuleFor(sale => sale.Price).GreaterThan(0);
        }
    }
}
