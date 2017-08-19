using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace CollectionData
{
    public abstract class ReadData
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
            dt.Columns.Add("Remark", typeof(String));

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
                    if (str.Length == 0 || str.Substring(0, 1) == ";" || str.Trim() == "") 
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
                            //dr[i] = strArray[i];
                            try
                            {
                                dr[i] = Regex.Replace(strArray[i], "\\\\n", "\t");
                            }
                            catch
                            {
                                dr[i] = "";
                            }
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
    }
}










