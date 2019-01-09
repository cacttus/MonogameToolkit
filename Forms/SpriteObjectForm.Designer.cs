namespace Monoedit
{
    partial class SpriteObjectForm
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
            this._txtName = new MetroFramework.Controls.MetroTextBox();
            this._lblName = new MetroFramework.Controls.MetroLabel();
            this._btnCancel = new MetroFramework.Controls.MetroButton();
            this._btnApply = new MetroFramework.Controls.MetroButton();
            this._btnOk = new MetroFramework.Controls.MetroButton();
            this._btnEditAnimations = new MetroFramework.Controls.MetroButton();
            this._pbPreview = new System.Windows.Forms.PictureBox();
            this._btnSelectPreview = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this._pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtName.CustomButton.Image = null;
            this._txtName.CustomButton.Location = new System.Drawing.Point(186, 1);
            this._txtName.CustomButton.Name = "";
            this._txtName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtName.CustomButton.TabIndex = 1;
            this._txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtName.CustomButton.UseSelectable = true;
            this._txtName.CustomButton.Visible = false;
            this._txtName.Lines = new string[] {
        "MySpriteObject"};
            this._txtName.Location = new System.Drawing.Point(75, 79);
            this._txtName.MaxLength = 32767;
            this._txtName.Name = "_txtName";
            this._txtName.PasswordChar = '\0';
            this._txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtName.SelectedText = "";
            this._txtName.SelectionLength = 0;
            this._txtName.SelectionStart = 0;
            this._txtName.ShortcutsEnabled = true;
            this._txtName.Size = new System.Drawing.Size(208, 23);
            this._txtName.TabIndex = 0;
            this._txtName.Text = "MySpriteObject";
            this._txtName.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtName.UseSelectable = true;
            this._txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this._txtName.TextChanged += new System.EventHandler(this._txtName_TextChanged);
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(24, 82);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(45, 19);
            this._lblName.TabIndex = 1;
            this._lblName.Text = "Name";
            this._lblName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnCancel.Location = new System.Drawing.Point(187, 238);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnCancel.UseSelectable = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnApply
            // 
            this._btnApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnApply.Location = new System.Drawing.Point(106, 238);
            this._btnApply.Name = "_btnApply";
            this._btnApply.Size = new System.Drawing.Size(75, 23);
            this._btnApply.TabIndex = 7;
            this._btnApply.Text = "Apply";
            this._btnApply.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnApply.UseSelectable = true;
            this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnOk.Location = new System.Drawing.Point(25, 238);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 8;
            this._btnOk.Text = "Ok";
            this._btnOk.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnOk.UseSelectable = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnEditAnimations
            // 
            this._btnEditAnimations.Location = new System.Drawing.Point(146, 141);
            this._btnEditAnimations.Name = "_btnEditAnimations";
            this._btnEditAnimations.Size = new System.Drawing.Size(116, 23);
            this._btnEditAnimations.TabIndex = 6;
            this._btnEditAnimations.Text = "Edit Animations";
            this._btnEditAnimations.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnEditAnimations.UseSelectable = true;
            this._btnEditAnimations.Click += new System.EventHandler(this._btnEditAnimations_Click);
            // 
            // _pbPreview
            // 
            this._pbPreview.Location = new System.Drawing.Point(25, 118);
            this._pbPreview.Name = "_pbPreview";
            this._pbPreview.Size = new System.Drawing.Size(100, 96);
            this._pbPreview.TabIndex = 9;
            this._pbPreview.TabStop = false;
            // 
            // _btnSelectPreview
            // 
            this._btnSelectPreview.Location = new System.Drawing.Point(45, 141);
            this._btnSelectPreview.Name = "_btnSelectPreview";
            this._btnSelectPreview.Size = new System.Drawing.Size(55, 46);
            this._btnSelectPreview.TabIndex = 6;
            this._btnSelectPreview.Text = "Select";
            this._btnSelectPreview.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnSelectPreview.UseSelectable = true;
            this._btnSelectPreview.Click += new System.EventHandler(this._btnSelectPreview_Click);
            // 
            // SpriteObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 284);
            this.Controls.Add(this._btnSelectPreview);
            this.Controls.Add(this._pbPreview);
            this.Controls.Add(this._btnEditAnimations);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnApply);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this._txtName);
            this.Name = "SpriteObjectForm";
            this.Text = "AddEditSpriteObject";
            this.Load += new System.EventHandler(this.AddEditSpriteObject_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox _txtName;
        private MetroFramework.Controls.MetroLabel _lblName;
        private MetroFramework.Controls.MetroButton _btnCancel;
        private MetroFramework.Controls.MetroButton _btnApply;
        private MetroFramework.Controls.MetroButton _btnOk;
        private MetroFramework.Controls.MetroButton _btnEditAnimations;
        private System.Windows.Forms.PictureBox _pbPreview;
        private MetroFramework.Controls.MetroButton _btnSelectPreview;
    }
}