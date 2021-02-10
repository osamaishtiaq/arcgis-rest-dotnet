using System;

namespace Oisee.ArcGIS.RestClient.Exceptions
{
    class ArcGISUnexpectedResponseException : Exception
    {
        public ArcGISUnexpectedResponseException(string message) : base(message)
        {
        }

        public ArcGISUnexpectedResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
