using Core.Azure;
using Microsoft.Azure;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace GroceryWeb
{
    public class BootstrapAzure
    {
        private AzureStorageSettings _settings;
        public BootstrapAzure(IOptions<AzureStorageSettings> settings)
        {
            _settings = settings.Value;
        }

        public void CreateKnownAzureQueues()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_settings.AzureConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            foreach (var queueName in AzureQueues.KnownQueues)
            {
                queueClient.GetQueueReference(queueName).CreateIfNotExists();
            }
        }
    }
}
