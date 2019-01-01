namespace Monoedit
{
    partial class AddEditImage
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
            this._pbImage = new System.Windows.Forms.PictureBox();
            this._pnlLocation = new System.Windows.Forms.Panel();
            this._optUseSelectedPath = new MetroFramework.Controls.MetroRadioButton();
            this._optCopyToProjectDir = new MetroFramework.Controls.MetroRadioButton();
            this._btnCancel = new MetroFramework.Controls.MetroButton();
            this._btnOk = new MetroFramework.Controls.MetroButton();
            this._btnReload = new MetroFramework.Controls.MetroButton();
            this._txtImagePathPreview = new MetroFramework.Controls.MetroTextBox();
            this._optAtlas = new MetroFramework.Controls.MetroRadioButton();
            this._optImage = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this._txtSpriteWidth = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this._txtSpriteHeight = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox3 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox4 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this._lblImageName = new MetroFramework.Controls.MetroLabel();
            this._txtImageName = new MetroFramework.Controls.MetroTextBox();
            this._lblImageId = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this._pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // _pbImage
            // 
            this._pbImage.Location = new System.Drawing.Point(344, 27);
            this._pbImage.Name = "_pbImage";
            this._pbImage.Size = new System.Drawing.Size(512, 512);
            this._pbImage.TabIndex = 0;
            this._pbImage.TabStop = false;
            // 
            // _pnlLocation
            // 
            this._pnlLocation.Location = new System.Drawing.Point(36, 138);
            this._pnlLocation.Name = "_pnlLocation";
            this._pnlLocation.Size = new System.Drawing.Size(302, 34);
            this._pnlLocation.TabIndex = 1;
            // 
            // _optUseSelectedPath
            // 
            this._optUseSelectedPath.AutoSize = true;
            this._optUseSelectedPath.Location = new System.Drawing.Point(59, 178);
            this._optUseSelectedPath.Name = "_optUseSelectedPath";
            this._optUseSelectedPath.Size = new System.Drawing.Size(116, 15);
            this._optUseSelectedPath.TabIndex = 2;
            this._optUseSelectedPath.Text = "Use Selected Path";
            this._optUseSelectedPath.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._optUseSelectedPath.UseSelectable = true;
            this._optUseSelectedPath.CheckedChanged += new System.EventHandler(this._optUseSelectedPath_CheckedChanged);
            // 
            // _optCopyToProjectDir
            // 
            this._optCopyToProjectDir.AutoSize = true;
            this._optCopyToProjectDir.Checked = true;
            this._optCopyToProjectDir.Location = new System.Drawing.Point(181, 178);
            this._optCopyToProjectDir.Name = "_optCopyToProjectDir";
            this._optCopyToProjectDir.Size = new System.Drawing.Size(125, 15);
            this._optCopyToProjectDir.TabIndex = 3;
            this._optCopyToProjectDir.TabStop = true;
            this._optCopyToProjectDir.Text = "Copy To Project Dir";
            this._optCopyToProjectDir.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._optCopyToProjectDir.UseSelectable = true;
            this._optCopyToProjectDir.CheckedChanged += new System.EventHandler(this._optCopyToProjectDir_CheckedChanged);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnCancel.Location = new System.Drawing.Point(156, 516);
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
            this._btnOk.Location = new System.Drawing.Point(75, 516);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 5;
            this._btnOk.Text = "Ok";
            this._btnOk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnOk.UseSelectable = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnReload
            // 
            this._btnReload.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnReload.Location = new System.Drawing.Point(283, 256);
            this._btnReload.Name = "_btnReload";
            this._btnReload.Size = new System.Drawing.Size(55, 23);
            this._btnReload.TabIndex = 5;
            this._btnReload.Text = "Reload";
            this._btnReload.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnReload.UseSelectable = true;
            this._btnReload.Click += new System.EventHandler(this._btnReload_Click);
            // 
            // _txtImagePathPreview
            // 
            this._txtImagePathPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtImagePathPreview.CustomButton.Image = null;
            this._txtImagePathPreview.CustomButton.Location = new System.Drawing.Point(280, 1);
            this._txtImagePathPreview.CustomButton.Name = "";
            this._txtImagePathPreview.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtImagePathPreview.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtImagePathPreview.CustomButton.TabIndex = 1;
            this._txtImagePathPreview.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._txtImagePathPreview.CustomButton.UseSelectable = true;
            this._txtImagePathPreview.CustomButton.Visible = false;
            this._txtImagePathPreview.Enabled = false;
            this._txtImagePathPreview.Lines = new string[] {
        "/"};
            this._txtImagePathPreview.Location = new System.Drawing.Point(36, 227);
            this._txtImagePathPreview.MaxLength = 32767;
            this._txtImagePathPreview.Name = "_txtImagePathPreview";
            this._txtImagePathPreview.PasswordChar = '\0';
            this._txtImagePathPreview.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtImagePathPreview.SelectedText = "";
            this._txtImagePathPreview.SelectionLength = 0;
            this._txtImagePathPreview.SelectionStart = 0;
            this._txtImagePathPreview.ShortcutsEnabled = true;
            this._txtImagePathPreview.Size = new System.Drawing.Size(302, 23);
            this._txtImagePathPreview.TabIndex = 6;
            this._txtImagePathPreview.Text = "/";
            this._txtImagePathPreview.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtImagePathPreview.UseSelectable = true;
            this._txtImagePathPreview.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtImagePathPreview.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // _optAtlas
            // 
            this._optAtlas.AutoSize = true;
            this._optAtlas.Location = new System.Drawing.Point(99, 296);
            this._optAtlas.Name = "_optAtlas";
            this._optAtlas.Size = new System.Drawing.Size(49, 15);
            this._optAtlas.TabIndex = 2;
            this._optAtlas.Text = "Atlas";
            this._optAtlas.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._optAtlas.UseSelectable = true;
            // 
            // _optImage
            // 
            this._optImage.AutoSize = true;
            this._optImage.Checked = true;
            this._optImage.Location = new System.Drawing.Point(37, 296);
            this._optImage.Name = "_optImage";
            this._optImage.Size = new System.Drawing.Size(56, 15);
            this._optImage.TabIndex = 3;
            this._optImage.TabStop = true;
            this._optImage.Text = "Image";
            this._optImage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._optImage.UseSelectable = true;
            this._optImage.CheckedChanged += new System.EventHandler(this._optImage_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(16, 274);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(77, 19);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Image Type";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(16, 116);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(58, 19);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Location";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(16, 205);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(74, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Actual Path";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _txtSpriteWidth
            // 
            // 
            // 
            // 
            this._txtSpriteWidth.CustomButton.Image = null;
            this._txtSpriteWidth.CustomButton.Location = new System.Drawing.Point(23, 1);
            this._txtSpriteWidth.CustomButton.Name = "";
            this._txtSpriteWidth.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtSpriteWidth.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtSpriteWidth.CustomButton.TabIndex = 1;
            this._txtSpriteWidth.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._txtSpriteWidth.CustomButton.UseSelectable = true;
            this._txtSpriteWidth.CustomButton.Visible = false;
            this._txtSpriteWidth.Lines = new string[] {
        "32"};
            this._txtSpriteWidth.Location = new System.Drawing.Point(116, 359);
            this._txtSpriteWidth.MaxLength = 32767;
            this._txtSpriteWidth.Name = "_txtSpriteWidth";
            this._txtSpriteWidth.PasswordChar = '\0';
            this._txtSpriteWidth.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtSpriteWidth.SelectedText = "";
            this._txtSpriteWidth.SelectionLength = 0;
            this._txtSpriteWidth.SelectionStart = 0;
            this._txtSpriteWidth.ShortcutsEnabled = true;
            this._txtSpriteWidth.Size = new System.Drawing.Size(45, 23);
            this._txtSpriteWidth.TabIndex = 8;
            this._txtSpriteWidth.Text = "32";
            this._txtSpriteWidth.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtSpriteWidth.UseSelectable = true;
            this._txtSpriteWidth.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtSpriteWidth.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(16, 328);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(107, 19);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Atlas Parameters";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // _txtSpriteHeight
            // 
            // 
            // 
            // 
            this._txtSpriteHeight.CustomButton.Image = null;
            this._txtSpriteHeight.CustomButton.Location = new System.Drawing.Point(23, 1);
            this._txtSpriteHeight.CustomButton.Name = "";
            this._txtSpriteHeight.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtSpriteHeight.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtSpriteHeight.CustomButton.TabIndex = 1;
            this._txtSpriteHeight.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._txtSpriteHeight.CustomButton.UseSelectable = true;
            this._txtSpriteHeight.CustomButton.Visible = false;
            this._txtSpriteHeight.Lines = new string[] {
        "32"};
            this._txtSpriteHeight.Location = new System.Drawing.Point(167, 359);
            this._txtSpriteHeight.MaxLength = 32767;
            this._txtSpriteHeight.Name = "_txtSpriteHeight";
            this._txtSpriteHeight.PasswordChar = '\0';
            this._txtSpriteHeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtSpriteHeight.SelectedText = "";
            this._txtSpriteHeight.SelectionLength = 0;
            this._txtSpriteHeight.SelectionStart = 0;
            this._txtSpriteHeight.ShortcutsEnabled = true;
            this._txtSpriteHeight.Size = new System.Drawing.Size(45, 23);
            this._txtSpriteHeight.TabIndex = 8;
            this._txtSpriteHeight.Text = "32";
            this._txtSpriteHeight.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtSpriteHeight.UseSelectable = true;
            this._txtSpriteHeight.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtSpriteHeight.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(44, 359);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(70, 19);
            this.metroLabel5.TabIndex = 7;
            this.metroLabel5.Text = "Sprite Size";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel5.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(59, 388);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(51, 19);
            this.metroLabel7.TabIndex = 7;
            this.metroLabel7.Text = "Margin";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel7.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(23, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[] {
        "1"};
            this.metroTextBox1.Location = new System.Drawing.Point(116, 388);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(45, 23);
            this.metroTextBox1.TabIndex = 8;
            this.metroTextBox1.Text = "1";
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(23, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[] {
        "1"};
            this.metroTextBox2.Location = new System.Drawing.Point(167, 388);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(45, 23);
            this.metroTextBox2.TabIndex = 8;
            this.metroTextBox2.Text = "1";
            this.metroTextBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(59, 417);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(55, 19);
            this.metroLabel6.TabIndex = 7;
            this.metroLabel6.Text = "Spacing";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel6.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // metroTextBox3
            // 
            // 
            // 
            // 
            this.metroTextBox3.CustomButton.Image = null;
            this.metroTextBox3.CustomButton.Location = new System.Drawing.Point(23, 1);
            this.metroTextBox3.CustomButton.Name = "";
            this.metroTextBox3.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox3.CustomButton.TabIndex = 1;
            this.metroTextBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox3.CustomButton.UseSelectable = true;
            this.metroTextBox3.CustomButton.Visible = false;
            this.metroTextBox3.Lines = new string[] {
        "1"};
            this.metroTextBox3.Location = new System.Drawing.Point(116, 417);
            this.metroTextBox3.MaxLength = 32767;
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.PasswordChar = '\0';
            this.metroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox3.SelectedText = "";
            this.metroTextBox3.SelectionLength = 0;
            this.metroTextBox3.SelectionStart = 0;
            this.metroTextBox3.ShortcutsEnabled = true;
            this.metroTextBox3.Size = new System.Drawing.Size(45, 23);
            this.metroTextBox3.TabIndex = 8;
            this.metroTextBox3.Text = "1";
            this.metroTextBox3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox3.UseSelectable = true;
            this.metroTextBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox4
            // 
            // 
            // 
            // 
            this.metroTextBox4.CustomButton.Image = null;
            this.metroTextBox4.CustomButton.Location = new System.Drawing.Point(23, 1);
            this.metroTextBox4.CustomButton.Name = "";
            this.metroTextBox4.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox4.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox4.CustomButton.TabIndex = 1;
            this.metroTextBox4.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox4.CustomButton.UseSelectable = true;
            this.metroTextBox4.CustomButton.Visible = false;
            this.metroTextBox4.Lines = new string[] {
        "1"};
            this.metroTextBox4.Location = new System.Drawing.Point(167, 417);
            this.metroTextBox4.MaxLength = 32767;
            this.metroTextBox4.Name = "metroTextBox4";
            this.metroTextBox4.PasswordChar = '\0';
            this.metroTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox4.SelectedText = "";
            this.metroTextBox4.SelectionLength = 0;
            this.metroTextBox4.SelectionStart = 0;
            this.metroTextBox4.ShortcutsEnabled = true;
            this.metroTextBox4.Size = new System.Drawing.Size(45, 23);
            this.metroTextBox4.TabIndex = 8;
            this.metroTextBox4.Text = "1";
            this.metroTextBox4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox4.UseSelectable = true;
            this.metroTextBox4.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox4.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(210, 362);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(23, 19);
            this.metroLabel8.TabIndex = 7;
            this.metroLabel8.Text = "px";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel8.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(210, 391);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(23, 19);
            this.metroLabel9.TabIndex = 7;
            this.metroLabel9.Text = "px";
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel9.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(210, 420);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(23, 19);
            this.metroLabel10.TabIndex = 7;
            this.metroLabel10.Text = "px";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel10.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // _lblImageName
            // 
            this._lblImageName.AutoSize = true;
            this._lblImageName.Location = new System.Drawing.Point(16, 60);
            this._lblImageName.Name = "_lblImageName";
            this._lblImageName.Size = new System.Drawing.Size(45, 19);
            this._lblImageName.TabIndex = 7;
            this._lblImageName.Text = "Name";
            this._lblImageName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _txtImageName
            // 
            this._txtImageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtImageName.CustomButton.Image = null;
            this._txtImageName.CustomButton.Location = new System.Drawing.Point(280, 1);
            this._txtImageName.CustomButton.Name = "";
            this._txtImageName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtImageName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtImageName.CustomButton.TabIndex = 1;
            this._txtImageName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._txtImageName.CustomButton.UseSelectable = true;
            this._txtImageName.CustomButton.Visible = false;
            this._txtImageName.Enabled = false;
            this._txtImageName.Lines = new string[] {
        "MyImage"};
            this._txtImageName.Location = new System.Drawing.Point(36, 82);
            this._txtImageName.MaxLength = 32767;
            this._txtImageName.Name = "_txtImageName";
            this._txtImageName.PasswordChar = '\0';
            this._txtImageName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtImageName.SelectedText = "";
            this._txtImageName.SelectionLength = 0;
            this._txtImageName.SelectionStart = 0;
            this._txtImageName.ShortcutsEnabled = true;
            this._txtImageName.Size = new System.Drawing.Size(302, 23);
            this._txtImageName.TabIndex = 6;
            this._txtImageName.Text = "MyImage";
            this._txtImageName.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtImageName.UseSelectable = true;
            this._txtImageName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtImageName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // _lblImageId
            // 
            this._lblImageId.AutoSize = true;
            this._lblImageId.Location = new System.Drawing.Point(269, 116);
            this._lblImageId.Name = "_lblImageId";
            this._lblImageId.Size = new System.Drawing.Size(38, 19);
            this._lblImageId.TabIndex = 9;
            this._lblImageId.Text = "(Id:0)";
            this._lblImageId.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // AddEditImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 562);
            this.Controls.Add(this._lblImageId);
            this.Controls.Add(this.metroTextBox4);
            this.Controls.Add(this.metroTextBox2);
            this.Controls.Add(this._txtSpriteHeight);
            this.Controls.Add(this.metroTextBox3);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this._txtSpriteWidth);
            this.Controls.Add(this._lblImageName);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this._txtImageName);
            this.Controls.Add(this._txtImagePathPreview);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnReload);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._optImage);
            this.Controls.Add(this._optCopyToProjectDir);
            this.Controls.Add(this._optAtlas);
            this.Controls.Add(this._optUseSelectedPath);
            this.Controls.Add(this._pnlLocation);
            this.Controls.Add(this._pbImage);
            this.Name = "AddEditImage";
            this.Text = "Add/Edit Image";
            this.Load += new System.EventHandler(this.AddEditImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pbImage;
        private System.Windows.Forms.Panel _pnlLocation;
        private MetroFramework.Controls.MetroRadioButton _optUseSelectedPath;
        private MetroFramework.Controls.MetroRadioButton _optCopyToProjectDir;
        private MetroFramework.Controls.MetroButton _btnCancel;
        private MetroFramework.Controls.MetroButton _btnOk;
        private MetroFramework.Controls.MetroButton _btnReload;
        private MetroFramework.Controls.MetroTextBox _txtImagePathPreview;
        private MetroFramework.Controls.MetroRadioButton _optAtlas;
        private MetroFramework.Controls.MetroRadioButton _optImage;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox _txtSpriteWidth;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox _txtSpriteHeight;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox metroTextBox3;
        private MetroFramework.Controls.MetroTextBox metroTextBox4;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel _lblImageName;
        private MetroFramework.Controls.MetroTextBox _txtImageName;
        private MetroFramework.Controls.MetroLabel _lblImageId;
    }
}