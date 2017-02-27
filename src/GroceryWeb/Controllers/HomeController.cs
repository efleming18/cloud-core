using Core.Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Queue;

namespace GroceryWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQueueResolver _queueResolver;

        public HomeController(IQueueResolver queueResolver)
        {
            _queueResolver = queueResolver;
        }

        public IActionResult Index()
        {
            var groceryListQueue = _queueResolver.GetQueue(AzureQueues.GroceryList);
            groceryListQueue.AddMessage(new CloudQueueMessage("Hello from DevIQ!"));
            return View();
        }
    }
}
