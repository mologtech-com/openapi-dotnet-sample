using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MologWMSOpenApi.Internal
{
    public class MologWMSOpenApiCrosscheck
    {
        private MologWMSOpenApiClient mologWMSOpenApiClient;

        public MologWMSOpenApiCrosscheck(MologWMSOpenApiClient mologWMSOpenApiClient)
        {
            this.mologWMSOpenApiClient = mologWMSOpenApiClient;
        }

        public async Task<object> SelectASN(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Get("/crosscheck/asn",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }

        public async Task<object> SelectDSO(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Get("/crosscheck/dso",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }
    }
}
