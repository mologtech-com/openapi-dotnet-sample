using MologWMSOpenApi.Internal;
using MologWMSOpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MologWMSOpenApi
{
    public class MologWMSOpenApiClient
    {
        internal string appKey;
        internal string appSecret;
        internal CreateTokenModel tokenModel = null;

        public MologWMSOpenApiInventory Inventory { get; }
        public MologWMSOpenApiPicked Picked { get; }
        public MologWMSOpenApiPacked Packed { get; }
        public MologWMSOpenApiShipped Shipped { get; }
        public MologWMSOpenApiGR GR { get; }
        public MologWMSOpenApiCrosscheck Crosscheck { get; }

        public MologWMSOpenApiASN ASN { get; }
        public MologWMSOpenApiPSO PSO { get; }
        public MologWMSOpenApiDSO DSO { get; }
        public MologWMSOpenApiSKU SKU { get; }
        public MologWMSOpenApiPartner Partner { get; }

        public MologWMSOpenApiClient(string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

            this.Inventory = new MologWMSOpenApiInventory(this);
            this.Picked = new MologWMSOpenApiPicked(this);
            this.Packed = new MologWMSOpenApiPacked(this);
            this.Shipped = new MologWMSOpenApiShipped(this);
            this.GR = new MologWMSOpenApiGR(this);
            this.Crosscheck = new MologWMSOpenApiCrosscheck(this);
            this.ASN = new MologWMSOpenApiASN(this);
            this.PSO = new MologWMSOpenApiPSO(this);
            this.DSO = new MologWMSOpenApiDSO(this);
            this.SKU = new MologWMSOpenApiSKU(this);
            this.Partner = new MologWMSOpenApiPartner(this);
        }

        public async Task CreateToken(string usernameOrEmail, string password)
        {
            var contents = await ApiRunner.Post("/system/token",
                this.appKey,
                this.appSecret,
                null,
                new Dictionary<string, object>() {
                    { "USERNAME", Util.EncryptString(usernameOrEmail, this.appSecret) },
                    { "PASSWORD", Util.EncryptString(password, this.appSecret) }
                }
            );
            this.tokenModel = JsonConvert.DeserializeObject<CreateTokenModel>(contents);
        }

        public async Task RefreshToken()
        {
            var contents = await ApiRunner.Post("/system/refresh_token",
                this.appKey,
                this.appSecret,
                null,
                new Dictionary<string, object>() {
                    { "REFRESH_TOKEN", this.tokenModel.RefreshToken }
                }
            );
            var refreshResult = JsonConvert.DeserializeObject<RefreshTokenModel>(contents);
            this.tokenModel.AccessToken = refreshResult.AccessToken;
            this.tokenModel.AccessTokenExpire = refreshResult.AccessTokenExpire;
        }

        public async Task<object> DeleteToken()
        {
            var contents = await ApiRunner.Delete("/system/token",
                this.appKey,
                this.appSecret,
                this.tokenModel.AccessToken,
                new Dictionary<string, object>() {
                   
                }
            );
            this.tokenModel = null;
            return JsonConvert.DeserializeObject(contents);
        }

        public CreateTokenModel GetToken()
        {
            return this.tokenModel;
        }

    }
}
