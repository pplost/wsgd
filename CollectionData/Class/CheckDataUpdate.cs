using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace CollectionData
{
    class CheckDataUpdate
    {
        private string str;
        private DataTable dt = new DataTable();

        public CheckDataUpdate()
        {
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Type", typeof(String));
            dt.Columns.Add("Name", typeof(String));
        }
        public string getResponse()
        {
            string url = "http://js.ntwikis.com/rest/cancollezh/charactorquery";
            string dataStr = "ismobile=0";
            CookieContainer cc = new CookieContainer();
            HttpWebRequest hwreq = (HttpWebRequest)WebRequest.Create(url);
            hwreq.Method = "POST";
            hwreq.Host = "js.ntwikis.com";
            hwreq.KeepAlive = true;
            hwreq.ContentLength = dataStr.Length;
            hwreq.Accept = "*/*";
            hwreq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.75 Safari/537.36";
            hwreq.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            hwreq.Referer = "http://js.ntwikis.com/";
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
        public void getDataTable()
        {
            Regex reg = new Regex(@"<a href=""/jsp/apps/cancollezh/charactors/detail.jsp\?detailid=(\d+).*?【(.+?)】(.+?)</div>");
            MatchCollection dataSet = reg.Matches(str);
            foreach (Match data in dataSet)
            {
                DataRow dr = dt.NewRow();
                for (int i = 1; i < data.Groups.Count; i++)
                {
                    dr[i - 1] = data.Groups[i].Value;
                }
                dt.Rows.Add(dr);
            }
            //WriteConfig.reWriteData("test.txt", dt);
        }
        public bool compareDiff(ref DataTable oldTable)
        {
            bool resultFlag = false;
            if (dt.Rows.Count == oldTable.Rows.Count)
            {
                return resultFlag;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool flag = false;
                int j = 0, l = i;
                while (j < oldTable.Rows.Count)
                {
                    if (l >= oldTable.Rows.Count)
                    {
                        l = 0;
                    }
                    if (dt.Rows[i][0].ToString() == oldTable.Rows[l][0].ToString())
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        l++;
                    }
                    j++;
                }
                //未找到，则为新行，插入原表
                if (!flag)
                {
                    resultFlag = true;
                    DataRow dr = oldTable.NewRow();
                    dr[0] = dt.Rows[i][0];
                    dr[1] = dt.Rows[i][1];
                    dr[2] = dt.Rows[i][2];
                    dr[3] = 0;
                    if (dr[0].ToString().Trim().Length >= 4 && dr[0].ToString().Substring(0, 1) == "1")
                    {
                        dr[4] = 1;
                    }
                    else
                    {
                        dr[4] = 0;
                    }
                    if ((dr[0].ToString().Trim().Length >= 4 && dr[0].ToString().Substring(0, 1) == "8") || (dr[2].ToString().Trim() == "戈本"))
                    {
                        dr[5] = 1;
                    }
                    else
                    {
                        dr[5] = 0;
                    }
                    dr[6] = "";
                    oldTable.Rows.Add(dr);
                }
            }
            //有更新，则重新排序,并重写配置文件
            if (resultFlag)
            {
                DataView dv = new DataView(oldTable);
                dv.Sort = "ID asc";
                oldTable = dv.ToTable();
                WriteData.reWriteData("Data.wsgd", oldTable);
            }
            return resultFlag;
        }
    }
}




