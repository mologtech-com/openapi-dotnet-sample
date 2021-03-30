using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MologWMSOpenApi.Internal
{
    public class MologWMSOpenApiPartner
    {
        private MologWMSOpenApiClient mologWMSOpenApiClient;

        public MologWMSOpenApiPartner(MologWMSOpenApiClient mologWMSOpenApiClient)
        {
            this.mologWMSOpenApiClient = mologWMSOpenApiClient;
        }

        public async Task<object> CreateUpdate(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Post("/partner/partner",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }

    }
}
