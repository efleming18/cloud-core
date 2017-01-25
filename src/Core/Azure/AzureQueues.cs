using System.Collections.Generic;

namespace Core.Azure
{
    public static class AzureQueues
    {
        public static string GroceryList = "grocery-list";
        public static List<string> KnownQueues = new List<string> { GroceryList };
    }
}