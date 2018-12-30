namespace Monoedit
{
    partial class CustomMessageBox
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnOkYes = new MetroFramework.Controls.MetroButton();
            this._btnCancelNo = new MetroFramework.Controls.MetroButton();
            this._btnCancel = new MetroFramework.Controls.MetroButton();
            this._txtMessage = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // _btnOkYes
            // 
            this._btnOkYes.Location = new System.Drawing.Point(49, 204);
            this._btnOkYes.Name = "_btnOkYes";
            this._btnOkYes.Size = new System.Drawing.Size(75, 23);
            this._btnOkYes.TabIndex = 2;
            this._btnOkYes.Text = "metroButton1";
            this._btnOkYes.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnOkYes.UseSelectable = true;
            // 
            // _btnCancelNo
            // 
            this._btnCancelNo.Location = new System.Drawing.Point(166, 204);
            this._btnCancelNo.Name = "_btnCancelNo";
            this._btnCancelNo.Size = new System.Drawing.Size(75, 23);
            this._btnCancelNo.TabIndex = 2;
            this._btnCancelNo.Text = "metroButton1";
            this._btnCancelNo.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnCancelNo.UseSelectable = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(293, 204);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 2;
            this._btnCancel.Text = "metroButton1";
            this._btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnCancel.UseSelectable = true;
            // 
            // _txtMessage
            // 
            // 
            // 
            // 
            this._txtMessage.CustomButton.Image = null;
            this._txtMessage.CustomButton.Location = new System.Drawing.Point(247, 1);
            this._txtMessage.CustomButton.Name = "";
            this._txtMessage.CustomButton.Size = new System.Drawing.Size(133, 133);
            this._txtMessage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this._txtMessage.CustomButton.TabIndex = 1;
            this._txtMessage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this._txtMessage.CustomButton.UseSelectable = true;
            this._txtMessage.CustomButton.Visible = false;
            this._txtMessage.Lines = new string[] {
        "metroTextBox1"};
            this._txtMessage.Location = new System.Drawing.Point(23, 63);
            this._txtMessage.MaxLength = 32767;
            this._txtMessage.Multiline = true;
            this._txtMessage.Name = "_txtMessage";
            this._txtMessage.PasswordChar = '\0';
            this._txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._txtMessage.SelectedText = "";
            this._txtMessage.SelectionLength = 0;
            this._txtMessage.SelectionStart = 0;
            this._txtMessage.ShortcutsEnabled = true;
            this._txtMessage.Size = new System.Drawing.Size(381, 135);
            this._txtMessage.TabIndex = 3;
            this._txtMessage.Text = "metroTextBox1";
            this._txtMessage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._txtMessage.UseSelectable = true;
            this._txtMessage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this._txtMessage.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 259);
            this.Controls.Add(this._txtMessage);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnCancelNo);
            this.Controls.Add(this._btnOkYes);
            this.Name = "CustomMessageBox";
            this.Text = "CustomMessageBox";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.CustomMessageBox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton _btnOkYes;
        private MetroFramework.Controls.MetroButton _btnCancelNo;
        private MetroFramework.Controls.MetroButton _btnCancel;
        private MetroFramework.Controls.MetroTextBox _txtMessage;
    }
}