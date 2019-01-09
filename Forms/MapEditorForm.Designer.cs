namespace Monoedit
{
    partial class MapEditorForm
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
            this._pbEditor = new System.Windows.Forms.PictureBox();
            this._mnuMenu = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pnlToolbar = new MetroFramework.Controls.MetroPanel();
            this._btnPaintbrush = new MetroFramework.Controls.MetroButton();
            this._lsvObjects = new MetroFramework.Controls.MetroListView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this._pbEditor)).BeginInit();
            this._mnuMenu.SuspendLayout();
            this._pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pbEditor
            // 
            this._pbEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pbEditor.Location = new System.Drawing.Point(73, 99);
            this._pbEditor.Name = "_pbEditor";
            this._pbEditor.Size = new System.Drawing.Size(537, 393);
            this._pbEditor.TabIndex = 0;
            this._pbEditor.TabStop = false;
            // 
            // _mnuMenu
            // 
            this._mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._mnuMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this._mnuMenu.Location = new System.Drawing.Point(20, 60);
            this._mnuMenu.Name = "_mnuMenu";
            this._mnuMenu.Size = new System.Drawing.Size(720, 24);
            this._mnuMenu.TabIndex = 6;
            this._mnuMenu.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.undoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.redoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // _pnlToolbar
            // 
            this._pnlToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._pnlToolbar.Controls.Add(this._btnPaintbrush);
            this._pnlToolbar.HorizontalScrollbarBarColor = true;
            this._pnlToolbar.HorizontalScrollbarHighlightOnWheel = false;
            this._pnlToolbar.HorizontalScrollbarSize = 10;
            this._pnlToolbar.Location = new System.Drawing.Point(26, 99);
            this._pnlToolbar.Name = "_pnlToolbar";
            this._pnlToolbar.Size = new System.Drawing.Size(41, 393);
            this._pnlToolbar.TabIndex = 7;
            this._pnlToolbar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._pnlToolbar.VerticalScrollbarBarColor = true;
            this._pnlToolbar.VerticalScrollbarHighlightOnWheel = false;
            this._pnlToolbar.VerticalScrollbarSize = 10;
            // 
            // _btnPaintbrush
            // 
            this._btnPaintbrush.Location = new System.Drawing.Point(4, 4);
            this._btnPaintbrush.Name = "_btnPaintbrush";
            this._btnPaintbrush.Size = new System.Drawing.Size(32, 32);
            this._btnPaintbrush.TabIndex = 2;
            this._btnPaintbrush.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnPaintbrush.UseSelectable = true;
            // 
            // _lsvObjects
            // 
            this._lsvObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lsvObjects.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._lsvObjects.FullRowSelect = true;
            this._lsvObjects.Location = new System.Drawing.Point(616, 121);
            this._lsvObjects.Name = "_lsvObjects";
            this._lsvObjects.OwnerDraw = true;
            this._lsvObjects.Size = new System.Drawing.Size(121, 150);
            this._lsvObjects.TabIndex = 8;
            this._lsvObjects.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._lsvObjects.UseCompatibleStateImageBehavior = false;
            this._lsvObjects.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(649, 99);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(53, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Objects";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 515);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this._lsvObjects);
            this.Controls.Add(this._pnlToolbar);
            this.Controls.Add(this._mnuMenu);
            this.Controls.Add(this._pbEditor);
            this.Name = "MapEditorForm";
            this.Text = "Map Editor";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this._pbEditor)).EndInit();
            this._mnuMenu.ResumeLayout(false);
            this._mnuMenu.PerformLayout();
            this._pnlToolbar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pbEditor;
        private System.Windows.Forms.MenuStrip _mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel _pnlToolbar;
        private MetroFramework.Controls.MetroButton _btnPaintbrush;
        private MetroFramework.Controls.MetroListView _lsvObjects;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}