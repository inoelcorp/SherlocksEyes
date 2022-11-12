
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lsvLocations = new System.Windows.Forms.ListView();
            this.colRemoteIP = new System.Windows.Forms.ColumnHeader();
            this.colCountry = new System.Windows.Forms.ColumnHeader();
            this.colDetail = new System.Windows.Forms.ColumnHeader();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnWhoIs = new System.Windows.Forms.Button();
            this.mnuCtxTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wiFiPasswordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuButton1 = new Sherlock_s_Eyes.UserControls.MenuButton();
            this.mnuCtxTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvLocations
            // 
            this.lsvLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRemoteIP,
            this.colCountry,
            this.colDetail});
            this.lsvLocations.FullRowSelect = true;
            this.lsvLocations.Location = new System.Drawing.Point(11, 15);
            this.lsvLocations.MultiSelect = false;
            this.lsvLocations.Name = "lsvLocations";
            this.lsvLocations.OwnerDraw = true;
            this.lsvLocations.Size = new System.Drawing.Size(552, 221);
            this.lsvLocations.TabIndex = 0;
            this.lsvLocations.UseCompatibleStateImageBehavior = false;
            this.lsvLocations.View = System.Windows.Forms.View.Details;
            this.lsvLocations.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lsvLocations_DrawColumnHeader);
            this.lsvLocations.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lsvLocations_DrawItem);
            this.lsvLocations.SelectedIndexChanged += new System.EventHandler(this.lsvLocations_SelectedIndexChanged);
            // 
            // colRemoteIP
            // 
            this.colRemoteIP.Text = "Remote IP";
            this.colRemoteIP.Width = 100;
            // 
            // colCountry
            // 
            this.colCountry.Text = "Country";
            this.colCountry.Width = 120;
            // 
            // colDetail
            // 
            this.colDetail.Text = "Nearest Address";
            this.colDetail.Width = 310;
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInfo.Location = new System.Drawing.Point(8, 242);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(407, 242);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(488, 242);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMap
            // 
            this.btnMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMap.Enabled = false;
            this.btnMap.Location = new System.Drawing.Point(89, 242);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(75, 23);
            this.btnMap.TabIndex = 2;
            this.btnMap.Text = "Map";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // btnWhoIs
            // 
            this.btnWhoIs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWhoIs.Enabled = false;
            this.btnWhoIs.Location = new System.Drawing.Point(170, 242);
            this.btnWhoIs.Name = "btnWhoIs";
            this.btnWhoIs.Size = new System.Drawing.Size(75, 23);
            this.btnWhoIs.TabIndex = 3;
            this.btnWhoIs.Text = "Who Is?";
            this.btnWhoIs.UseVisualStyleBackColor = true;
            this.btnWhoIs.Click += new System.EventHandler(this.button1_Click);
            // 
            // mnuCtxTools
            // 
            this.mnuCtxTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wiFiPasswordsToolStripMenuItem});
            this.mnuCtxTools.Name = "mnuCtxTools";
            this.mnuCtxTools.Size = new System.Drawing.Size(165, 26);
            // 
            // wiFiPasswordsToolStripMenuItem
            // 
            this.wiFiPasswordsToolStripMenuItem.Name = "wiFiPasswordsToolStripMenuItem";
            this.wiFiPasswordsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.wiFiPasswordsToolStripMenuItem.Text = "WiFi Passwords...";
            this.wiFiPasswordsToolStripMenuItem.Click += new System.EventHandler(this.wiFiPasswordsToolStripMenuItem_Click);
            // 
            // menuButton1
            // 
            this.menuButton1.Location = new System.Drawing.Point(251, 242);
            this.menuButton1.Menu = this.mnuCtxTools;
            this.menuButton1.Name = "menuButton1";
            this.menuButton1.Size = new System.Drawing.Size(75, 23);
            this.menuButton1.TabIndex = 4;
            this.menuButton1.Text = "Tools";
            this.menuButton1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 278);
            this.Controls.Add(this.menuButton1);
            this.Controls.Add(this.btnWhoIs);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.lsvLocations);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sherlock\'s Eyes";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuCtxTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

    #endregion

    private ListView lsvLocations;
    private Button btnInfo;
    private Button btnRefresh;
    private Button btnClose;
    private ColumnHeader colRemoteIP;
    private ColumnHeader colCountry;
    private ColumnHeader colDetail;
    private Button btnMap;
    private Button btnWhoIs;
    private ContextMenuStrip mnuCtxTools;
    private ToolStripMenuItem wiFiPasswordsToolStripMenuItem;
    private Sherlock_s_Eyes.UserControls.MenuButton menuButton1;
}
