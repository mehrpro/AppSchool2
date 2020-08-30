namespace SchoolApp.WinClient.Views.SystemForms
{
    partial class SplashScreenForm
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
            this.StatusLabel = new DevExpress.XtraEditors.LabelControl();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.StatusLabel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.StatusLabel.Appearance.Options.UseFont = true;
            this.StatusLabel.Appearance.Options.UseForeColor = true;
            this.StatusLabel.Location = new System.Drawing.Point(160, 118);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(94, 21);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "labelControl1";
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(12, 145);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Parmida_ActivePlusMultiKeys = false;
            this.marqueeProgressBarControl1.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.PingPong;
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(390, 25);
            this.marqueeProgressBarControl1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(111, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(193, 30);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "سیستم حضور وغیاب ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 16.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(127, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(160, 30);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "مدرسه سماء بیجار";
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::SchoolApp.WinClient.Properties.Resources.windows_xp_bliss_wide;
            this.ClientSize = new System.Drawing.Size(414, 182);
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.StatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreenForm";
            this.Load += new System.EventHandler(this.SplashScreenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl StatusLabel;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}