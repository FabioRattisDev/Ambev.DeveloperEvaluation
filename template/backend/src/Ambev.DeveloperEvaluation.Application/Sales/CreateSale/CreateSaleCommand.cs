using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Command to create a new sale.
    /// </summary>
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        /// <summary>
        /// Sale number.
        /// </summary>
        public string SaleNumber { get; set; }

        /// <summary>
        /// Date when the sale was made.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Customer information.
        /// </summary>
        public String Customer { get; set; }

        /// <summary>
        /// Total sale amount.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Branch where the sale was made.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// List of products in the sale.
        /// </summary>
        public List<SaleItemDto> Items { get; set; } = new();

        /// <summary>
        /// Whether the sale is cancelled or not.
        /// </summary>
        public bool IsCancelled { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }

    /// <summary>
    /// DTO to represent an item in the sale.
    /// </summary>
    public class SaleItemDto
    {
        /// <summary>
        /// Product ID.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Quantity of the product.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount applied to the product.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Total amount for the item (quantity * unit price - discount).
        /// </summary>
        public decimal TotalAmount => (Quantity * UnitPrice) - Discount;
    }
}
