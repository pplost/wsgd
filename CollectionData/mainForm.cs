using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CollectionData
{
    public partial class mainForm : Form
    {
        //全局变量
        DataTable dt;
        DataView dv;
        string ownedFilterStr = "IsIgnored = 0";
        string retrofitedFilterStr = " and IsRetrofited = 0";
        string searchFilterStr = "";
        string tmpUrl = "";
        string configPath = Application.StartupPath + "\\config.ini";
        string dataPath = "Data.wsgd";
        string sizable = "0";
        string checkUpdateFlag = "1";
        public mainForm()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            initBrowser();
            initDataGrid();
        }

        //初始化浏览器
        public void initBrowser()
        {
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Navigate("http://js.ntwikis.com");
        }
        //初始化表格
        private void initDataGrid()
        {
            dt = ReadData.readData(dataPath);
            dv = dt.DefaultView;
            dv.RowFilter = "IsIgnored=0";
            dataGridView.DataSource = dv;
            dataGridView.Columns[1].HeaderText = "类型";
            dataGridView.Columns[2].HeaderText = "名字";
            dataGridView.Columns[3].HeaderText = "拥有状态";
            dataGridView.Columns[4].Visible = false;
            dataGridView.Columns[5].Visible = false;
            dataGridView.Columns[6].HeaderText = "备注";
            for (int i = 0; i < dataGridView.ColumnCount - 1; i++)
            {
                dataGridView.Columns[i].ReadOnly = true;
            }
        }
        //窗体载入
        private void mainForm_Load(object sender, EventArgs e)
        {
            int xPoint = int.Parse(OperateIniFile.iniGetStringValue(configPath, "Settings", "LocationX", "-9999"));
            int yPoint = int.Parse(OperateIniFile.iniGetStringValue(configPath, "Settings", "LocationY", "-9999"));
            int showRetrofitedFlag = int.Parse(OperateIniFile.iniGetStringValue(configPath, "Settings", "ShowRetrofitedFlag", "1"));
            sizable = OperateIniFile.iniGetStringValue(configPath, "Settings", "Sizable", "0");
            int height = int.Parse(OperateIniFile.iniGetStringValue(configPath, "Settings", "Height", "520"));
            int width = int.Parse(OperateIniFile.iniGetStringValue(configPath, "Settings", "Width", "800"));
            checkUpdateFlag = OperateIniFile.iniGetStringValue(configPath, "Settings", "CheckUpdate", "1");
            if (checkUpdateFlag!="0")
            {
                CheckUpdate c = new CheckUpdate();
                string newVer = c.getResponse().Trim();
                if (newVer != "" && newVer != Application.ProductVersion.ToString())
                {
                    DialogResult dr = MessageBox.Show("有更新，是否前往更新？", "更新", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start("http://bbs.nga.cn/read.php?tid=11452817");
                        this.Close();
                    }
                }
            }
            decimal totalCount = 0, ownedCount = 0;
            if (xPoint != -9999 && yPoint != -9999)
            {
                this.Location = new Point(xPoint, yPoint);
            }
            if (showRetrofitedFlag == 1)
            {
                checkBox1.Checked = true;
                retrofitedFilterStr = "";
                totalCount = dt.Select("IsIgnored = 0 ").Length;
                ownedCount = dt.Select("IsIgnored = 0 and IsOwned = 1").Length;
            }
            else
            {
                checkBox1.Checked = false;
                retrofitedFilterStr = " and IsRetrofited = 0";
                totalCount = dt.Select("IsIgnored = 0 and IsRetrofited = 0").Length;
                ownedCount = dt.Select("IsIgnored = 0 and IsRetrofited = 0 and IsOwned = 1").Length;
            }
            if (sizable == "1")
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }

            this.Width = width;
            this.Height = height;
            if (totalCount > 0)
            {
                countTextBox.Text = ownedCount + "/" + totalCount + "," + Math.Round((ownedCount / totalCount * 100), 2) + "%";
            }
            else
            {
                countTextBox.Text = "0/0,0%";
            }
            dataGridView.AutoResizeColumns();
            dataGridView.AutoResizeRows();
        }

        //窗体退出
        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string xPoint = this.Location.X.ToString();
            string yPoint = this.Location.Y.ToString();
            string showRetrofitedFlag = checkBox1.Checked ? "1" : "0";
            string height = this.Height.ToString();
            string width = this.Width.ToString();
            string configItems = "appName=" + appName + "\0"
            + "LocationX=" + xPoint + "\0"
            + "LocationY=" + yPoint + "\0"
            + "ShowRetrofitedFlag=" + showRetrofitedFlag + "\0"
            + "Sizable=" + sizable + "\0"
            + "Height=" + height + "\0"
            + "Width=" + width + "\0"
            + "CheckUpdate=" + checkUpdateFlag;

            WriteData.reWriteData(dataPath, dt);
            OperateIniFile.iniWriteItems(configPath, "Settings", configItems);
        }
        //禁止访问其他网站
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (webBrowser.Url.ToString().Contains("js.ntwikis.com"))
            {
                tmpUrl = webBrowser.Url.ToString();
            }
            else if (tmpUrl != "")
            {
                webBrowser.Url = new Uri(tmpUrl);
            }
        }

        //更改表格显示内容
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ownedFilterStr = "IsIgnored = 0";
            dv.RowFilter = ownedFilterStr + retrofitedFilterStr + searchFilterStr;
            dataGridView.AutoResizeColumns();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ownedFilterStr = "IsIgnored = 0 and IsOwned = 1";
            dv.RowFilter = ownedFilterStr + retrofitedFilterStr + searchFilterStr;
            dataGridView.AutoResizeColumns();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ownedFilterStr = "IsIgnored = 0 and IsOwned = 0";
            dv.RowFilter = ownedFilterStr + retrofitedFilterStr + searchFilterStr;
            dataGridView.AutoResizeColumns();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            decimal totalCount = 0, ownedCount = 0;
            if (checkBox1.Checked)
            {
                retrofitedFilterStr = "";
                totalCount = dt.Select("IsIgnored = 0 ").Length;
                ownedCount = dt.Select("IsIgnored = 0 and IsOwned = 1").Length;
            }
            else
            {
                retrofitedFilterStr = " and IsRetrofited = 0";
                totalCount = dt.Select("IsIgnored = 0 and IsRetrofited = 0").Length;
                ownedCount = dt.Select("IsIgnored = 0 and IsRetrofited = 0 and IsOwned = 1").Length;
            }
            if (totalCount > 0)
            {
                countTextBox.Text = ownedCount + "/" + totalCount + "," + Math.Round((ownedCount / totalCount * 100), 2) + "%";
            }
            else
            {
                countTextBox.Text = "0/0,0%";
            }
            dv.RowFilter = ownedFilterStr + retrofitedFilterStr + searchFilterStr;
            dataGridView.AutoResizeColumns();
        }
        //搜索
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Trim() == "")
            {
                searchFilterStr = "";
            }
            else
            {
                searchFilterStr = " and Name like '%" + searchTextBox.Text + "%'";
            }
            dv.RowFilter = ownedFilterStr + retrofitedFilterStr + searchFilterStr;
        }
        //检查更新
        private void checkUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                CheckDataUpdate cu = new CheckDataUpdate();
                string re = cu.getResponse();
                cu.getDataTable();
                if (cu.compareDiff(ref dt))
                {
                    dv.Sort = " ID asc";
                    decimal totalCount = 0, ownedCount = 0;
                    if (checkBox1.Checked)
                    {
                        totalCount = dt.Select("IsIgnored = 0 ").Length;
                        ownedCount = dt.Select("IsIgnored = 0 and IsOwned = 1").Length;
                    }
                    else
                    {
                        totalCount = dt.Select("IsIgnored = 0 and IsRetrofited = 0").Length;
                        ownedCount = dt.Select("IsIgnored = 0 and IsRetrofited = 0 and IsOwned = 1").Length;
                    }
                    if (totalCount > 0)
                    {
                        countTextBox.Text = ownedCount + "/" + totalCount + "," + Math.Round((ownedCount / totalCount * 100), 2) + "%";
                    }
                    else
                    {
                        countTextBox.Text = "0/0,0%";
                    }
                    MessageBox.Show("更新完成！");
                }
                else
                {
                    MessageBox.Show("无需更新。");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //修改
        private void modifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    DataRow[] drs = new DataRow[dataGridView.SelectedRows.Count];
                    for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                    {
                        drs[i] = (dataGridView.SelectedRows[i].DataBoundItem as DataRowView).Row;
                    }
                    foreach (DataRow dr in drs)
                    {
                        dr[3] = (dr[3].ToString() == "1") ? 0 : 1;
                    }
                }
                decimal totalCount = 0, ownedCount = 0;
                totalCount = dt.Select("IsIgnored = 0 ").Length;
                ownedCount = dt.Select("IsIgnored = 0 and IsOwned = 1").Length;
                if (totalCount > 0)
                {
                    countTextBox.Text = ownedCount + "/" + totalCount + "," + Math.Round((ownedCount / totalCount * 100), 2) + "%";
                }
                else
                {
                    countTextBox.Text = "0/0,0%";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //页面自动跳转
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                string url = "http://js.ntwikis.com/jsp/apps/cancollezh/charactors/detail.jsp?detailid=" + id;
                if (tmpUrl != url)
                {
                    webBrowser.Url = new Uri(url);
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }


        //测试用
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            //if (this.textBox1.InvokeRequired)
            //{
            //    SetTextCallback d = new SetTextCallback(SetText);
            //    this.Invoke(d, new object[] { text });
            //}
            //else
            //{
            //    this.textBox1.Text = text;
            //}
        }

        private void findDropButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("该操作可能花费较长时间，确认继续吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    string id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                    FindDropPoint fdp = new FindDropPoint();
                    string dropPoints = fdp.DropPoints(id);
                    if (dropPoints == "")
                    {
                        MessageBox.Show("该舰为建造限定！");
                    }
                    else
                    {
                        DialogResult dr2 = MessageBox.Show(dropPoints, "是否需要写入备注", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            dropPoints = System.Text.RegularExpressions.Regex.Replace(dropPoints, "\n", "");
                            dataGridView.SelectedRows[0].Cells[6].Value += dropPoints;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
