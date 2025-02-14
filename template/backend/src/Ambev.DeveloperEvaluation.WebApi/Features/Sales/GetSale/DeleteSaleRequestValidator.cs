using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    /// <summary>
    /// Validator for DeleteSaleRequest.
    /// </summary>
    public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
    {
        public DeleteSaleRequestValidator()
        {
            RuleFor(sale => sale.Id).NotEmpty();
        }
    }
}
