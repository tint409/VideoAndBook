using VideoAndBook.BusinessLayer.Models.Interfaces;

namespace VideoAndBook.BusinessLayer.Models
{
    public enum MembershipType
    {
        Book,
        Video,
        Premium
    }

    public class MembershipDTO : BaseDTO, IPurchaseItem
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public MembershipType MembershipType { get; set; }

        public bool IsPhysical() => false;
    }
}
