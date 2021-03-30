using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MologWMSOpenApi
{
    public class MologWMSOpenApiException : Exception
    {
        public string ERROR_CODE { get; }
        public string ERROR_MESSAGE { get; }

        public MologWMSOpenApiException(string rawStr, string errorCode, string errorMsg)
            : base(errorMsg ?? rawStr)
        {
            this.ERROR_CODE = errorCode;
            this.ERROR_MESSAGE = errorMsg;
        }

        public static MologWMSOpenApiException Create(string jsonString)
        {
            dynamic jsonResponse = JsonConvert.DeserializeObject(jsonString);
            var errorCode = jsonResponse.ERROR_CODE;
            var errorMsg = jsonResponse.ERROR_MESSAGE;
            if (errorCode != null && errorMsg != null)
            {
                return new MologWMSOpenApiException(jsonString, errorCode.ToString(), errorMsg.ToString());
            } else
            {
                return new MologWMSOpenApiException(jsonString, null, null);
            }
        }
    }
}
