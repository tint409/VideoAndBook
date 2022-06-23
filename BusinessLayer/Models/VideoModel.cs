using VideoAndBook.BusinessLayer.Models.Interfaces;

namespace VideoAndBook.BusinessLayer.Models
{
    public class VideoModel : BaseModel, IPurchaseItem
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
