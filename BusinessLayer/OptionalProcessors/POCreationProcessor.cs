using BusinessLayer.OptionalProcessors;
using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer
{
    /// <summary>
    /// This is partial class of POCreationProcessor
    /// It uses observer pattern. It allows the PO data is observed and notified other optional processors
    /// Optional processors:
    ///     If fail to process, dont roll back the PO, but can re-try the task later.
    ///     Observers are independent, and 1 observer fail doesn't affect other observer.
    /// </summary>
    public partial class POCreationProcessor : IObservable<PurchaseOrderDTO>
    {
        private List<IObserver<PurchaseOrderDTO>> _observers = new();

        public IDisposable Subscribe(IObserver<PurchaseOrderDTO> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new POObservationUnsubscriber(_observers, observer);
        }
    }
}
