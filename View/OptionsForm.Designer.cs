namespace Monoedit
{
    partial class OptionsForm
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
            this._btnOk = new MetroFramework.Controls.MetroButton();
            this._btnCancel = new MetroFramework.Controls.MetroButton();
            this._cboLanguage = new MetroFramework.Controls.MetroComboBox();
            this._lblLanguage = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this._cboTheme = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnOk.Location = new System.Drawing.Point(54, 176);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 0;
            this._btnOk.Text = "Ok";
            this._btnOk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnOk.UseSelectable = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(135, 176);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 0;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnCancel.UseSelectable = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _cboLanguage
            // 
            this._cboLanguage.FormattingEnabled = true;
            this._cboLanguage.ItemHeight = 23;
            this._cboLanguage.Items.AddRange(new object[] {
            "English",
            "Spanish"});
            this._cboLanguage.Location = new System.Drawing.Point(85, 63);
            this._cboLanguage.Name = "_cboLanguage";
            this._cboLanguage.Size = new System.Drawing.Size(159, 29);
            this._cboLanguage.TabIndex = 1;
            this._cboLanguage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._cboLanguage.UseSelectable = true;
            this._cboLanguage.SelectedIndexChanged += new System.EventHandler(this._cboLanguage_SelectedIndexChanged);
            // 
            // _lblLanguage
            // 
            this._lblLanguage.AutoSize = true;
            this._lblLanguage.Location = new System.Drawing.Point(13, 63);
            this._lblLanguage.Name = "_lblLanguage";
            this._lblLanguage.Size = new System.Drawing.Size(66, 19);
            this._lblLanguage.TabIndex = 2;
            this._lblLanguage.Text = "Language";
            this._lblLanguage.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(13, 98);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(49, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Theme";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _cboTheme
            // 
            this._cboTheme.FormattingEnabled = true;
            this._cboTheme.ItemHeight = 23;
            this._cboTheme.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this._cboTheme.Location = new System.Drawing.Point(85, 98);
            this._cboTheme.Name = "_cboTheme";
            this._cboTheme.Size = new System.Drawing.Size(159, 29);
            this._cboTheme.TabIndex = 3;
            this._cboTheme.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._cboTheme.UseSelectable = true;
            this._cboTheme.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 222);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this._cboTheme);
            this.Controls.Add(this._lblLanguage);
            this.Controls.Add(this._cboLanguage);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton _btnOk;
        private MetroFramework.Controls.MetroButton _btnCancel;
        private MetroFramework.Controls.MetroComboBox _cboLanguage;
        private MetroFramework.Controls.MetroLabel _lblLanguage;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox _cboTheme;
    }
}