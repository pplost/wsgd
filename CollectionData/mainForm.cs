using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
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
            //阻止脚本错误提示
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
            for (int i = 0; i < dataGridView.ColumnCount; i++)
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
                showRetroCheckBox.Checked = true;
                retrofitedFilterStr = "";
                totalCount = dt.Select("IsIgnored = 0 ").Length;
                ownedCount = dt.Select("IsIgnored = 0 and IsOwned = 1").Length;
            }
            else
            {
                showRetroCheckBox.Checked = false;
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
            reSizeColumns();
            dataGridView.AutoResizeRows();
        }

        //窗体退出
        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            string xPoint = this.Location.X.ToString();
            string yPoint = this.Location.Y.ToString();
            string showRetrofitedFlag = showRetroCheckBox.Checked ? "1" : "0";
            string height = this.Height.ToString();
            string width = this.Width.ToString();
            OperateIniFile.iniWriteValue(configPath, "Settings", "appName", appName);
            OperateIniFile.iniWriteValue(configPath, "Settings", "ShowRetrofitedFlag", showRetrofitedFlag);
            OperateIniFile.iniWriteValue(configPath, "Settings", "LocationX", xPoint);
            OperateIniFile.iniWriteValue(configPath, "Settings", "LocationY", yPoint);
            OperateIniFile.iniWriteValue(configPath, "Settings", "Height", height);
            OperateIniFile.iniWriteValue(configPath, "Settings", "Width", width);
            OperateIniFile.iniWriteValue(configPath, "Settings", "Sizable", sizable);
            OperateIniFile.iniWriteValue(configPath, "Settings", "CheckUpdate", checkUpdateFlag);
            WriteData.reWriteData(dataPath, dt);

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
        private void showAllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ownedFilterStr = "IsIgnored = 0";
            dv.RowFilter = ownedFilterStr + retrofitedFilterStr + searchFilterStr;
            reSizeColumns();
        }
        private void showOwnedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ownedFilterStr = "IsIgnored = 0 and IsOwned = 1";
            dv.RowFilter = ownedFilterStr + retrofitedFilterStr + searchFilterStr;
            reSizeColumns();
        }
        private void showUnownedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ownedFilterStr = "IsIgnored = 0 and IsOwned = 0";
            dv.RowFilter = ownedFilterStr + retrofitedFilterStr + searchFilterStr;
            reSizeColumns();
        }
        private void showRetroCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            decimal totalCount = 0, ownedCount = 0;
            if (showRetroCheckBox.Checked)
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
            reSizeColumns();
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
                    if (showRetroCheckBox.Checked)
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
                dataGridView.SelectedRows[0].Selected = true;
                List<int> l = new List<int>();
                for(int i=1;i< dataGridView.SelectedRows.Count;i++)
                {
                    l.Add(dataGridView.SelectedRows[i].Index);
                }
                foreach(int i in l)
                {
                    dataGridView.Rows[i].Selected = false;
                }
                string id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                if (int.Parse(id) > 1000 && int.Parse(id) < 2000)
                {
                    MessageBox.Show("该舰为改造获得！");
                    return;
                }
                DialogResult dr = MessageBox.Show("该操作可能花费较长时间，确认继续吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    FindDropPoint fdp = new FindDropPoint();
                    string dropPoints = fdp.DropPoints(id);

                    if (dropPoints == "")
                    {
                        MessageBox.Show("该舰暂时无法通过打捞获得！");
                    }
                    else
                    {
                        DialogResult dr2 = MessageBox.Show(dropPoints, "是否需要写入备注", MessageBoxButtons.OKCancel);
                        if (dr2 == DialogResult.OK)
                        {
                            dropPoints = Regex.Replace(dropPoints, "\n", "\t");
                            if (dataGridView.SelectedRows[0].Cells[6].Value.ToString().Trim() != "")
                            {
                                dataGridView.SelectedRows[0].Cells[6].Value += "\t";
                            }
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

        #region 自动调整窗口
        private void reSizeColumns()
        {
            
            dataGridView.AutoResizeColumns();
        }
        #endregion

        #region 窗体传值

        private int cellPos = 0;
        public string remarkFormString
        {
            set
            {
                dataGridView.Rows[cellPos].Cells[dataGridView.ColumnCount - 1].Value = value;
            }
        }
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dataGridView.ColumnCount - 1;
            int rowIndex = e.RowIndex;
            RemarkForm remarkForm = new RemarkForm();
            remarkForm.Owner = this;
            string inStr = dataGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString();
            inStr = Regex.Replace(inStr, "\\t", "\r\n");
            remarkForm.remarkStr = inStr;
            cellPos = rowIndex;
            remarkForm.ShowDialog();
        }

        #endregion
    }
}
