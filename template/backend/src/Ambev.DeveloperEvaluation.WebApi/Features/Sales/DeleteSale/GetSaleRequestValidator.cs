namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    using FluentValidation;

    /// <summary>
    /// Validator for GetSaleRequest.
    /// </summary>
    public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
    {
        public GetSaleRequestValidator()
        {
            RuleFor(sale => sale.Id).NotEmpty();
        }
    }
}
