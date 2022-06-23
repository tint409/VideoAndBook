using BusinessLayer.MandatoryProcessors;
using BusinessLayer.MandatoryProcessors.Interfaces;
using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer
{
    public partial class POCreationProcessor : POProcessor, IPOProcessor
    {
        internal override int Process(PurchaseOrderModel po, params object[]? additionalParams)
        {
            // Validating and creating PO
            var createdPOID = 999;
            po.Id = createdPOID;

            _observers.ForEach(o => 
            {
                if (po.Id > 0)
                    o.OnNext(po);
                else
                    o.OnError(new Exception("Something wrong"));
            });

            // If activate membership successfully, go next step, if not, stop
            return createdPOID > 0 ? (NextProcessor?.Process(po) ?? createdPOID) : 0;
        }
    }
}
