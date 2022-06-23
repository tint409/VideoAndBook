using BusinessLayer.MandatoryProcessors;
using BusinessLayer.MandatoryProcessors.Interfaces;
using BusinessLayer.OptionalProcessors;

namespace BusinessLayer
{
    public class POProcessorFactory//: IPOProcessorFactory
    {
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
            var defaultFlow = new MembershipProcessor();
            var poCreationProcessor = new POCreationProcessor();
            poCreationProcessor.Subscribe(new DeliveryCreationProcessor());
            defaultFlow.SetNext(poCreationProcessor);
            return defaultFlow;
        }
    }
}