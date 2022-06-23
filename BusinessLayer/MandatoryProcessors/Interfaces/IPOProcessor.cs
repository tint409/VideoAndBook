using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer.MandatoryProcessors.Interfaces
{
    public interface IPOProcessor
    {
        int Process(PurchaseOrderModel po);
    }
}
