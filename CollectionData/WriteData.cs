using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionData
{
    abstract class WriteData
    {
        static public void reWriteData(string path, DataTable dt)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
                string text = ";ID\tType\tName\tIsOwned\tIsRetrofited\tIsIgnored\tRemark\n";
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    for(int j=0;j<dt.Columns.Count;j++)
                    {
                        text += dt.Rows[i][j].ToString().Replace('\t', ' ') + "\t";
                    }
                    text += "\n";
                }
                sw.Write(text);
                sw.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
