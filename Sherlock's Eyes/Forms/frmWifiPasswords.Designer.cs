namespace Sherlock_s_Eyes
{
    partial class frmWifiPasswords
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsvSSID = new System.Windows.Forms.ListView();
            this.colSSID = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.lsvDetails = new System.Windows.Forms.ListView();
            this.colFieldName = new System.Windows.Forms.ColumnHeader();
            this.colValue = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lsvSSID
            // 
            this.lsvSSID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsvSSID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSSID});
            this.lsvSSID.FullRowSelect = true;
            this.lsvSSID.Location = new System.Drawing.Point(12, 12);
            this.lsvSSID.MultiSelect = false;
            this.lsvSSID.Name = "lsvSSID";
            this.lsvSSID.Size = new System.Drawing.Size(226, 252);
            this.lsvSSID.TabIndex = 0;
            this.lsvSSID.UseCompatibleStateImageBehavior = false;
            this.lsvSSID.View = System.Windows.Forms.View.Details;
            this.lsvSSID.SelectedIndexChanged += new System.EventHandler(this.lsvSSID_SelectedIndexChanged);
            // 
            // colSSID
            // 
            this.colSSID.Text = "SSID";
            this.colSSID.Width = 200;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(613, 270);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lsvDetails
            // 
            this.lsvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFieldName,
            this.colValue});
            this.lsvDetails.FullRowSelect = true;
            this.lsvDetails.Location = new System.Drawing.Point(244, 12);
            this.lsvDetails.MultiSelect = false;
            this.lsvDetails.Name = "lsvDetails";
            this.lsvDetails.Size = new System.Drawing.Size(444, 252);
            this.lsvDetails.TabIndex = 3;
            this.lsvDetails.UseCompatibleStateImageBehavior = false;
            this.lsvDetails.View = System.Windows.Forms.View.Details;
            this.lsvDetails.SelectedIndexChanged += new System.EventHandler(this.lsvDetails_SelectedIndexChanged);
            this.lsvDetails.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsvDetails_MouseDoubleClick);
            // 
            // colFieldName
            // 
            this.colFieldName.Text = "Field";
            this.colFieldName.Width = 150;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 270;
            // 
            // frmWifiPasswords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(700, 305);
            this.Controls.Add(this.lsvDetails);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lsvSSID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWifiPasswords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wifi Information Stored on this Machine";
            this.Load += new System.EventHandler(this.frmWifiPasswords_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lsvSSID;
        private ColumnHeader colSSID;
        private Button btnClose;
        private ListView lsvDetails;
        private ColumnHeader colFieldName;
        private ColumnHeader colValue;
    }
}