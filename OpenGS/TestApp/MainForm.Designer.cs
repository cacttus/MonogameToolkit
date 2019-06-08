namespace TestApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._pnlScene1 = new System.Windows.Forms.Panel();
            this._txtErrors = new System.Windows.Forms.TextBox();
            this._txtShaderLog = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._btnPause1 = new System.Windows.Forms.Button();
            this._pnlScene2 = new System.Windows.Forms.Panel();
            this._btnPause2 = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this._btnLoadModel = new System.Windows.Forms.Button();
            this._btnLoadImage = new System.Windows.Forms.Button();
            this._pbLoaded = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbLoaded)).BeginInit();
            this.SuspendLayout();
            // 
            // _pnlScene1
            // 
            this._pnlScene1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._pnlScene1.Location = new System.Drawing.Point(12, 12);
            this._pnlScene1.Name = "_pnlScene1";
            this._pnlScene1.Size = new System.Drawing.Size(354, 231);
            this._pnlScene1.TabIndex = 0;
            this._pnlScene1.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlScene_Paint);
            // 
            // _txtErrors
            // 
            this._txtErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtErrors.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtErrors.Location = new System.Drawing.Point(3, 3);
            this._txtErrors.Multiline = true;
            this._txtErrors.Name = "_txtErrors";
            this._txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtErrors.Size = new System.Drawing.Size(706, 242);
            this._txtErrors.TabIndex = 1;
            this._txtErrors.Text = "Error/Info";
            // 
            // _txtShaderLog
            // 
            this._txtShaderLog.BackColor = System.Drawing.Color.Black;
            this._txtShaderLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtShaderLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtShaderLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._txtShaderLog.Location = new System.Drawing.Point(3, 3);
            this._txtShaderLog.Multiline = true;
            this._txtShaderLog.Name = "_txtShaderLog";
            this._txtShaderLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtShaderLog.Size = new System.Drawing.Size(706, 242);
            this._txtShaderLog.TabIndex = 1;
            this._txtShaderLog.Text = "Shader";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 328);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 274);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._txtErrors);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(712, 248);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this._txtShaderLog);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(712, 248);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Shader";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _btnPause1
            // 
            this._btnPause1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnPause1.Location = new System.Drawing.Point(266, 249);
            this._btnPause1.Name = "_btnPause1";
            this._btnPause1.Size = new System.Drawing.Size(61, 20);
            this._btnPause1.TabIndex = 3;
            this._btnPause1.Text = "Pause";
            this._btnPause1.UseVisualStyleBackColor = true;
            this._btnPause1.Click += new System.EventHandler(this._btnPause1_Click);
            // 
            // _pnlScene2
            // 
            this._pnlScene2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlScene2.Location = new System.Drawing.Point(386, 12);
            this._pnlScene2.Name = "_pnlScene2";
            this._pnlScene2.Size = new System.Drawing.Size(322, 231);
            this._pnlScene2.TabIndex = 0;
            this._pnlScene2.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlScene_Paint);
            // 
            // _btnPause2
            // 
            this._btnPause2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPause2.Location = new System.Drawing.Point(599, 249);
            this._btnPause2.Name = "_btnPause2";
            this._btnPause2.Size = new System.Drawing.Size(62, 20);
            this._btnPause2.TabIndex = 3;
            this._btnPause2.Text = "Pause";
            this._btnPause2.UseVisualStyleBackColor = true;
            this._btnPause2.Click += new System.EventHandler(this._btnPause2_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.Location = new System.Drawing.Point(419, 249);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(174, 45);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.TabStop = false;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Value = 25;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // _btnLoadModel
            // 
            this._btnLoadModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnLoadModel.Location = new System.Drawing.Point(667, 249);
            this._btnLoadModel.Name = "_btnLoadModel";
            this._btnLoadModel.Size = new System.Drawing.Size(41, 20);
            this._btnLoadModel.TabIndex = 3;
            this._btnLoadModel.Text = "...";
            this._btnLoadModel.UseVisualStyleBackColor = true;
            this._btnLoadModel.Click += new System.EventHandler(this._btnLoadModel_Click);
            // 
            // _btnLoadImage
            // 
            this._btnLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnLoadImage.Location = new System.Drawing.Point(333, 249);
            this._btnLoadImage.Name = "_btnLoadImage";
            this._btnLoadImage.Size = new System.Drawing.Size(33, 20);
            this._btnLoadImage.TabIndex = 3;
            this._btnLoadImage.Text = "...";
            this._btnLoadImage.UseVisualStyleBackColor = true;
            this._btnLoadImage.Click += new System.EventHandler(this._btnLoadImage_Click);
            // 
            // _pbLoaded
            // 
            this._pbLoaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._pbLoaded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pbLoaded.Image = ((System.Drawing.Image)(resources.GetObject("_pbLoaded.Image")));
            this._pbLoaded.Location = new System.Drawing.Point(12, 249);
            this._pbLoaded.Name = "_pbLoaded";
            this._pbLoaded.Size = new System.Drawing.Size(45, 45);
            this._pbLoaded.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._pbLoaded.TabIndex = 5;
            this._pbLoaded.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 602);
            this.Controls.Add(this._pbLoaded);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this._btnLoadImage);
            this.Controls.Add(this._btnLoadModel);
            this.Controls.Add(this._btnPause2);
            this.Controls.Add(this._btnPause1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this._pnlScene2);
            this.Controls.Add(this._pnlScene1);
            this.Name = "MainForm";
            this.Text = "Test App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbLoaded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _pnlScene1;
        private System.Windows.Forms.TextBox _txtErrors;
        private System.Windows.Forms.TextBox _txtShaderLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button _btnPause1;
        private System.Windows.Forms.Panel _pnlScene2;
        private System.Windows.Forms.Button _btnPause2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button _btnLoadModel;
        private System.Windows.Forms.Button _btnLoadImage;
        private System.Windows.Forms.PictureBox _pbLoaded;
    }
}

