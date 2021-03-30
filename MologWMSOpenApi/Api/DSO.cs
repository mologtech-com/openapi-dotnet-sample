using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MologWMSOpenApi.Internal
{
    public class MologWMSOpenApiDSO
    {
        private MologWMSOpenApiClient mologWMSOpenApiClient;

        public MologWMSOpenApiDSO(MologWMSOpenApiClient mologWMSOpenApiClient)
        {
            this.mologWMSOpenApiClient = mologWMSOpenApiClient;
        }

        public async Task<object> Create(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Post("/dso/dso",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }

        public async Task<object> UpdateConsigneeShipTo(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Put("/dso/con_st",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }

        public async Task<object> UpdateInvoice(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Put("/dso/invoice",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }

        public async Task<object> Cancel(Dictionary<string, object> dict)
        {
            var contents = await ApiRunner.Put("/dso/cancel",
                this.mologWMSOpenApiClient.appKey,
                this.mologWMSOpenApiClient.appSecret,
                this.mologWMSOpenApiClient.tokenModel.AccessToken,
                dict
            );
            return JsonConvert.DeserializeObject(contents);
        }

    }
}
