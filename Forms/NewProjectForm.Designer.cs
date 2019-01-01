namespace Monoedit
{
    partial class NewProjectForm
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
            this._pnlProjectDir = new System.Windows.Forms.Panel();
            this._lblProjectName = new MetroFramework.Controls.MetroLabel();
            this._txtProjectName = new MetroFramework.Controls.MetroTextBox();
            this._btnOk = new MetroFramework.Controls.MetroButton();
            this._btnCancel = new MetroFramework.Controls.MetroButton();
            this._txtFinalPath = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this._chkOverwrite = new MetroFramework.Controls.MetroCheckBox();
            this.SuspendLayout();
            // 
            // _pnlProjectDir
            // 
            this._pnlProjectDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlProjectDir.Location = new System.Drawing.Point(13, 136);
            this._pnlProjectDir.Name = "_pnlProjectDir";
            this._pnlProjectDir.Size = new System.Drawing.Size(553, 28);
            this._pnlProjectDir.TabIndex = 0;
            this._pnlProjectDir.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlProjectDir_Paint);
            // 
            // _lblProjectName
            // 
            this._lblProjectName.AutoSize = true;
            this._lblProjectName.Location = new System.Drawing.Point(12, 83);
            this._lblProjectName.Name = "_lblProjectName";
            this._lblProjectName.Size = new System.Drawing.Size(90, 19);
            this._lblProjectName.TabIndex = 1;
            this._lblProjectName.Text = "Project Name";
            this._lblProjectName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _txtProjectName
            // 
            this._txtProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtProjectName.CustomButton.Image = null;
            this._txtProjectName.CustomButton.Location = new System.Drawing.Point(198, 1);
            this._txtProjectName.CustomButton.Name = "";
            this._txtProjectName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtProjectName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtProjectName.CustomButton.TabIndex = 1;
            this._txtProjectName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtProjectName.CustomButton.UseSelectable = true;
            this._txtProjectName.CustomButton.Visible = false;
            this._txtProjectName.Lines = new string[] {
        "MyProject"};
            this._txtProjectName.Location = new System.Drawing.Point(108, 83);
            this._txtProjectName.MaxLength = 32767;
            this._txtProjectName.Name = "_txtProjectName";
            this._txtProjectName.PasswordChar = '\0';
            this._txtProjectName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtProjectName.SelectedText = "";
            this._txtProjectName.SelectionLength = 0;
            this._txtProjectName.SelectionStart = 0;
            this._txtProjectName.ShortcutsEnabled = true;
            this._txtProjectName.Size = new System.Drawing.Size(220, 23);
            this._txtProjectName.TabIndex = 2;
            this._txtProjectName.Text = "MyProject";
            this._txtProjectName.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtProjectName.UseSelectable = true;
            this._txtProjectName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtProjectName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this._txtProjectName.TextChanged += new System.EventHandler(this._txtProjectName_TextChanged);
            this._txtProjectName.Click += new System.EventHandler(this._txtProjectName_Click);
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnOk.Location = new System.Drawing.Point(219, 244);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 3;
            this._btnOk.Text = "Ok";
            this._btnOk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnOk.UseSelectable = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnCancel.Location = new System.Drawing.Point(300, 244);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 3;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnCancel.UseSelectable = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _txtFinalPath
            // 
            this._txtFinalPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtFinalPath.CustomButton.Image = null;
            this._txtFinalPath.CustomButton.Location = new System.Drawing.Point(455, 1);
            this._txtFinalPath.CustomButton.Name = "";
            this._txtFinalPath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtFinalPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtFinalPath.CustomButton.TabIndex = 1;
            this._txtFinalPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtFinalPath.CustomButton.UseSelectable = true;
            this._txtFinalPath.CustomButton.Visible = false;
            this._txtFinalPath.Enabled = false;
            this._txtFinalPath.Lines = new string[] {
        "/"};
            this._txtFinalPath.Location = new System.Drawing.Point(89, 178);
            this._txtFinalPath.MaxLength = 32767;
            this._txtFinalPath.Name = "_txtFinalPath";
            this._txtFinalPath.PasswordChar = '\0';
            this._txtFinalPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtFinalPath.SelectedText = "";
            this._txtFinalPath.SelectionLength = 0;
            this._txtFinalPath.SelectionStart = 0;
            this._txtFinalPath.ShortcutsEnabled = true;
            this._txtFinalPath.Size = new System.Drawing.Size(477, 23);
            this._txtFinalPath.TabIndex = 2;
            this._txtFinalPath.Text = "/";
            this._txtFinalPath.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtFinalPath.UseSelectable = true;
            this._txtFinalPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtFinalPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this._txtFinalPath.TextChanged += new System.EventHandler(this._txtProjectName_TextChanged);
            this._txtFinalPath.Click += new System.EventHandler(this._txtProjectName_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(13, 114);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(120, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Create In Directory";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(13, 182);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(74, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Project File";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _chkOverwrite
            // 
            this._chkOverwrite.AutoSize = true;
            this._chkOverwrite.Location = new System.Drawing.Point(374, 87);
            this._chkOverwrite.Name = "_chkOverwrite";
            this._chkOverwrite.Size = new System.Drawing.Size(183, 15);
            this._chkOverwrite.TabIndex = 5;
            this._chkOverwrite.Text = "Overwrite Existing Project Files";
            this._chkOverwrite.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._chkOverwrite.UseSelectable = true;
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 290);
            this.Controls.Add(this._chkOverwrite);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._txtFinalPath);
            this.Controls.Add(this._txtProjectName);
            this.Controls.Add(this._lblProjectName);
            this.Controls.Add(this._pnlProjectDir);
            this.Name = "NewProjectForm";
            this.Text = "NewProjectForm";
            this.Load += new System.EventHandler(this.NewProjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _pnlProjectDir;
        private MetroFramework.Controls.MetroLabel _lblProjectName;
        private MetroFramework.Controls.MetroTextBox _txtProjectName;
        private MetroFramework.Controls.MetroButton _btnOk;
        private MetroFramework.Controls.MetroButton _btnCancel;
        private MetroFramework.Controls.MetroTextBox _txtFinalPath;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroCheckBox _chkOverwrite;
    }
}