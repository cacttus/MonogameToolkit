namespace Monoedit
{
    partial class ProjectPropertiesForm
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
            this._lblOutputDirectory = new MetroFramework.Controls.MetroLabel();
            this._txtOutputDirectory = new MetroFramework.Controls.MetroTextBox();
            this._btnCancel = new MetroFramework.Controls.MetroButton();
            this._btnOk = new MetroFramework.Controls.MetroButton();
            this._btnApply = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this._cboExportFileType = new MetroFramework.Controls.MetroComboBox();
            this._lblExportFileType = new MetroFramework.Controls.MetroLabel();
            this._txtOutputFilename = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this._pnlMaxTextureWidth = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _lblOutputDirectory
            // 
            this._lblOutputDirectory.AutoSize = true;
            this._lblOutputDirectory.Location = new System.Drawing.Point(23, 86);
            this._lblOutputDirectory.Name = "_lblOutputDirectory";
            this._lblOutputDirectory.Size = new System.Drawing.Size(111, 19);
            this._lblOutputDirectory.TabIndex = 0;
            this._lblOutputDirectory.Text = "Output Directory:";
            this._lblOutputDirectory.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _txtOutputDirectory
            // 
            this._txtOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtOutputDirectory.CustomButton.Image = null;
            this._txtOutputDirectory.CustomButton.Location = new System.Drawing.Point(303, 1);
            this._txtOutputDirectory.CustomButton.Name = "";
            this._txtOutputDirectory.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtOutputDirectory.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtOutputDirectory.CustomButton.TabIndex = 1;
            this._txtOutputDirectory.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtOutputDirectory.CustomButton.UseSelectable = true;
            this._txtOutputDirectory.CustomButton.Visible = false;
            this._txtOutputDirectory.Lines = new string[] {
        "{ProjectRoot}/Output"};
            this._txtOutputDirectory.Location = new System.Drawing.Point(150, 86);
            this._txtOutputDirectory.MaxLength = 32767;
            this._txtOutputDirectory.Name = "_txtOutputDirectory";
            this._txtOutputDirectory.PasswordChar = '\0';
            this._txtOutputDirectory.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtOutputDirectory.SelectedText = "";
            this._txtOutputDirectory.SelectionLength = 0;
            this._txtOutputDirectory.SelectionStart = 0;
            this._txtOutputDirectory.ShortcutsEnabled = true;
            this._txtOutputDirectory.Size = new System.Drawing.Size(325, 23);
            this._txtOutputDirectory.TabIndex = 1;
            this._txtOutputDirectory.Text = "{ProjectRoot}/Output";
            this._txtOutputDirectory.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtOutputDirectory.UseSelectable = true;
            this._txtOutputDirectory.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtOutputDirectory.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this._txtOutputDirectory.Click += new System.EventHandler(this._txtOutputDirectory_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnCancel.Location = new System.Drawing.Point(282, 250);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 4;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnCancel.UseSelectable = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnOk.Location = new System.Drawing.Point(120, 250);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 5;
            this._btnOk.Text = "Ok";
            this._btnOk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnOk.UseSelectable = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnApply
            // 
            this._btnApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnApply.Location = new System.Drawing.Point(201, 250);
            this._btnApply.Name = "_btnApply";
            this._btnApply.Size = new System.Drawing.Size(75, 23);
            this._btnApply.TabIndex = 5;
            this._btnApply.Text = "Apply";
            this._btnApply.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnApply.UseSelectable = true;
            this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 156);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(121, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Max Texture Width:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _cboExportFileType
            // 
            this._cboExportFileType.FormattingEnabled = true;
            this._cboExportFileType.ItemHeight = 23;
            this._cboExportFileType.Location = new System.Drawing.Point(150, 194);
            this._cboExportFileType.Name = "_cboExportFileType";
            this._cboExportFileType.Size = new System.Drawing.Size(78, 29);
            this._cboExportFileType.TabIndex = 7;
            this._cboExportFileType.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._cboExportFileType.UseSelectable = true;
            // 
            // _lblExportFileType
            // 
            this._lblExportFileType.AutoSize = true;
            this._lblExportFileType.Location = new System.Drawing.Point(23, 194);
            this._lblExportFileType.Name = "_lblExportFileType";
            this._lblExportFileType.Size = new System.Drawing.Size(106, 19);
            this._lblExportFileType.TabIndex = 0;
            this._lblExportFileType.Text = "Export File Type:";
            this._lblExportFileType.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _txtOutputFilename
            // 
            this._txtOutputFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtOutputFilename.CustomButton.Image = null;
            this._txtOutputFilename.CustomButton.Location = new System.Drawing.Point(212, 1);
            this._txtOutputFilename.CustomButton.Name = "";
            this._txtOutputFilename.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtOutputFilename.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtOutputFilename.CustomButton.TabIndex = 1;
            this._txtOutputFilename.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtOutputFilename.CustomButton.UseSelectable = true;
            this._txtOutputFilename.CustomButton.Visible = false;
            this._txtOutputFilename.Lines = new string[] {
        "{ProjectName}.Json"};
            this._txtOutputFilename.Location = new System.Drawing.Point(150, 115);
            this._txtOutputFilename.MaxLength = 32767;
            this._txtOutputFilename.Name = "_txtOutputFilename";
            this._txtOutputFilename.PasswordChar = '\0';
            this._txtOutputFilename.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtOutputFilename.SelectedText = "";
            this._txtOutputFilename.SelectionLength = 0;
            this._txtOutputFilename.SelectionStart = 0;
            this._txtOutputFilename.ShortcutsEnabled = true;
            this._txtOutputFilename.Size = new System.Drawing.Size(234, 23);
            this._txtOutputFilename.TabIndex = 1;
            this._txtOutputFilename.Text = "{ProjectName}.Json";
            this._txtOutputFilename.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtOutputFilename.UseSelectable = true;
            this._txtOutputFilename.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtOutputFilename.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this._txtOutputFilename.Click += new System.EventHandler(this._txtOutputDirectory_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 115);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 19);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Output Filename:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _pnlMaxTextureWidth
            // 
            this._pnlMaxTextureWidth.Location = new System.Drawing.Point(157, 156);
            this._pnlMaxTextureWidth.Name = "_pnlMaxTextureWidth";
            this._pnlMaxTextureWidth.Size = new System.Drawing.Size(119, 32);
            this._pnlMaxTextureWidth.TabIndex = 8;
            // 
            // ProjectPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 296);
            this.Controls.Add(this._pnlMaxTextureWidth);
            this.Controls.Add(this._cboExportFileType);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnApply);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._txtOutputFilename);
            this.Controls.Add(this._txtOutputDirectory);
            this.Controls.Add(this._lblExportFileType);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this._lblOutputDirectory);
            this.Name = "ProjectPropertiesForm";
            this.Text = "ProjectProperties";
            this.Load += new System.EventHandler(this.ProjectPropertiesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel _lblOutputDirectory;
        private MetroFramework.Controls.MetroTextBox _txtOutputDirectory;
        private MetroFramework.Controls.MetroButton _btnCancel;
        private MetroFramework.Controls.MetroButton _btnOk;
        private MetroFramework.Controls.MetroButton _btnApply;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox _cboExportFileType;
        private MetroFramework.Controls.MetroLabel _lblExportFileType;
        private MetroFramework.Controls.MetroTextBox _txtOutputFilename;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Panel _pnlMaxTextureWidth;
    }
}