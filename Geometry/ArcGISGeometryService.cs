using Oisee.ArcGIS.RestClient.Common;
using Oisee.ArcGIS.RestClient.DTOs;
using Oisee.ArcGIS.RestClient.Enums;
using Oisee.ArcGIS.RestClient.Exceptions;
using Oisee.ArcGIS.RestClient.Geometry.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Oisee.ArcGIS.RestClient.Geometry
{
    public class ArcGISGeometryService : ArcGISServiceBase
    {
        public ArcGISGeometryService(string host, string site = "arcgis") : base(host, site)
        {
            this.folder = "Utilities";
            this.serviceName = "Geometry";
            this.serviceType = "GeometryServer";
        }

        public async Task<PolygonGeometry> ProjectPolygon(string token, string inSR, string outSR, PolygonGeometry geometry)
        {
            var queryUrl = $"{getRestServiceEndpoint()}/project";
            var payLoadModel = new ArcGISProjectPolygonGeometryParam(new PolygonGeometry[] { geometry });

            var encodedContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("f",responseFormat),
                new KeyValuePair<string, string>("token",token),
                new KeyValuePair<string, string>("inSR",inSR),
                new KeyValuePair<string, string>("outSR",outSR),
                new KeyValuePair<string, string>("geometries", JsonConvert.SerializeObject(payLoadModel).TrimJsonRequest())
            });

            var resp = await ArcGISHttpClient.PostAsync(queryUrl, encodedContent);

            var respStr = await resp.Content.ReadAsStringAsync();

            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new ArcGISInvalidResponseException($"Unsuccessfull. \n" +
                    $"Response Code: {resp.StatusCode}\n" +
                    $"Response: {respStr}" +
                    $"Query String: {queryUrl}");
            }

            var model = JsonConvert.DeserializeObject<ArcGISProjectPolygonResponse>(respStr);

            return model.geometries.FirstOrDefault();
        }

        public async Task<ArcGISAreaLengthResponse> CalculateAreasAndLengths(string token, string sr,
            EsriGeometryCalcType calculationType, EsriAreaUnit areaUnit, PolygonGeometry geometry, string lengthUnit = "")
        {
            string queryUrl = $"{getRestServiceEndpoint()}/areasAndLengths";
            var areaUnitParam = new ArcGISCalculateAreasAndLengthAreaParam(areaUnit);

            PolygonGeometry[] polygonPayload = { geometry };

            var encodedContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("f",responseFormat),
                    new KeyValuePair<string, string>("token",token),
                    new KeyValuePair<string, string>("sr", sr),
                    new KeyValuePair<string, string>("lengthUnit",lengthUnit),
                    new KeyValuePair<string, string>("calculationType",calculationType.ToString()),
                    new KeyValuePair<string, string>("areaUnit", JsonConvert.SerializeObject(areaUnitParam).TrimJsonRequest()),
                    new KeyValuePair<string, string>("polygons", JsonConvert.SerializeObject(polygonPayload).TrimJsonRequest())
                });

            var resp = await ArcGISHttpClient.PostAsync(queryUrl, encodedContent);

            var respStr = await resp.Content.ReadAsStringAsync();

            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new ArcGISInvalidResponseException($"Unsuccessfull. \n" +
                    $"Response Code: {resp.StatusCode}\n" +
                    $"Response: {respStr}" +
                    $"Query String: {queryUrl}");
            }

            var model = JsonConvert.DeserializeObject<ArcGISCalculateAreasAndLengthsResponse>(respStr);

            if (model.areas.Count > 1 || model.lengths.Count > 1)
            {
                throw new ArcGISUnexpectedResponseException("Returned response count greater than 1 or equal to 0");
            }

            return new ArcGISAreaLengthResponse(model.areas.FirstOrDefault(), model.lengths.FirstOrDefault());
        }
    }
}
