using VideoAndBook.BusinessLayer.Models.Interfaces;

namespace VideoAndBook.BusinessLayer.Models
{
    public class BookModel : BaseModel, IPurchaseItem
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
