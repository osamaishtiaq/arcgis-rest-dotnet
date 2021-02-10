using Oisee.ArcGIS.RestClient.Exceptions;
using System.Net.Http;

namespace Oisee.ArcGIS.RestClient.Common
{
    public abstract class ArcGISServiceBase
    {
        protected string host;
        protected string site;
        protected string restServiceEndpoint = "rest/services";
        protected string folder;
        protected string serviceName;
        protected string serviceType;
        protected string responseFormat { get; } = "json";
        private static string acceptHeaders { get; } = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";

        public ArcGISServiceBase(string host, string site = "arcgis")
        {
            this.host = host;
            this.site = site;
        }

        private static HttpClient httpClient;

        protected static HttpClient ArcGISHttpClient
        {
            get
            {
                if (httpClient == null)
                {
                    httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Add("Accept", acceptHeaders);
                }

                return httpClient;
            }
        }

        protected virtual string getSiteEndpoint()
        {
            validateSiteEndpoint();

            return $"https://{host}/{site}";
        }

        private void validateSiteEndpoint()
        {
            if (string.IsNullOrEmpty(host))
                throw new ArcGISInvalidEndpointException($"missing '{nameof(host)}' field");

            if (string.IsNullOrEmpty(site))
                throw new ArcGISInvalidEndpointException($"missing '{nameof(site)}' field");
        }

        protected virtual string getRestServiceEndpoint()
        {
            validateServiceEndpoint();

            var endpoint = $"{getSiteEndpoint()}/{restServiceEndpoint}/{folder}/{serviceName}/{serviceType}";
            return endpoint;
        }

        private void validateServiceEndpoint()
        {
            if (string.IsNullOrEmpty(folder))
                throw new ArcGISInvalidEndpointException($"missing '{nameof(folder)}' field");

            if (string.IsNullOrEmpty(serviceName))
                throw new ArcGISInvalidEndpointException($"missing '{nameof(serviceName)}' field");

            if (string.IsNullOrEmpty(serviceType))
                throw new ArcGISInvalidEndpointException($"missing '{nameof(serviceType)}' field");
        }
    }
}
