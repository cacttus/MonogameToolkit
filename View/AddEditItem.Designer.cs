namespace Monoedit
{
    partial class AddEditItem
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
            this._pnlSpriteListView = new System.Windows.Forms.Panel();
            this._btnAdd = new System.Windows.Forms.Button();
            this._btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _pnlSpriteListView
            // 
            this._pnlSpriteListView.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlSpriteListView.Location = new System.Drawing.Point(0, 0);
            this._pnlSpriteListView.Name = "_pnlSpriteListView";
            this._pnlSpriteListView.Size = new System.Drawing.Size(295, 366);
            this._pnlSpriteListView.TabIndex = 0;
            // 
            // _btnAdd
            // 
            this._btnAdd.Location = new System.Drawing.Point(26, 372);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(75, 23);
            this._btnAdd.TabIndex = 1;
            this._btnAdd.Text = "Add";
            this._btnAdd.UseVisualStyleBackColor = true;
            // 
            // _btnRemove
            // 
            this._btnRemove.Location = new System.Drawing.Point(169, 372);
            this._btnRemove.Name = "_btnRemove";
            this._btnRemove.Size = new System.Drawing.Size(75, 23);
            this._btnRemove.TabIndex = 1;
            this._btnRemove.Text = "Remove";
            this._btnRemove.UseVisualStyleBackColor = true;
            // 
            // AddEditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 406);
            this.Controls.Add(this._btnRemove);
            this.Controls.Add(this._btnAdd);
            this.Controls.Add(this._pnlSpriteListView);
            this.Name = "AddEditItem";
            this.Text = "AddEditItem";
            this.Load += new System.EventHandler(this.AddEditItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _pnlSpriteListView;
        private System.Windows.Forms.Button _btnAdd;
        private System.Windows.Forms.Button _btnRemove;
    }
}