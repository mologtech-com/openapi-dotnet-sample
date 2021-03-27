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

        public MologWMSOpenApiClient(string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;

            this.Inventory = new MologWMSOpenApiInventory(this);
        }

        public async Task CreateToken(string usernameOrEmail, string password)
        {
            var contents = await ApiRunner.Post("/system/token",
                this.appKey,
                this.appSecret,
                null,
                new Dictionary<string, string>() {
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
                new Dictionary<string, string>() {
                    { "REFRESH_TOKEN", this.tokenModel.RefreshToken }
                }
            );
            var refreshResult = JsonConvert.DeserializeObject<RefreshTokenModel>(contents);
            this.tokenModel.AccessToken = refreshResult.AccessToken;
            this.tokenModel.AccessTokenExpire = refreshResult.AccessTokenExpire;
        }

        public CreateTokenModel GetToken()
        {
            return this.tokenModel;
        }

    }
}
