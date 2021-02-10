using Oisee.ArcGIS.RestClient.Common;
using Oisee.ArcGIS.RestClient.Exceptions;
using Oisee.ArcGIS.RestClient.Feature.DTOs;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Oisee.ArcGIS.RestClient.Feature
{
    public class ArcGISFeatureLayerService : ArcGISServiceBase
    {
        public ArcGISFeatureLayerService(string host, string folder, string serviceName, string site="arcgis") : base(host, site)
        {
            this.folder = folder;
            this.serviceName = serviceName;
            this.serviceType = "FeatureServer";
        }

        public async Task<ArcGISFeaturesLayerQueryResponse> QueryFeatureLayer(string token, int layerId, string[] outFields, string whereClause = "1=1")
        {
            var queryUrl = $"{this.getRestServiceEndpoint()}/{layerId}/query" +
                $"?token={token}" +
                $"&f={responseFormat}" +
                $"&outFields={string.Join(",", outFields)}" +
                $"&where={whereClause}";

            var resp = await ArcGISHttpClient.PostAsync(queryUrl, null);

            var respStr = await resp.Content.ReadAsStringAsync();

            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new ArcGISInvalidResponseException($"Unsuccessfull. \n" +
                    $"Response Code: {resp.StatusCode}\n" +
                    $"Response: {respStr}" +
                    $"Query String: {queryUrl}");
            }

            var model = JsonConvert.DeserializeObject<ArcGISFeaturesLayerQueryResponse>(respStr);
            return model;

        }
    }
}