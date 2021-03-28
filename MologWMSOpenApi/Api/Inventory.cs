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

        public async Task<object> Select(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Get("/inventory/list",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }
    }
}
