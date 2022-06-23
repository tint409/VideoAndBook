namespace VideoAndBook.Models
{
    public class PurchaseOrderModel : BaseModel
    {
        public string OrderNumber { get; set; } = string.Empty;
        public CustomerModel Customer { get; init; } = new();
        // Other props...

        public List<PurchaseOrderItemModel>? Items { get; set; } 
        // Items is nullable for get listing api.
        // Ideally, we should have a compact model which doesn't contain items and a full model which contains items.
    }
}
