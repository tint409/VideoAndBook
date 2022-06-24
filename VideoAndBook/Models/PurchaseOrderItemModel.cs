namespace VideoAndBook.Models
{
    public class PurchaseOrderItemModel : BaseModel
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        // Other props...
    }
}
