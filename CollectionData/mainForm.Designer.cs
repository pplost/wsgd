using System.Windows.Forms;
namespace CollectionData
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.modifyButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.showRetroCheckBox = new System.Windows.Forms.CheckBox();
            this.showUnownedRadioButton = new System.Windows.Forms.RadioButton();
            this.showOwnedRadioButton = new System.Windows.Forms.RadioButton();
            this.showAllRadioButton = new System.Windows.Forms.RadioButton();
            this.checkUpdateButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.findDropButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.webBrowser);
            this.panel1.Location = new System.Drawing.Point(372, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 461);
            this.panel1.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(400, 461);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            // 
            // modifyButton
            // 
            this.modifyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.modifyButton.Location = new System.Drawing.Point(287, 450);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 1;
            this.modifyButton.Text = "切换";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(350, 400);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // showRetroCheckBox
            // 
            this.showRetroCheckBox.AutoSize = true;
            this.showRetroCheckBox.Checked = true;
            this.showRetroCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showRetroCheckBox.Location = new System.Drawing.Point(264, 4);
            this.showRetroCheckBox.Name = "showRetroCheckBox";
            this.showRetroCheckBox.Size = new System.Drawing.Size(84, 16);
            this.showRetroCheckBox.TabIndex = 3;
            this.showRetroCheckBox.Text = "显示改造船";
            this.showRetroCheckBox.UseVisualStyleBackColor = true;
            this.showRetroCheckBox.CheckedChanged += new System.EventHandler(this.showRetroCheckBox_CheckedChanged);
            // 
            // showUnownedRadioButton
            // 
            this.showUnownedRadioButton.AutoSize = true;
            this.showUnownedRadioButton.Location = new System.Drawing.Point(121, 3);
            this.showUnownedRadioButton.Name = "showUnownedRadioButton";
            this.showUnownedRadioButton.Size = new System.Drawing.Size(59, 16);
            this.showUnownedRadioButton.TabIndex = 2;
            this.showUnownedRadioButton.TabStop = true;
            this.showUnownedRadioButton.Text = "未拥有";
            this.showUnownedRadioButton.UseVisualStyleBackColor = true;
            this.showUnownedRadioButton.CheckedChanged += new System.EventHandler(this.showUnownedRadioButton_CheckedChanged);
            // 
            // showOwnedRadioButton
            // 
            this.showOwnedRadioButton.AutoSize = true;
            this.showOwnedRadioButton.Location = new System.Drawing.Point(56, 3);
            this.showOwnedRadioButton.Name = "showOwnedRadioButton";
            this.showOwnedRadioButton.Size = new System.Drawing.Size(59, 16);
            this.showOwnedRadioButton.TabIndex = 1;
            this.showOwnedRadioButton.Text = "已拥有";
            this.showOwnedRadioButton.UseVisualStyleBackColor = true;
            this.showOwnedRadioButton.CheckedChanged += new System.EventHandler(this.showOwnedRadioButton_CheckedChanged);
            // 
            // showAllRadioButton
            // 
            this.showAllRadioButton.AutoSize = true;
            this.showAllRadioButton.Checked = true;
            this.showAllRadioButton.Location = new System.Drawing.Point(3, 3);
            this.showAllRadioButton.Name = "showAllRadioButton";
            this.showAllRadioButton.Size = new System.Drawing.Size(47, 16);
            this.showAllRadioButton.TabIndex = 0;
            this.showAllRadioButton.TabStop = true;
            this.showAllRadioButton.Text = "全部";
            this.showAllRadioButton.UseVisualStyleBackColor = true;
            this.showAllRadioButton.CheckedChanged += new System.EventHandler(this.showAllRadioButton_CheckedChanged);
            // 
            // checkUpdateButton
            // 
            this.checkUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkUpdateButton.Location = new System.Drawing.Point(206, 450);
            this.checkUpdateButton.Name = "checkUpdateButton";
            this.checkUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.checkUpdateButton.TabIndex = 5;
            this.checkUpdateButton.Text = "检查更新";
            this.checkUpdateButton.UseVisualStyleBackColor = true;
            this.checkUpdateButton.Click += new System.EventHandler(this.checkUpdateButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.searchTextBox);
            this.panel2.Controls.Add(this.showRetroCheckBox);
            this.panel2.Controls.Add(this.showAllRadioButton);
            this.panel2.Controls.Add(this.showUnownedRadioButton);
            this.panel2.Controls.Add(this.showOwnedRadioButton);
            this.panel2.Location = new System.Drawing.Point(12, 415);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 29);
            this.panel2.TabIndex = 6;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(186, 2);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(72, 21);
            this.searchTextBox.TabIndex = 7;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // countTextBox
            // 
            this.countTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.countTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.countTextBox.Location = new System.Drawing.Point(39, 455);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.ReadOnly = true;
            this.countTextBox.Size = new System.Drawing.Size(72, 14);
            this.countTextBox.TabIndex = 7;
            // 
            // findDropButton
            // 
            this.findDropButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.findDropButton.Location = new System.Drawing.Point(125, 450);
            this.findDropButton.Name = "findDropButton";
            this.findDropButton.Size = new System.Drawing.Size(75, 23);
            this.findDropButton.TabIndex = 8;
            this.findDropButton.Text = "查询掉落点";
            this.findDropButton.UseVisualStyleBackColor = true;
            this.findDropButton.Click += new System.EventHandler(this.findDropButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 482);
            this.Controls.Add(this.findDropButton);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.checkUpdateButton);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "战舰少女仓库";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private RadioButton showUnownedRadioButton;
        private RadioButton showOwnedRadioButton;
        private RadioButton showAllRadioButton;
        private Button checkUpdateButton;
        private CheckBox showRetroCheckBox;
        private Panel panel2;
        private WebBrowser webBrowser;
        private TextBox searchTextBox;
        private TextBox countTextBox;
        private Button findDropButton;
    }
}

