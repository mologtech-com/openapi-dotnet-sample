using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MologWMSOpenApi.Internal
{
    public class MologWMSOpenApiASN
    {
        private MologWMSOpenApiClient mologWMSOpenApiClient;

        public MologWMSOpenApiASN(MologWMSOpenApiClient mologWMSOpenApiClient)
        {
            this.mologWMSOpenApiClient = mologWMSOpenApiClient;
        }

        public async Task<object> Create(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Post("/asn/asn",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }

    }
}
