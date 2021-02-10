using Oisee.ArcGIS.RestClient.DTOs;

namespace Oisee.ArcGIS.RestClient.Feature.DTOs
{
    public class ArcGISFeaturesLayerQueryResponse
    {
        public string objectIdFieldName { get; set; }
        public string globalIdFieldName { get; set; }
        public string geometryType { get; set; }
        public Spatialreference spatialReference { get; set; }
        public Field[] fields { get; set; }
        public Feature[] features { get; set; }
    }

    public class Spatialreference
    {
        public int wkid { get; set; }
        public int latestWkid { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string alias { get; set; }
        public string type { get; set; }
        public int length { get; set; }
    }

    public class Feature
    {
        public Attributes attributes { get; set; }
        public PolygonGeometry geometry { get; set; }
    }

    public class Attributes
    {
        public string StandID { get; set; }
        public int OBJECTID { get; set; }
        public int ProjectID { get; set; }
    }
}
