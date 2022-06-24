using VideoAndBook.Models;

namespace VideoAndBook.BusinessLayer.Models
{
    public class PurchaseOrderDTO : BaseDTO
    {
        public string OrderNumber { get; set; } = string.Empty;
        public CustomerDTO Customer { get; init; } = new();
        // Other props...

        public List<PurchaseOrderItemDTO>? Items { get; set; } 
        // Items is nullable for get listing api.
        // Ideally, we should have a compact model which doesn't contain items and a full model which contains items.
    }
}
