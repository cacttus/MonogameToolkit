namespace Monoedit
{
    partial class TextEditorTab
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
            this._rtbText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _rtbText
            // 
            this._rtbText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rtbText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rtbText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this._rtbText.Location = new System.Drawing.Point(0, 0);
            this._rtbText.Name = "_rtbText";
            this._rtbText.Size = new System.Drawing.Size(479, 329);
            this._rtbText.TabIndex = 0;
            this._rtbText.Text = "";
            this._rtbText.TextChanged += new System.EventHandler(this._rtbText_TextChanged);
            // 
            // TextEditorTab
            // 
            this.Controls.Add(this._rtbText);
            this.Name = "TextEditorTab";
            this.Size = new System.Drawing.Size(479, 329);
            this.Load += new System.EventHandler(this.TextEditorTab_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _rtbTextArea;
    }
}
