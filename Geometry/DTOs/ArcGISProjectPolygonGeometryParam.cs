using Oisee.ArcGIS.RestClient.DTOs;
using Oisee.ArcGIS.RestClient.Enums;

namespace Oisee.ArcGIS.RestClient.Geometry.DTOs
{
    class ArcGISProjectPolygonGeometryParam
    {
        public string geometryType { get; private set; }
        public PolygonGeometry[] geometries { get; private set; }

        public ArcGISProjectPolygonGeometryParam(PolygonGeometry[] geometries)
        {
            this.geometries = geometries;
            geometryType = EsriGeometryType.esriGeometryPolygon.ToString();
        }
    }

}