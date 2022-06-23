using BusinessLayer.MandatoryProcessors.Interfaces;
using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer.MandatoryProcessors
{
    /// <summary>
    /// All mandatory steps of the process must implement this.
    /// It uses Chain or Responsibility pattern, that allow re-order steps, stop/next step if needed.
    /// </summary>
    public abstract class POProcessor : IPOProcessor
    {
        protected POProcessor? NextProcessor { get; private set; }

        public int Process(PurchaseOrderModel po) => Process(po, null);

        internal abstract int Process(PurchaseOrderModel po, params object[]? additionalParams);

        public void SetNext(POProcessor next)
        {
            if (NextProcessor == null)
            {
                NextProcessor = next;
            }
            else
            {
                NextProcessor.SetNext(next);
            }
        }
    }
}
