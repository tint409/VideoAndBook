using BusinessLayer;
using BusinessLayer.OptionalProcessors;
using VideoAndBook.BusinessLayer.Models;

namespace VideoAndBook.ConfigureServices
{
    public static class AddServices
    {
        public static void AddPurchaseOrderServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<POProcessorFactory, POProcessorFactory>();
            serviceCollection.AddScoped<IObserver<PurchaseOrderDTO>, DeliveryCreationProcessor>();
        }
    }
}
