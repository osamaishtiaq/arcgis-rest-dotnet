using System;

namespace Oisee.ArcGIS.RestClient.Exceptions
{
    class ArcGISInvalidParameterException : Exception
    {
        public ArcGISInvalidParameterException(string message) : base(message)
        {
        }

        public ArcGISInvalidParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
