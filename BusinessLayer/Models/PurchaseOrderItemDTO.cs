using VideoAndBook.BusinessLayer.Models.Interfaces;
using VideoAndBook.BusinessLayer.Models;

namespace VideoAndBook.Models
{
    public class PurchaseOrderItemDTO : BaseDTO
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IPurchaseItem Product { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        // Other props...
    }
}
