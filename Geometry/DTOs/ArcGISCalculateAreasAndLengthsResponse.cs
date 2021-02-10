using System.Collections.Generic;

namespace Oisee.ArcGIS.RestClient.Geometry.DTOs
{

    class ArcGISCalculateAreasAndLengthsResponse
    {
        public ArcGISCalculateAreasAndLengthsResponse()
        {
            areas = new List<decimal>();
            lengths = new List<decimal>();
        }

        public List<decimal> areas { get; private set; }
        public List<decimal> lengths { get; private set; }
    }

    public class ArcGISAreaLengthResponse
    {
        public decimal Area { get; private set; }
        public decimal Length { get; private set; }

        public ArcGISAreaLengthResponse(decimal area, decimal length)
        {
            Area = area;
            Length = length;
        }
    }

}
