namespace Monoedit
{
    partial class AboutForm
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
            this._txtAbout = new MetroFramework.Controls.MetroTextBox();
            this._btnOk = new MetroFramework.Controls.MetroButton();
            this._txtErrors = new MetroFramework.Controls.MetroTextBox();
            this._btnClearErrors = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // _txtAbout
            // 
            this._txtAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtAbout.CustomButton.Image = null;
            this._txtAbout.CustomButton.Location = new System.Drawing.Point(199, 1);
            this._txtAbout.CustomButton.Name = "";
            this._txtAbout.CustomButton.Size = new System.Drawing.Size(193, 193);
            this._txtAbout.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtAbout.CustomButton.TabIndex = 1;
            this._txtAbout.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._txtAbout.CustomButton.UseSelectable = true;
            this._txtAbout.CustomButton.Visible = false;
            this._txtAbout.Lines = new string[0];
            this._txtAbout.Location = new System.Drawing.Point(23, 82);
            this._txtAbout.MaxLength = 32767;
            this._txtAbout.Multiline = true;
            this._txtAbout.Name = "_txtAbout";
            this._txtAbout.PasswordChar = '\0';
            this._txtAbout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtAbout.SelectedText = "";
            this._txtAbout.SelectionLength = 0;
            this._txtAbout.SelectionStart = 0;
            this._txtAbout.ShortcutsEnabled = true;
            this._txtAbout.Size = new System.Drawing.Size(393, 184);
            this._txtAbout.TabIndex = 0;
            this._txtAbout.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtAbout.UseSelectable = true;
            this._txtAbout.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtAbout.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this._txtAbout.Click += new System.EventHandler(this._txtAbout_Click);
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnOk.Location = new System.Drawing.Point(175, 489);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 1;
            this._btnOk.Text = "Ok";
            this._btnOk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnOk.UseSelectable = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _txtErrors
            // 
            this._txtErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtErrors.CustomButton.Image = null;
            this._txtErrors.CustomButton.Location = new System.Drawing.Point(199, 1);
            this._txtErrors.CustomButton.Name = "";
            this._txtErrors.CustomButton.Size = new System.Drawing.Size(193, 193);
            this._txtErrors.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtErrors.CustomButton.TabIndex = 1;
            this._txtErrors.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._txtErrors.CustomButton.UseSelectable = true;
            this._txtErrors.CustomButton.Visible = false;
            this._txtErrors.Lines = new string[0];
            this._txtErrors.Location = new System.Drawing.Point(23, 291);
            this._txtErrors.MaxLength = 32767;
            this._txtErrors.Multiline = true;
            this._txtErrors.Name = "_txtErrors";
            this._txtErrors.PasswordChar = '\0';
            this._txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtErrors.SelectedText = "";
            this._txtErrors.SelectionLength = 0;
            this._txtErrors.SelectionStart = 0;
            this._txtErrors.ShortcutsEnabled = true;
            this._txtErrors.Size = new System.Drawing.Size(393, 168);
            this._txtErrors.TabIndex = 0;
            this._txtErrors.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtErrors.UseSelectable = true;
            this._txtErrors.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtErrors.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this._txtErrors.Click += new System.EventHandler(this._txtAbout_Click);
            // 
            // _btnClearErrors
            // 
            this._btnClearErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClearErrors.Location = new System.Drawing.Point(370, 465);
            this._btnClearErrors.Name = "_btnClearErrors";
            this._btnClearErrors.Size = new System.Drawing.Size(46, 23);
            this._btnClearErrors.TabIndex = 1;
            this._btnClearErrors.Text = "Clear";
            this._btnClearErrors.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnClearErrors.UseSelectable = true;
            this._btnClearErrors.Click += new System.EventHandler(this._btnClearErrors_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "About";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 269);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Error Log";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 530);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this._btnClearErrors);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._txtErrors);
            this.Controls.Add(this._txtAbout);
            this.Name = "AboutForm";
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox _txtAbout;
        private MetroFramework.Controls.MetroButton _btnOk;
        private MetroFramework.Controls.MetroTextBox _txtErrors;
        private MetroFramework.Controls.MetroButton _btnClearErrors;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}