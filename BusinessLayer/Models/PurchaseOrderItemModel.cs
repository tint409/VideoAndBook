using VideoAndBook.BusinessLayer.Models.Interfaces;
using VideoAndBook.BusinessLayer.Models;

namespace VideoAndBook.Models
{
    public class PurchaseOrderItemModel : BaseModel
    {
        public IPurchaseItem Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        // Other props...
    }
}
