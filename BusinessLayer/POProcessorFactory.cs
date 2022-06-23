using BusinessLayer.MandatoryProcessors;
using BusinessLayer.MandatoryProcessors.Interfaces;
using VideoAndBook.BusinessLayer.Models;

namespace BusinessLayer
{
    public class POProcessorFactory//: IPOProcessorFactory
    {
        private readonly POProcessor _membershipProcessor;
        private readonly POCreationProcessor _poCreationProcessor;
        private readonly IObserver<PurchaseOrderModel> _deliveryCreationProcessor;

        public POProcessorFactory(POProcessor membershipProcessor, POCreationProcessor poCreationProcessor, IObserver<PurchaseOrderModel> deliveryCreationProcessor)
        {
            _membershipProcessor = membershipProcessor;
            _poCreationProcessor = poCreationProcessor;
            _deliveryCreationProcessor = deliveryCreationProcessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeOfFlow">Type of PO creation flow. Can be an enum or a Func<> to determine which flow to go.</param>
        /// <returns></returns>
        public IPOProcessor CreateProcessor(int typeOfFlow = 0) => typeOfFlow switch
        {
            //some other flow
            //1 => null, 
            //2 => null,
            _ => DefaultFlow()
        };

        private IPOProcessor DefaultFlow()
        {
            var defaultFlow = _membershipProcessor;
            _poCreationProcessor.Subscribe(_deliveryCreationProcessor);
            defaultFlow.SetNext(_poCreationProcessor);
            return defaultFlow;
        }
    }
}