using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using MologWMSOpenApi.Models;

namespace MologWMSOpenApi.Internal
{
    public class ApiRunner
    {
        private static string enpoint = "https://localhost:7900/rest";

        private static string HashRequest(string path, string appKey, string appSecretKey, string ts)
        {
            var signString = $"{path}APP_KEY{appKey}TIMESTAMP{ts}";
            HMACSHA256 sha256Hash = new HMACSHA256(Encoding.UTF8.GetBytes(appSecretKey));
            byte[] hashmessage = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(signString));
            return HexStringFromBytes(hashmessage).ToUpper();
        }

        private static string HexStringFromBytes(byte[] hashmessage)
        {
            var sb = new StringBuilder();
            foreach (byte b in hashmessage)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        private static (HttpClient, string) GetHttpClientUrl(string endpoint, string path, string appKey, string appSecret, string accessToken, Dictionary<string, string> queryDict)
        {
            if (queryDict == null)
            {
                queryDict = new Dictionary<string, string>();
            }
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };


            queryDict["APP_KEY"] = appKey;
            queryDict["TIMESTAMP"] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            queryDict["SIGN"] = HashRequest(path, queryDict["APP_KEY"], appSecret, queryDict["TIMESTAMP"]);
            if (accessToken != null)
            {
                queryDict["ACCESS_TOKEN"] = accessToken;
            }

            return (new HttpClient(handler), BuildUrlQuery(endpoint + path, queryDict));
        }

        private static string BuildUrlQuery(string url, Dictionary<string, string> dict)
        {
            var builder = new UriBuilder(url);
            if (builder.Port == 443)
            {
                builder.Port = -1;
            }
            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach (var kvp in dict)
            {
                query.Add(kvp.Key.ToString(), kvp.Value.ToString());
            }
            builder.Query = query.ToString();
            Console.WriteLine(builder.ToString());
            return builder.ToString();
        }

        public static async Task<string> Get(string path, string appKey, string appSecret, string accessToken, Dictionary<string, string> dict)
        {
            var (client, url) = GetHttpClientUrl(ApiRunner.enpoint, path, appKey, appSecret, accessToken, dict);
            var response = await client.GetAsync(url);
            var contents = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw MologWMSOpenApiException.Create(contents);
            }
            return contents;
        }

        public static async Task<string> Post(string path, string appKey, string appSecret, string accessToken, Dictionary<string, string> dict)
        {
            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            var httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var (client, url) = GetHttpClientUrl(ApiRunner.enpoint, path, appKey, appSecret, accessToken, null);
            var response = await client.PostAsync(url, httpContent);
            var contents = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw MologWMSOpenApiException.Create(contents);
            }
            return contents;
        }

        

    }
}
