using Microsoft.AspNetCore.HttpLogging;

namespace VideoAndBook.ConfigureServices
{
    public static class ConfigureLogging
    {
        public static void ConfigreLog(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpLogging(logging =>
             {
                 logging.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders | HttpLoggingFields.RequestBody;
                 logging.RequestBodyLogLimit = 4096;
                 logging.ResponseBodyLogLimit = 4096;
             });
        }
    }
}
