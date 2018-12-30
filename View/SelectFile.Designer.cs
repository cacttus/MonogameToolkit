namespace Monoedit
{
    partial class SelectFile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._txtFileLocation = new MetroFramework.Controls.MetroTextBox();
            this._btnOpenFile = new MetroFramework.Controls.MetroButton();
            this._lblError = new MetroFramework.Controls.MetroLabel();
            this._lblInstruction = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // _txtFileLocation
            // 
            this._txtFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this._txtFileLocation.CustomButton.Image = null;
            this._txtFileLocation.CustomButton.Location = new System.Drawing.Point(67, 1);
            this._txtFileLocation.CustomButton.Name = "";
            this._txtFileLocation.CustomButton.Size = new System.Drawing.Size(21, 21);
            this._txtFileLocation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtFileLocation.CustomButton.TabIndex = 1;
            this._txtFileLocation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._txtFileLocation.CustomButton.UseSelectable = true;
            this._txtFileLocation.CustomButton.Visible = false;
            this._txtFileLocation.Lines = new string[0];
            this._txtFileLocation.Location = new System.Drawing.Point(37, 27);
            this._txtFileLocation.MaxLength = 32767;
            this._txtFileLocation.Name = "_txtFileLocation";
            this._txtFileLocation.PasswordChar = '\0';
            this._txtFileLocation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtFileLocation.SelectedText = "";
            this._txtFileLocation.SelectionLength = 0;
            this._txtFileLocation.SelectionStart = 0;
            this._txtFileLocation.ShortcutsEnabled = true;
            this._txtFileLocation.Size = new System.Drawing.Size(178, 23);
            this._txtFileLocation.TabIndex = 1;
            this._txtFileLocation.UseSelectable = true;
            this._txtFileLocation.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtFileLocation.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this._txtFileLocation.TextChanged += new System.EventHandler(this._txtFileLocation_TextChanged);
            this._txtFileLocation.Click += new System.EventHandler(this._txtFileLocation_Click);
            // 
            // _btnOpenFile
            // 

            this._btnOpenFile.Location = new System.Drawing.Point(3, 27);
            this._btnOpenFile.Name = "_btnOpenFile";
            this._btnOpenFile.Size = new System.Drawing.Size(25, 25);
            this._btnOpenFile.TabIndex = 0;
            this._btnOpenFile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnOpenFile.UseSelectable = true;
            this._btnOpenFile.Click += new System.EventHandler(this._btnOpenFile_Click);
            // 
            // _lblError
            // 
            this._lblError.AutoSize = true;
            this._lblError.Location = new System.Drawing.Point(34, 61);
            this._lblError.Name = "_lblError";
            this._lblError.Size = new System.Drawing.Size(15, 19);
            this._lblError.TabIndex = 2;
            this._lblError.Text = "_";
            this._lblError.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _lblInstruction
            // 
            this._lblInstruction.AutoSize = true;
            this._lblInstruction.Location = new System.Drawing.Point(3, 5);
            this._lblInstruction.Name = "_lblInstruction";
            this._lblInstruction.Size = new System.Drawing.Size(15, 19);
            this._lblInstruction.TabIndex = 2;
            this._lblInstruction.Text = "_";
            this._lblInstruction.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // SelectFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this._lblInstruction);
            this.Controls.Add(this._lblError);
            this.Controls.Add(this._txtFileLocation);
            this.Controls.Add(this._btnOpenFile);
            this.Name = "SelectFile";
            this.Size = new System.Drawing.Size(215, 80);
            this.Load += new System.EventHandler(this.SelectFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton _btnOpenFile;
        private MetroFramework.Controls.MetroTextBox _txtFileLocation;
        private MetroFramework.Controls.MetroLabel _lblError;
        private MetroFramework.Controls.MetroLabel _lblInstruction;
    }
}
