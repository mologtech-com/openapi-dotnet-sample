using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MologWMSOpenApi.Internal
{
    public class MologWMSOpenApiInventory
    {
        private MologWMSOpenApiClient mologWMSOpenApiClient;

        public MologWMSOpenApiInventory(MologWMSOpenApiClient mologWMSOpenApiClient)
        {
            this.mologWMSOpenApiClient = mologWMSOpenApiClient;
        }

        public async Task<object> GetByTime(int page, int size)
        {
            var contents = await ApiRunner.Get("/inventory/list",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                new Dictionary<string, string>() {
                    { "PAGE", page.ToString() },
                    { "SIZE", size.ToString() }
                }
            );
            return JsonConvert.DeserializeObject(contents);
        }
    }
}
