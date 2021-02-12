using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Oisee.ArcGIS.RestClient.Utils
{
    public class ArcGISEncodedContent : Dictionary<string,string>
    {
        public new void Add(string key, string value)
        {
            base.Add(key, value);
        }

        public StringContent ToStringUrlEncodedContent()
        {
            List<string> encodedItems = new List<string>();
            foreach (KeyValuePair<string,string> i in this)
            {
                encodedItems.Add(WebUtility.UrlEncode(i.Key) + "=" + WebUtility.UrlEncode(i.Value));
            }
            return new StringContent(string.Join("&", encodedItems), null, "application/x-www-form-urlencoded");
        }
    }
}
