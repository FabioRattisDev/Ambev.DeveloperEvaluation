using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    /// <summary>
    /// Command to Get a new sale.
    /// </summary>
    public class GetSaleCommand : IRequest<GetSaleResult>
    {
        /// <summary>
        /// Sale number.
        /// </summary>
        public Guid? SaleId { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new GetSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
