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
            this._btnCancel = new MetroFramework.Controls.MetroButton();
            this._btnOk = new MetroFramework.Controls.MetroButton();
            this._btnReload = new MetroFramework.Controls.MetroButton();
            this._txtActualPath = new MetroFramework.Controls.MetroTextBox();
            this._optAtlas = new MetroFramework.Controls.MetroRadioButton();
            this._optImage = new MetroFramework.Controls.MetroRadioButton();
            this._lblImageType = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this._lblProjectPath = new MetroFramework.Controls.MetroLabel();
            this._txtTileWidth = new MetroFramework.Controls.MetroTextBox();
            this._txtTileHeight = new MetroFramework.Controls.MetroTextBox();
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
            this._gbpAtlasParameters = new System.Windows.Forms.GroupBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this._lblAtlasParameters = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            ((System.ComponentModel.ISupportInitialize)(this._pbImage)).BeginInit();
            this._gbpAtlasParameters.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pbImage
            // 
            this._pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._pbImage.Location = new System.Drawing.Point(344, 27);
            this._pbImage.Name = "_pbImage";
            this._pbImage.Size = new System.Drawing.Size(512, 512);
            this._pbImage.TabIndex = 0;
            this._pbImage.TabStop = false;
            // 
            // _pnlLocation
            // 
            this._pnlLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlLocation.Location = new System.Drawing.Point(36, 138);
            this._pnlLocation.Name = "_pnlLocation";
            this._pnlLocation.Size = new System.Drawing.Size(302, 34);
            this._pnlLocation.TabIndex = 1;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(156, 511);
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
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnOk.Location = new System.Drawing.Point(75, 511);
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
            this._btnReload.Location = new System.Drawing.Point(283, 236);
            this._btnReload.Name = "_btnReload";
            this._btnReload.Size = new System.Drawing.Size(55, 23);
            this._btnReload.TabIndex = 5;
            this._btnReload.Text = "Reload";
            this._btnReload.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnReload.UseSelectable = true;
            this._btnReload.Click += new System.EventHandler(this._btnReload_Click);
            // 
            // _txtActualPath
            // 
            this._txtActualPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtActualPath.CustomButton.Image = null;
            this._txtActualPath.CustomButton.Location = new System.Drawing.Point(280, 1);
            this._txtActualPath.CustomButton.Name = "";
            this._txtActualPath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtActualPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtActualPath.CustomButton.TabIndex = 1;
            this._txtActualPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtActualPath.CustomButton.UseSelectable = true;
            this._txtActualPath.CustomButton.Visible = false;
            this._txtActualPath.Enabled = false;
            this._txtActualPath.Lines = new string[] {
        "/"};
            this._txtActualPath.Location = new System.Drawing.Point(36, 207);
            this._txtActualPath.MaxLength = 32767;
            this._txtActualPath.Name = "_txtActualPath";
            this._txtActualPath.PasswordChar = '\0';
            this._txtActualPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtActualPath.SelectedText = "";
            this._txtActualPath.SelectionLength = 0;
            this._txtActualPath.SelectionStart = 0;
            this._txtActualPath.ShortcutsEnabled = true;
            this._txtActualPath.Size = new System.Drawing.Size(302, 23);
            this._txtActualPath.TabIndex = 6;
            this._txtActualPath.Text = "/";
            this._txtActualPath.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtActualPath.UseSelectable = true;
            this._txtActualPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtActualPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // _optAtlas
            // 
            this._optAtlas.AutoSize = true;
            this._optAtlas.Location = new System.Drawing.Point(65, 3);
            this._optAtlas.Name = "_optAtlas";
            this._optAtlas.Size = new System.Drawing.Size(49, 15);
            this._optAtlas.TabIndex = 2;
            this._optAtlas.Text = "Atlas";
            this._optAtlas.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._optAtlas.UseSelectable = true;
            this._optAtlas.CheckedChanged += new System.EventHandler(this._optAtlas_CheckedChanged);
            // 
            // _optImage
            // 
            this._optImage.AutoSize = true;
            this._optImage.Checked = true;
            this._optImage.Location = new System.Drawing.Point(3, 3);
            this._optImage.Name = "_optImage";
            this._optImage.Size = new System.Drawing.Size(56, 15);
            this._optImage.TabIndex = 3;
            this._optImage.TabStop = true;
            this._optImage.Text = "Image";
            this._optImage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._optImage.UseSelectable = true;
            this._optImage.CheckedChanged += new System.EventHandler(this._optImage_CheckedChanged);
            // 
            // _lblImageType
            // 
            this._lblImageType.AutoSize = true;
            this._lblImageType.Location = new System.Drawing.Point(16, 254);
            this._lblImageType.Name = "_lblImageType";
            this._lblImageType.Size = new System.Drawing.Size(77, 19);
            this._lblImageType.TabIndex = 7;
            this._lblImageType.Text = "Image Type";
            this._lblImageType.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(16, 116);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(99, 19);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Image Location";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _lblProjectPath
            // 
            this._lblProjectPath.AutoSize = true;
            this._lblProjectPath.Location = new System.Drawing.Point(16, 185);
            this._lblProjectPath.Name = "_lblProjectPath";
            this._lblProjectPath.Size = new System.Drawing.Size(79, 19);
            this._lblProjectPath.TabIndex = 7;
            this._lblProjectPath.Text = "Project Path";
            this._lblProjectPath.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _txtTileWidth
            // 
            // 
            // 
            // 
            this._txtTileWidth.CustomButton.Image = null;
            this._txtTileWidth.CustomButton.Location = new System.Drawing.Point(23, 1);
            this._txtTileWidth.CustomButton.Name = "";
            this._txtTileWidth.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtTileWidth.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtTileWidth.CustomButton.TabIndex = 1;
            this._txtTileWidth.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtTileWidth.CustomButton.UseSelectable = true;
            this._txtTileWidth.CustomButton.Visible = false;
            this._txtTileWidth.Lines = new string[] {
        "32"};
            this._txtTileWidth.Location = new System.Drawing.Point(96, 32);
            this._txtTileWidth.MaxLength = 32767;
            this._txtTileWidth.Name = "_txtTileWidth";
            this._txtTileWidth.PasswordChar = '\0';
            this._txtTileWidth.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtTileWidth.SelectedText = "";
            this._txtTileWidth.SelectionLength = 0;
            this._txtTileWidth.SelectionStart = 0;
            this._txtTileWidth.ShortcutsEnabled = true;
            this._txtTileWidth.Size = new System.Drawing.Size(45, 23);
            this._txtTileWidth.TabIndex = 8;
            this._txtTileWidth.Text = "32";
            this._txtTileWidth.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtTileWidth.UseSelectable = true;
            this._txtTileWidth.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtTileWidth.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // _txtTileHeight
            // 
            // 
            // 
            // 
            this._txtTileHeight.CustomButton.Image = null;
            this._txtTileHeight.CustomButton.Location = new System.Drawing.Point(23, 1);
            this._txtTileHeight.CustomButton.Name = "";
            this._txtTileHeight.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtTileHeight.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtTileHeight.CustomButton.TabIndex = 1;
            this._txtTileHeight.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtTileHeight.CustomButton.UseSelectable = true;
            this._txtTileHeight.CustomButton.Visible = false;
            this._txtTileHeight.Lines = new string[] {
        "32"};
            this._txtTileHeight.Location = new System.Drawing.Point(158, 32);
            this._txtTileHeight.MaxLength = 32767;
            this._txtTileHeight.Name = "_txtTileHeight";
            this._txtTileHeight.PasswordChar = '\0';
            this._txtTileHeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtTileHeight.SelectedText = "";
            this._txtTileHeight.SelectionLength = 0;
            this._txtTileHeight.SelectionStart = 0;
            this._txtTileHeight.ShortcutsEnabled = true;
            this._txtTileHeight.Size = new System.Drawing.Size(45, 23);
            this._txtTileHeight.TabIndex = 8;
            this._txtTileHeight.Text = "32";
            this._txtTileHeight.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtTileHeight.UseSelectable = true;
            this._txtTileHeight.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtTileHeight.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(11, 32);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(56, 19);
            this.metroLabel5.TabIndex = 7;
            this.metroLabel5.Text = "Tile Size";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(11, 61);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(51, 19);
            this.metroLabel7.TabIndex = 7;
            this.metroLabel7.Text = "Margin";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
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
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[] {
        "1"};
            this.metroTextBox1.Location = new System.Drawing.Point(96, 61);
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
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[] {
        "1"};
            this.metroTextBox2.Location = new System.Drawing.Point(158, 61);
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
            this.metroLabel6.Location = new System.Drawing.Point(11, 90);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(55, 19);
            this.metroLabel6.TabIndex = 7;
            this.metroLabel6.Text = "Spacing";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
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
            this.metroTextBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox3.CustomButton.UseSelectable = true;
            this.metroTextBox3.CustomButton.Visible = false;
            this.metroTextBox3.Lines = new string[] {
        "1"};
            this.metroTextBox3.Location = new System.Drawing.Point(96, 90);
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
            this.metroTextBox4.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox4.CustomButton.UseSelectable = true;
            this.metroTextBox4.CustomButton.Visible = false;
            this.metroTextBox4.Lines = new string[] {
        "1"};
            this.metroTextBox4.Location = new System.Drawing.Point(158, 90);
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
            this.metroLabel8.Location = new System.Drawing.Point(142, 36);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(15, 19);
            this.metroLabel8.TabIndex = 7;
            this.metroLabel8.Text = "x";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(142, 65);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(15, 19);
            this.metroLabel9.TabIndex = 7;
            this.metroLabel9.Text = "x";
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(142, 94);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(15, 19);
            this.metroLabel10.TabIndex = 7;
            this.metroLabel10.Text = "x";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
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
            this._txtImageName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtImageName.CustomButton.UseSelectable = true;
            this._txtImageName.CustomButton.Visible = false;
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
            // _gbpAtlasParameters
            // 
            this._gbpAtlasParameters.Controls.Add(this._txtTileWidth);
            this._gbpAtlasParameters.Controls.Add(this.metroLabel5);
            this._gbpAtlasParameters.Controls.Add(this.metroTextBox4);
            this._gbpAtlasParameters.Controls.Add(this.metroLabel12);
            this._gbpAtlasParameters.Controls.Add(this.metroLabel8);
            this._gbpAtlasParameters.Controls.Add(this.metroLabel11);
            this._gbpAtlasParameters.Controls.Add(this.metroTextBox2);
            this._gbpAtlasParameters.Controls.Add(this.metroLabel9);
            this._gbpAtlasParameters.Controls.Add(this.metroLabel4);
            this._gbpAtlasParameters.Controls.Add(this._txtTileHeight);
            this._gbpAtlasParameters.Controls.Add(this.metroLabel10);
            this._gbpAtlasParameters.Controls.Add(this.metroTextBox3);
            this._gbpAtlasParameters.Controls.Add(this.metroLabel7);
            this._gbpAtlasParameters.Controls.Add(this.metroTextBox1);
            this._gbpAtlasParameters.Controls.Add(this.metroLabel6);
            this._gbpAtlasParameters.ForeColor = System.Drawing.SystemColors.ControlText;
            this._gbpAtlasParameters.Location = new System.Drawing.Point(37, 332);
            this._gbpAtlasParameters.Name = "_gbpAtlasParameters";
            this._gbpAtlasParameters.Size = new System.Drawing.Size(249, 135);
            this._gbpAtlasParameters.TabIndex = 10;
            this._gbpAtlasParameters.TabStop = false;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(204, 37);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(23, 19);
            this.metroLabel12.TabIndex = 7;
            this.metroLabel12.Text = "px";
            this.metroLabel12.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(204, 66);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(23, 19);
            this.metroLabel11.TabIndex = 7;
            this.metroLabel11.Text = "px";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(204, 95);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(23, 19);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "px";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _lblAtlasParameters
            // 
            this._lblAtlasParameters.AutoSize = true;
            this._lblAtlasParameters.Location = new System.Drawing.Point(16, 310);
            this._lblAtlasParameters.Name = "_lblAtlasParameters";
            this._lblAtlasParameters.Size = new System.Drawing.Size(107, 19);
            this._lblAtlasParameters.TabIndex = 7;
            this._lblAtlasParameters.Text = "Atlas Parameters";
            this._lblAtlasParameters.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this._optImage);
            this.metroPanel2.Controls.Add(this._optAtlas);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(36, 276);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(302, 21);
            this.metroPanel2.TabIndex = 13;
            this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // AddEditImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 557);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this._gbpAtlasParameters);
            this.Controls.Add(this._lblImageId);
            this.Controls.Add(this._lblImageName);
            this.Controls.Add(this._lblProjectPath);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this._lblAtlasParameters);
            this.Controls.Add(this._lblImageType);
            this.Controls.Add(this._txtImageName);
            this.Controls.Add(this._txtActualPath);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnReload);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._pnlLocation);
            this.Controls.Add(this._pbImage);
            this.Name = "AddEditImage";
            this.Text = "Add/Edit Image";
            this.Load += new System.EventHandler(this.AddEditImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pbImage)).EndInit();
            this._gbpAtlasParameters.ResumeLayout(false);
            this._gbpAtlasParameters.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pbImage;
        private System.Windows.Forms.Panel _pnlLocation;
        private MetroFramework.Controls.MetroButton _btnCancel;
        private MetroFramework.Controls.MetroButton _btnOk;
        private MetroFramework.Controls.MetroButton _btnReload;
        private MetroFramework.Controls.MetroTextBox _txtActualPath;
        private MetroFramework.Controls.MetroRadioButton _optAtlas;
        private MetroFramework.Controls.MetroRadioButton _optImage;
        private MetroFramework.Controls.MetroLabel _lblImageType;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel _lblProjectPath;
        private MetroFramework.Controls.MetroTextBox _txtTileWidth;
        private MetroFramework.Controls.MetroTextBox _txtTileHeight;
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
        private System.Windows.Forms.GroupBox _gbpAtlasParameters;
        private MetroFramework.Controls.MetroLabel _lblAtlasParameters;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}