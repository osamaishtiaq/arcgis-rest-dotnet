using System;

namespace Oisee.ArcGIS.RestClient.Exceptions
{
    class ArcGISInvalidEndpointException : Exception
    {
        public ArcGISInvalidEndpointException(string message) 
            : base(message)
        {
        }
    }
}
