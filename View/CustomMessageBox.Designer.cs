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
            this._btnOkYes = new System.Windows.Forms.Button();
            this._btnCancelNo = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._txtMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _btnOkYes
            // 
            this._btnOkYes.Location = new System.Drawing.Point(32, 186);
            this._btnOkYes.Name = "_btnOkYes";
            this._btnOkYes.Size = new System.Drawing.Size(75, 23);
            this._btnOkYes.TabIndex = 0;
            this._btnOkYes.Text = "button1";
            this._btnOkYes.UseVisualStyleBackColor = true;
            // 
            // _btnCancelNo
            // 
            this._btnCancelNo.Location = new System.Drawing.Point(149, 186);
            this._btnCancelNo.Name = "_btnCancelNo";
            this._btnCancelNo.Size = new System.Drawing.Size(75, 23);
            this._btnCancelNo.TabIndex = 0;
            this._btnCancelNo.Text = "button1";
            this._btnCancelNo.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(276, 186);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 0;
            this._btnCancel.Text = "button1";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _txtMessage
            // 
            this._txtMessage.Location = new System.Drawing.Point(32, 13);
            this._txtMessage.Multiline = true;
            this._txtMessage.Name = "_txtMessage";
            this._txtMessage.Size = new System.Drawing.Size(370, 147);
            this._txtMessage.TabIndex = 1;
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 247);
            this.Controls.Add(this._txtMessage);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnCancelNo);
            this.Controls.Add(this._btnOkYes);
            this.Name = "CustomMessageBox";
            this.Text = "CustomMessageBox";
            this.Load += new System.EventHandler(this.CustomMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnOkYes;
        private System.Windows.Forms.Button _btnCancelNo;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.TextBox _txtMessage;
    }
}