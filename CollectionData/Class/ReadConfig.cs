using System;
using System.Data;
using System.IO;
using System.Text;


namespace CollectionData
{
    public abstract class ReadConfig
    {
        public static DataTable readData(string path)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Type", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("IsOwned", typeof(Int32));
            dt.Columns.Add("IsRetrofited", typeof(Int32));
            dt.Columns.Add("IsIgnored", typeof(Int32));

            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                string str = sr.ReadLine();
                while (str != null)
                {
                    if (str.Length == 0 || str.Substring(0, 1) == ";")
                    {
                        str = sr.ReadLine();
                        continue;
                    }
                    try
                    {
                        string[] strArray = str.Split('\t');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dr[i] = strArray[i];
                        }
                        dt.Rows.Add(dr);
                        str = sr.ReadLine();
                    }
                    catch
                    {
                        str = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static bool readConfig(string path)
        {
            bool flag = true;
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                string str = sr.ReadLine();
                while (str != null)
                {
                    if (str.Length == 0 || str.Substring(0, 1) == "#" || (str.Substring(0, 1) == "[" && str.Substring(str.Length - 1, 1) == "]"))
                    {
                        str = sr.ReadLine();
                        continue;
                    }
                    string[] strArray = str.Split('=');
                    try
                    {
                        if (strArray[0].ToString() == "ShowRetrofitedFlag")
                        {
                            if (strArray[1].ToString() == "false")
                            {
                                flag = false;
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                        str = sr.ReadLine();
                    }
                    catch
                    {
                        str = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }
    }
}










