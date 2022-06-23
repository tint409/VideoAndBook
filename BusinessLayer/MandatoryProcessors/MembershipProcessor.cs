using BusinessLayer.MandatoryProcessors.Interfaces;
using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer.MandatoryProcessors
{
    internal class MembershipProcessor : POProcessor, IPOProcessor
    {
        internal override int Process(PurchaseOrderModel po, params object[]? additionalParams)
        {
            // Activating membership
            var _IsActivated = true;

            // If activate membership successfully, go next step, if not, stop
            return _IsActivated ? (NextProcessor?.Process(po) ?? 0) : 0;
        }
    }
}
