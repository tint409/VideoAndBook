using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer.OptionalProcessors
{
    public class DeliveryCreationProcessor : IObserver<PurchaseOrderModel>
    {
        public void OnCompleted()
        {
            // Cleanup
        }

        public void OnError(Exception error)
        {
            // Do nothing, PO isn't created.
        }

        public void OnNext(PurchaseOrderModel value)
        {
            // Create Delivery if there is a physical items in the order
            
            // If delivery fails to be created, keep the PO, implement re-try mechanism
        }
    }
}
