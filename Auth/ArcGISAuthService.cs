using Oisee.ArcGIS.RestClient.Auth.DTOs;
using Oisee.ArcGIS.RestClient.Common;
using Oisee.ArcGIS.RestClient.Exceptions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Oisee.ArcGIS.RestClient.Auth
{
    public class ArcGISAuthService : ArcGISServiceBase
    {
        private string username;
        private string password;
        private const string referer = "https://machine.domain.com";
        
        public ArcGISAuthService(string host, string username, string password, string site = "arcgis") 
            : base(host, site)
        {
            this.restServiceEndpoint = "tokens/generateToken";
            this.username = username;
            this.password = password;
        }

        public async Task<ArcGISAuthToken> GetToken()
        {
            try
            {
                string reqUrl = getAuthRequestUrl();

                HttpResponseMessage resp = await ArcGISHttpClient.PostAsync(reqUrl, null);

                string str = await resp.Content.ReadAsStringAsync();
                
                if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new ArcGISAuthException($"Unsuccessfull " +
                        $"Username: {username}, StatusCode: {resp.StatusCode}, " +
                        $"Response Returned: {str}");
                }

                var model = JsonConvert.DeserializeObject<ArcGISAuthToken>(str);
                return model;
            }
            catch (System.Exception ex)
            {
                throw new ArcGISAuthException($"{ex.Message}", ex);
            }
        }

        private string getAuthRequestUrl()
        {
            string serviceEndpoint = this.getSiteEndpoint();

            string requestUrl = $"{serviceEndpoint}/{restServiceEndpoint}?f={responseFormat}" +
            $"&referer={referer}" +
            $"&Username={username}" +
            $"&Password={password}";
            
            return requestUrl;
        }

    }
}
