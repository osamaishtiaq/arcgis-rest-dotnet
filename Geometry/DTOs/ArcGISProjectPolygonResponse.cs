using Oisee.ArcGIS.RestClient.DTOs;
using System.Collections.Generic;

namespace Oisee.ArcGIS.RestClient.Geometry.DTOs
{
    class ArcGISProjectPolygonResponse
    {
        public ArcGISProjectPolygonResponse()
        {
            geometries = new List<PolygonGeometry>();
        }

        public List<PolygonGeometry> geometries { get; private set; }
    }
}

