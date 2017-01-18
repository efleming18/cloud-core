using Core.Azure;
using Core.Azure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage.Queue;

namespace GroceryWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueueResolver _queueResolver;
        public HomeController(IOptions<AzureStorageSettings> settings, IQueueResolver queueResolver)
        {
            _queueResolver = queueResolver;
            var what = settings.Value.AzureConnectionString;
        }

        public IActionResult Index()
        {
            var testQueue = _queueResolver.GetQueue(AzureQueues.FirstTestQueueName);
            testQueue.AddMessage(new CloudQueueMessage("message"));
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
