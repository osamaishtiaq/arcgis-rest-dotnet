using Oisee.ArcGIS.RestClient.Enums;
namespace Oisee.ArcGIS.RestClient.Geometry.DTOs
{
    class ArcGISCalculateAreasAndLengthAreaParam
    {
        public string areaUnit { get; private set; }

        public ArcGISCalculateAreasAndLengthAreaParam(EsriAreaUnit areaUnit)
        {
            this.areaUnit = areaUnit.ToString();
        }
    }
}
