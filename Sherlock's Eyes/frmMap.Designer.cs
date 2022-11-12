namespace Sherlock_s_Eyes
{
    partial class frmMap
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
            this.btnClose = new System.Windows.Forms.Button();
            this.webViewCtrl = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webViewCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(926, 527);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // webViewCtrl
            // 
            this.webViewCtrl.AllowExternalDrop = true;
            this.webViewCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webViewCtrl.CreationProperties = null;
            this.webViewCtrl.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webViewCtrl.Location = new System.Drawing.Point(12, 11);
            this.webViewCtrl.Name = "webViewCtrl";
            this.webViewCtrl.Size = new System.Drawing.Size(987, 510);
            this.webViewCtrl.TabIndex = 2;
            this.webViewCtrl.ZoomFactor = 1D;
            // 
            // frmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1013, 562);
            this.Controls.Add(this.webViewCtrl);
            this.Controls.Add(this.btnClose);
            this.MinimizeBox = false;
            this.Name = "frmMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            ((System.ComponentModel.ISupportInitialize)(this.webViewCtrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnClose;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewCtrl;
    }
}