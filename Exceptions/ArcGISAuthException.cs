using System;
using System.Runtime.Serialization;

namespace Oisee.ArcGIS.RestClient.Exceptions
{
    class ArcGISAuthException : Exception
    {
        public ArcGISAuthException()
        {
        }

        public ArcGISAuthException(string message) : base(message)
        {
        }

        public ArcGISAuthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArcGISAuthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
