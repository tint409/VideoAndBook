using VideoAndBook.BusinessLayer.Models.Interfaces;

namespace VideoAndBook.BusinessLayer.Models
{
    public class VideoDTO : BaseDTO, IPurchaseItem
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
