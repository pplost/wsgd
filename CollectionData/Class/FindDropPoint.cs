using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace CollectionData
{
    class FindDropPoint
    {

        private string getResponse(string url, string dataStr, string referer)
        {
            string str = "";
            CookieContainer cc = new CookieContainer();
            HttpWebRequest hwreq = (HttpWebRequest)WebRequest.Create(url);
            hwreq.Method = "POST";
            hwreq.Host = "js.ntwikis.com";
            hwreq.KeepAlive = true;
            hwreq.ContentLength = dataStr.Length;
            hwreq.Accept = "*/*";
            hwreq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.75 Safari/537.36";
            hwreq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            hwreq.Referer = referer;
            hwreq.Headers.Add("X-Requested-With: XMLHttpRequest");
            hwreq.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.8");
            //hwreq.Headers.Add("Accept-Encoding: gzip, deflate");
            hwreq.Headers.Add("Origin: http://js.ntwikis.com");
            hwreq.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            hwreq.CookieContainer = cc;
            StreamWriter sw = new StreamWriter(hwreq.GetRequestStream(), Encoding.ASCII);
            sw.Write(dataStr);
            sw.Flush();
            HttpWebResponse hwres = (HttpWebResponse)hwreq.GetResponse();
            //string encoding = hwres.ContentEncoding;
            //if (encoding == null || encoding.Length < 1)
            //{
            //    encoding = "UTF-8"; //默认编码  
            //}
            StreamReader sr = new StreamReader(hwres.GetResponseStream());
            str = sr.ReadToEnd();
            //str = str.Replace("\0", "");
            sr.Close();
            hwres.Close();
            return str;
        }

        private List<string> getDropArea(string id)
        {
            string url = "http://js.ntwikis.com/rest/cancollezh/charactordetail";
            string dataStr = "detailid=" + id + "&language=zh";
            string referer = "http://js.ntwikis.com/jsp/apps/cancollezh/charactors/detail.jsp?detailid=" + id;
            string response = getResponse(url, dataStr, referer);
            List<string> dropAreas = new List<string>();
            Regex reg = new Regex(@"<a href=\\""/jsp/apps/cancollezh/maps/detailnew\.jsp\?detailid=.*?>(.*?)<\\/a>");
            MatchCollection dataSet = reg.Matches(response);
            foreach (Match data in dataSet)
            {
                dropAreas.Add(data.Groups[1].Value);
            }
            return dropAreas;
        }

        private string getDropPoint(string area, string id)
        {
            string url = "http://js.ntwikis.com/rest/cancollezh/mapdetailnew";
            string dataStr = "detailid=" + area + "&adviser=0&zhandi=&uid=0";
            string referer = "http://js.ntwikis.com/jsp/apps/cancollezh/maps/detailnew.jsp?detailid=" + area + "&boldid=" + id;
            string response = getResponse(url, dataStr, referer);
            string points = area + ":";
            List<string> pt = new List<string>();
            JObject jo = (JObject)JsonConvert.DeserializeObject(response);
            foreach (JProperty jp in jo["DROPINFOS"])
            {
                foreach (JObject jo2 in jo["DROPINFOS"][jp.Name])
                {
                    if (jo2["CHARID"].ToString() == id)
                    {
                        pt.Add(jp.Name);
                        break;
                    }
                }
            }
            pt.Sort();
            foreach (string x in pt)
            {
                points += " " + x + ",";
            }
            return points;
        }

        public string DropPoints(string id)
        {
            string dropPoints = "";
            List<string> areas = getDropArea(id);
            if (areas.Count <= 0)
            {
                return "";
            }
            foreach (string area in areas)
            {
                //排除过期的活动图
                if(area.Length>4)
                {
                    Regex reg = new Regex(@"(\d+)_([a-zA-Z]+)_");
                    Match m = reg.Match(area);
                    if (m.Success)
                    {
                        string dateM = m.Groups[1].Value + m.Groups[2].Value;
                        int dt = int.Parse(Convert.ToDateTime(dateM).ToString("yyyyMM"));
                        int dtNow = int.Parse(DateTime.Now.AddDays(-15).ToString("yyyyMM"));
                        if(dtNow>dt)
                        {
                            continue;
                        }
                    }
                }
                Thread.Sleep(1500);
                string tmpStr = getDropPoint(area, id);
                dropPoints += tmpStr.Substring(0, tmpStr.Length - 1) + ";\n";
            }
            return dropPoints;
        }
    }
}
