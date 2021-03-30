using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace MologWMSOpenApi.Models
{

    public class Ts2DateConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var a = (DateTimeOffset) value;
            writer.WriteValue(a.ToUnixTimeMilliseconds());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
           // User user = new User();
           // user.UserName = (string)reader.Value;

            return DateTimeOffset.FromUnixTimeMilliseconds((long)reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }

    public class RefreshTokenModel {
        [JsonProperty("ACCESS_TOKEN", Required = Required.Always)]
        public string AccessToken { get; set; }

        [JsonProperty("ACCESS_TOKEN_EXPIRE", Required = Required.Always)]
        [JsonConverter(typeof(Ts2DateConverter))]
        public DateTimeOffset AccessTokenExpire { get; set; }
    }


    public class CreateTokenModel
    {
        [JsonProperty("ACCESS_TOKEN", Required = Required.Always)]
        public string AccessToken { get; set; }

        [JsonProperty("ACCESS_TOKEN_EXPIRE", Required = Required.Always)]
        [JsonConverter(typeof(Ts2DateConverter))]
        public DateTimeOffset AccessTokenExpire { get; set; }

        [JsonProperty("REFRESH_TOKEN", Required = Required.Always)]
        public string RefreshToken { get; set; }

        [JsonProperty("REFRESH_TOKEN_EXPIRE", Required = Required.Always)]
        [JsonConverter(typeof(Ts2DateConverter))]
        public DateTimeOffset RefreshTokenExpire { get; set; }

        [JsonProperty("USER", Required = Required.Always)]
        public CreateTokenUserModel User { get; set; }
    }

    public class CreateTokenUserModel
    {
        [JsonProperty("ID", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("USERNAME", Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty("FIRST_NAME", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty("LAST_NAME", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty("EMAIL", Required = Required.Always)]
        public string Email { get; set; }
    }
}
