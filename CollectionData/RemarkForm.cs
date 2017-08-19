using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CollectionData
{
    public partial class RemarkForm : Form
    {
        private string configPath = Application.StartupPath + "\\config.ini";
        public RemarkForm()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
        public string remarkStr
        {
            get
            {
                return remarkTextBox.Text;
            }
            set
            {
                if (value == null)
                {
                    remarkTextBox.Text = string.Empty;
                }
                else
                {
                    remarkTextBox.Text = value;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            mainForm mainForm1 = (mainForm)this.Owner;
            string outStr = remarkTextBox.Text;
            outStr = Regex.Replace(outStr, "\r\n", "\t");
            mainForm1.remarkFormString = outStr;
            this.Close();
        }
        private void RemarkForm_Load(object sender, EventArgs e)
        {
            int xPoint = int.Parse(OperateIniFile.iniGetStringValue(configPath, "Settings", "rLocationX", "-9999"));
            int yPoint = int.Parse(OperateIniFile.iniGetStringValue(configPath, "Settings", "rLocationY", "-9999"));
            int width = int.Parse(OperateIniFile.iniGetStringValue(configPath, "Settings", "rWidth", "350"));
            int height = int.Parse(OperateIniFile.iniGetStringValue(configPath, "Settings", "rHeight", "400"));
            if (xPoint != -9999 && yPoint != -9999)
            {
                this.Location = new Point(xPoint, yPoint);
            }
            this.Width = width;
            this.Height = height;
        }
        private void RemarkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string xPoint = this.Location.X.ToString();
            string yPoint = this.Location.Y.ToString();
            string height = this.Height.ToString();
            string width = this.Width.ToString();
            OperateIniFile.iniWriteValue(configPath, "Settings", "rLocationX", xPoint);
            OperateIniFile.iniWriteValue(configPath, "Settings", "rLocationY", yPoint);
            OperateIniFile.iniWriteValue(configPath, "Settings", "rHeight", height);
            OperateIniFile.iniWriteValue(configPath, "Settings", "rWidth", width);
        }
    }
}
