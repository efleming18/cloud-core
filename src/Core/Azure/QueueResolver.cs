using Core.Azure.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Core.Azure
{
    public class QueueResolver : IQueueResolver
    {
        private readonly CloudQueueClient _queueClient;
        public QueueResolver(IOptions<AzureStorageSettings> settings)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(settings.Value.ConnectionString);
            _queueClient = storageAccount.CreateCloudQueueClient();
        }

        public CloudQueue GetQueue(string queueName)
        {
            return _queueClient.GetQueueReference(queueName);
        }
    }
}
