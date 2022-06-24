using BusinessLayer.MandatoryProcessors;
using BusinessLayer.MandatoryProcessors.Interfaces;
using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer
{
    public partial class POCreationProcessor : POProcessor, IPOProcessor
    {
        internal override int Process(PurchaseOrderDTO po, params object[]? additionalParams)
        {
            // Validating PO
            if (po.Customer.Membership == null)
            {
                throw new Exception("Member doesn't have membership"); // Should create NoMembershipException for better logging/handling
            }
            if (po.Customer.Membership.MembershipType != MembershipType.Book 
                && po.Customer.Membership.MembershipType != MembershipType.Premium
                && (po.Items?.Any(i => i.Product is BookDTO) ?? false))
            {
                throw new Exception("Member doesn't have book membership, can't purchase book"); // Should create InvalidMembershipException for better logging/handling
            }
            if (po.Customer.Membership.MembershipType != MembershipType.Video 
                && po.Customer.Membership.MembershipType != MembershipType.Premium
                && (po.Items?.Any(i => i.Product is VideoDTO) ?? false))
            {
                throw new Exception("Member doesn't have video membership, can't purchase video"); // Should create InvalidMembershipException for better logging/handling
            }

            // Creating PO
            var createdPOID = 999;
            po.Id = createdPOID;

            _observers.ForEach(o => 
            {
                if (po.Id > 0)
                    o.OnNext(po); // PO created successfully, send to optional processors.
                else
                    o.OnError(new Exception("Something wrong")); // PO created fail, signal optional processors to stop.
            });

            // If PO created successfully, go next step, if not, stop
            return createdPOID > 0 ? (NextProcessor?.Process(po) ?? createdPOID) : 0;
        }
    }
}
