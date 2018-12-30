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
            this._pbProgress = new System.Windows.Forms.ProgressBar();
            this._lblStatusMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _pbProgress
            // 
            this._pbProgress.Location = new System.Drawing.Point(26, 23);
            this._pbProgress.Maximum = 10000;
            this._pbProgress.Name = "_pbProgress";
            this._pbProgress.Size = new System.Drawing.Size(548, 23);
            this._pbProgress.TabIndex = 0;
            // 
            // _lblStatusMsg
            // 
            this._lblStatusMsg.AutoSize = true;
            this._lblStatusMsg.Location = new System.Drawing.Point(104, 63);
            this._lblStatusMsg.Name = "_lblStatusMsg";
            this._lblStatusMsg.Size = new System.Drawing.Size(35, 13);
            this._lblStatusMsg.TabIndex = 1;
            this._lblStatusMsg.Text = "label1";
            // 
            // ProgressWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 106);
            this.Controls.Add(this._lblStatusMsg);
            this.Controls.Add(this._pbProgress);
            this.Name = "ProgressWindow";
            this.Text = "ProgressWindow";
            this.Load += new System.EventHandler(this.ProgressWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar _pbProgress;
        private System.Windows.Forms.Label _lblStatusMsg;
    }
}