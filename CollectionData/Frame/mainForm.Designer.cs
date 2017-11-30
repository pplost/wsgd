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
            this.showUnownedRadioButton = new System.Windows.Forms.RadioButton();
            this.showOwnedRadioButton = new System.Windows.Forms.RadioButton();
            this.showAllRadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.findDropButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDataUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRetroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoCheckUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.webBrowser);
            this.panel1.Location = new System.Drawing.Point(372, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 446);
            this.panel1.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(400, 446);
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
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(350, 385);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.searchTextBox);
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
            this.searchTextBox.Size = new System.Drawing.Size(161, 21);
            this.searchTextBox.TabIndex = 7;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // countTextBox
            // 
            this.countTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.countTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.countTextBox.Location = new System.Drawing.Point(27, 455);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.ReadOnly = true;
            this.countTextBox.Size = new System.Drawing.Size(92, 14);
            this.countTextBox.TabIndex = 7;
            // 
            // findDropButton
            // 
            this.findDropButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.findDropButton.Location = new System.Drawing.Point(206, 450);
            this.findDropButton.Name = "findDropButton";
            this.findDropButton.Size = new System.Drawing.Size(75, 23);
            this.findDropButton.TabIndex = 8;
            this.findDropButton.Text = "查询掉落点";
            this.findDropButton.UseVisualStyleBackColor = true;
            this.findDropButton.Click += new System.EventHandler(this.findDropButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 25);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkUpdateToolStripMenuItem,
            this.checkDataUpdateToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.menuToolStripMenuItem.Text = "菜单";
            // 
            // checkUpdateToolStripMenuItem
            // 
            this.checkUpdateToolStripMenuItem.Name = "checkUpdateToolStripMenuItem";
            this.checkUpdateToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.checkUpdateToolStripMenuItem.Text = "检查程序更新";
            this.checkUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkUpdateToolStripMenuItem_Click);
            // 
            // checkDataUpdateToolStripMenuItem
            // 
            this.checkDataUpdateToolStripMenuItem.Name = "checkDataUpdateToolStripMenuItem";
            this.checkDataUpdateToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.checkDataUpdateToolStripMenuItem.Text = "检查数据更新";
            this.checkDataUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkDataUpdateToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "退出";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.idToolStripMenuItem,
            this.typeToolStripMenuItem,
            this.nameToolStripMenuItem,
            this.remarkToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.searchToolStripMenuItem.Text = "搜索内容";
            // 
            // idToolStripMenuItem
            // 
            this.idToolStripMenuItem.Name = "idToolStripMenuItem";
            this.idToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.idToolStripMenuItem.Text = "ID";
            this.idToolStripMenuItem.Click += new System.EventHandler(this.idToolStripMenuItem_Click);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.typeToolStripMenuItem.Text = "类型";
            this.typeToolStripMenuItem.Click += new System.EventHandler(this.typeToolStripMenuItem_Click);
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nameToolStripMenuItem.Text = "名字";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // remarkToolStripMenuItem
            // 
            this.remarkToolStripMenuItem.Name = "remarkToolStripMenuItem";
            this.remarkToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.remarkToolStripMenuItem.Text = "备注";
            this.remarkToolStripMenuItem.Click += new System.EventHandler(this.remarkToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showRetroToolStripMenuItem,
            this.sizableToolStripMenuItem,
            this.autoCheckUpdateToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.settingToolStripMenuItem.Text = "设置";
            // 
            // showRetroToolStripMenuItem
            // 
            this.showRetroToolStripMenuItem.Name = "showRetroToolStripMenuItem";
            this.showRetroToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.showRetroToolStripMenuItem.Text = "显示改造";
            this.showRetroToolStripMenuItem.Click += new System.EventHandler(this.showRetroToolStripMenuItem_Click);
            // 
            // sizableToolStripMenuItem
            // 
            this.sizableToolStripMenuItem.Name = "sizableToolStripMenuItem";
            this.sizableToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.sizableToolStripMenuItem.Text = "锁定窗口大小";
            this.sizableToolStripMenuItem.Click += new System.EventHandler(this.sizableToolStripMenuItem_Click);
            // 
            // autoCheckUpdateToolStripMenuItem
            // 
            this.autoCheckUpdateToolStripMenuItem.Name = "autoCheckUpdateToolStripMenuItem";
            this.autoCheckUpdateToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.autoCheckUpdateToolStripMenuItem.Text = "自动检查更新";
            this.autoCheckUpdateToolStripMenuItem.Click += new System.EventHandler(this.autoCheckUpdateToolStripMenuItem_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 482);
            this.Controls.Add(this.findDropButton);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "战舰少女仓库";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
        private Panel panel2;
        private WebBrowser webBrowser;
        private TextBox searchTextBox;
        private TextBox countTextBox;
        private Button findDropButton;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem showRetroToolStripMenuItem;
        private ToolStripMenuItem sizableToolStripMenuItem;
        private ToolStripMenuItem autoCheckUpdateToolStripMenuItem;
        private ToolStripMenuItem checkUpdateToolStripMenuItem;
        private ToolStripMenuItem idToolStripMenuItem;
        private ToolStripMenuItem typeToolStripMenuItem;
        private ToolStripMenuItem nameToolStripMenuItem;
        private ToolStripMenuItem remarkToolStripMenuItem;
        private ToolStripMenuItem checkDataUpdateToolStripMenuItem;
    }
}

