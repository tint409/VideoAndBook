using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer.OptionalProcessors
{
    internal class POObservationUnsubscriber: IDisposable
    {
        private List<IObserver<PurchaseOrderDTO>> _observers;
        private IObserver<PurchaseOrderDTO> _observer;

        public POObservationUnsubscriber(List<IObserver<PurchaseOrderDTO>> observers, IObserver<PurchaseOrderDTO> observer)
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
