using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


namespace CollectionData
{
    class CheckUpdate
    {
        public string getResponse()
        {
            try
            {
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create("https://fgo-archive.github.io/VersionList/wsgVersion.txt");
                hwr.Method = "GET";
                hwr.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse hwrs = (HttpWebResponse)hwr.GetResponse();
                Stream streams = hwrs.GetResponseStream();
                StreamReader sr = new StreamReader(streams, Encoding.UTF8);
                string str = sr.ReadToEnd();
                sr.Close();
                streams.Close();
                return str;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
