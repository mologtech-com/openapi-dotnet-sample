using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MologWMSOpenApi.Internal
{
    public class MologWMSOpenApiGR
    {
        private MologWMSOpenApiClient mologWMSOpenApiClient;

        public MologWMSOpenApiGR(MologWMSOpenApiClient mologWMSOpenApiClient)
        {
            this.mologWMSOpenApiClient = mologWMSOpenApiClient;
        }

        public async Task<object> SelectByTime(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Get("/gr/by_time",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }

        public async Task<object> SelectByJob(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Get("/gr/by_job",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }
    }
}
