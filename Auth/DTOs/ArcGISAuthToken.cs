using Newtonsoft.Json;

namespace Oisee.ArcGIS.RestClient.Auth.DTOs
{
    public class ArcGISAuthToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expires")]
        public string Expires { get; set; }
    }
}
