using System;
using System.Net.Http;

namespace Oisee.ArcGIS.RestClient.Exceptions
{
    class ArcGISInvalidResponseException : Exception
    {

        public ArcGISInvalidResponseException(string message) : base(message)
        {
        }
    }
}
