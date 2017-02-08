using Core.Azure;
using GroceryWeb.Models;
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

        public IActionResult AddMessage(AzureMessage message)
        {
            var groceryListQueue = _queueResolver.GetQueue(AzureQueues.GroceryList);
            groceryListQueue.AddMessage(new CloudQueueMessage(message.AzureMessageText));
            return View("Index");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
