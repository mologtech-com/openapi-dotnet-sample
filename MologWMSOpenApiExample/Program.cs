using MologWMSOpenApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace MologWMSOpenApiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var appKey = "0881562077607899";
            var appSecret = "qHOyaytGjOqduSZnZDymxhPWgezyiMYr";
            var client = new MologWMSOpenApiClient(appKey, appSecret);
            await client.CreateToken("administrator", "ft@123");
            await client.RefreshToken();

            var inventoryList = await client.Inventory.GetByTime(1, 10);
        }
    }
}
