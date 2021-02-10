namespace Oisee.ArcGIS.RestClient
{
    public static class JsonExtensions
    {
        public static string TrimJsonRequest(this string str)
        {
            return str.Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\t", string.Empty);
        }
    }
}
