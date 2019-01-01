namespace Monoedit
{
    partial class ProgressWindow
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
            this._lblStatusMsg = new MetroFramework.Controls.MetroLabel();
            this._pbProgress = new MetroFramework.Controls.MetroProgressBar();
            this.SuspendLayout();
            // 
            // _lblStatusMsg
            // 
            this._lblStatusMsg.AutoSize = true;
            this._lblStatusMsg.Location = new System.Drawing.Point(23, 48);
            this._lblStatusMsg.Name = "_lblStatusMsg";
            this._lblStatusMsg.Size = new System.Drawing.Size(81, 19);
            this._lblStatusMsg.TabIndex = 1;
            this._lblStatusMsg.Text = "metroLabel1";
            this._lblStatusMsg.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._lblStatusMsg.Click += new System.EventHandler(this._lblStatusMsg_Click);
            // 
            // _pbProgress
            // 
            this._pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pbProgress.Location = new System.Drawing.Point(23, 22);
            this._pbProgress.Name = "_pbProgress";
            this._pbProgress.Size = new System.Drawing.Size(478, 23);
            this._pbProgress.TabIndex = 2;
            // 
            // ProgressWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 77);
            this.Controls.Add(this._pbProgress);
            this.Controls.Add(this._lblStatusMsg);
            this.DisplayHeader = false;
            this.Name = "ProgressWindow";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ProgressWindow";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.ProgressWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel _lblStatusMsg;
        private MetroFramework.Controls.MetroProgressBar _pbProgress;
    }
}