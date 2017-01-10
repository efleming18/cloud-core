using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
