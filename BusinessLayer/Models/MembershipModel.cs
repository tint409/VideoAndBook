using VideoAndBook.BusinessLayer.Models.Interfaces;

namespace VideoAndBook.BusinessLayer.Models
{
    public class MembershipModel : BaseModel, IPurchaseItem
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public bool IsPhysical() => false;
    }
}
