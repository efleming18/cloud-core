using Core.Azure;
using Core.Azure.Interfaces;
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
            return View();
        }

        public IActionResult AddMessage()
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
