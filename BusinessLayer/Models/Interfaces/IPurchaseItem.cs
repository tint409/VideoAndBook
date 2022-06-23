namespace VideoAndBook.BusinessLayer.Models.Interfaces
{
    public interface IPurchaseItem
    {
        string Name { get; set; }
        string? Description { get; set; }

        // Other props...

        bool IsPhysical() => true; // Show case of default implementation, but can be converted to prop.
    }
}
