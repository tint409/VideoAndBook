using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer.OptionalProcessors
{
    internal class POObservationUnsubscriber: IDisposable
    {
        private List<IObserver<PurchaseOrderModel>> _observers;
        private IObserver<PurchaseOrderModel> _observer;

        public POObservationUnsubscriber(List<IObserver<PurchaseOrderModel>> observers, IObserver<PurchaseOrderModel> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
