using BusinessLayer.MandatoryProcessors.Interfaces;
using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer.MandatoryProcessors
{
    internal class MembershipProcessor : POProcessor, IPOProcessor
    {
        internal override int Process(PurchaseOrderDTO po, params object[]? additionalParams)
        {
            var isActivated = true;

            var purchasedMembership = po.Items?.FirstOrDefault(i => i.Product is MembershipDTO);
            if (purchasedMembership != null)
            {
                // Activating membership
                // ...
                po.Customer.Membership = new MembershipDTO
                {
                    MembershipType = ((MembershipDTO)purchasedMembership.Product).MembershipType
                };
            }

            // If activate membership successfully, go next step, if not, stop
            return isActivated ? (NextProcessor?.Process(po) ?? 0) : 0;
        }
    }
}
