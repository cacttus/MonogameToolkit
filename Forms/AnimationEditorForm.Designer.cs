using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Monoedit
{
    partial class AnimationEditorForm
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
            this._pnlTimeline = new MetroFramework.Controls.MetroPanel();
            this._lblFrameNumber = new MetroFramework.Controls.MetroLabel();
            this._pnlFrameEnd = new MetroFramework.Controls.MetroPanel();
            this._pnlFrameStart = new MetroFramework.Controls.MetroPanel();
            this._btnPlay = new MetroFramework.Controls.MetroButton();
            this._btnAddKey = new MetroFramework.Controls.MetroButton();
            this._tbKeyframes = new MetroFramework.Controls.MetroTrackBar();
            this._pbEditor = new System.Windows.Forms.PictureBox();
            this._lsvSpriteComponents = new MetroFramework.Controls.MetroListView();
            this._pnlToolbar = new MetroFramework.Controls.MetroPanel();
            this._btnAddSprite = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this._mnuMenu = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pnlTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pbEditor)).BeginInit();
            this._pnlToolbar.SuspendLayout();
            this._mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlTimeline
            // 
            this._pnlTimeline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlTimeline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlTimeline.Controls.Add(this._lblFrameNumber);
            this._pnlTimeline.Controls.Add(this._pnlFrameEnd);
            this._pnlTimeline.Controls.Add(this._pnlFrameStart);
            this._pnlTimeline.Controls.Add(this._btnPlay);
            this._pnlTimeline.Controls.Add(this._btnAddKey);
            this._pnlTimeline.Controls.Add(this._tbKeyframes);
            this._pnlTimeline.HorizontalScrollbarBarColor = true;
            this._pnlTimeline.HorizontalScrollbarHighlightOnWheel = false;
            this._pnlTimeline.HorizontalScrollbarSize = 10;
            this._pnlTimeline.Location = new System.Drawing.Point(23, 486);
            this._pnlTimeline.Name = "_pnlTimeline";
            this._pnlTimeline.Size = new System.Drawing.Size(930, 73);
            this._pnlTimeline.TabIndex = 0;
            this._pnlTimeline.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._pnlTimeline.VerticalScrollbarBarColor = true;
            this._pnlTimeline.VerticalScrollbarHighlightOnWheel = false;
            this._pnlTimeline.VerticalScrollbarSize = 10;
            // 
            // _lblFrameNumber
            // 
            this._lblFrameNumber.AutoSize = true;
            this._lblFrameNumber.Location = new System.Drawing.Point(6, 9);
            this._lblFrameNumber.Name = "_lblFrameNumber";
            this._lblFrameNumber.Size = new System.Drawing.Size(14, 19);
            this._lblFrameNumber.TabIndex = 5;
            this._lblFrameNumber.Text = "1";
            this._lblFrameNumber.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _pnlFrameEnd
            // 
            this._pnlFrameEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlFrameEnd.HorizontalScrollbarBarColor = true;
            this._pnlFrameEnd.HorizontalScrollbarHighlightOnWheel = false;
            this._pnlFrameEnd.HorizontalScrollbarSize = 10;
            this._pnlFrameEnd.Location = new System.Drawing.Point(860, 41);
            this._pnlFrameEnd.Name = "_pnlFrameEnd";
            this._pnlFrameEnd.Size = new System.Drawing.Size(45, 18);
            this._pnlFrameEnd.TabIndex = 4;
            this._pnlFrameEnd.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._pnlFrameEnd.VerticalScrollbarBarColor = true;
            this._pnlFrameEnd.VerticalScrollbarHighlightOnWheel = false;
            this._pnlFrameEnd.VerticalScrollbarSize = 10;
            // 
            // _pnlFrameStart
            // 
            this._pnlFrameStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlFrameStart.HorizontalScrollbarBarColor = true;
            this._pnlFrameStart.HorizontalScrollbarHighlightOnWheel = false;
            this._pnlFrameStart.HorizontalScrollbarSize = 10;
            this._pnlFrameStart.Location = new System.Drawing.Point(809, 41);
            this._pnlFrameStart.Name = "_pnlFrameStart";
            this._pnlFrameStart.Size = new System.Drawing.Size(45, 18);
            this._pnlFrameStart.TabIndex = 4;
            this._pnlFrameStart.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._pnlFrameStart.VerticalScrollbarBarColor = true;
            this._pnlFrameStart.VerticalScrollbarHighlightOnWheel = false;
            this._pnlFrameStart.VerticalScrollbarSize = 10;
            // 
            // _btnPlay
            // 
            this._btnPlay.Location = new System.Drawing.Point(8, 36);
            this._btnPlay.Name = "_btnPlay";
            this._btnPlay.Size = new System.Drawing.Size(32, 32);
            this._btnPlay.TabIndex = 3;
            this._btnPlay.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnPlay.UseSelectable = true;
            // 
            // _btnAddKey
            // 
            this._btnAddKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddKey.Location = new System.Drawing.Point(809, 3);
            this._btnAddKey.Name = "_btnAddKey";
            this._btnAddKey.Size = new System.Drawing.Size(32, 32);
            this._btnAddKey.TabIndex = 3;
            this._btnAddKey.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnAddKey.UseSelectable = true;
            // 
            // _tbKeyframes
            // 
            this._tbKeyframes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbKeyframes.BackColor = System.Drawing.Color.Transparent;
            this._tbKeyframes.Location = new System.Drawing.Point(30, 3);
            this._tbKeyframes.Name = "_tbKeyframes";
            this._tbKeyframes.Size = new System.Drawing.Size(762, 28);
            this._tbKeyframes.TabIndex = 2;
            this._tbKeyframes.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._tbKeyframes.Value = 1;
            // 
            // _pbEditor
            // 
            this._pbEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pbEditor.Location = new System.Drawing.Point(70, 91);
            this._pbEditor.Name = "_pbEditor";
            this._pbEditor.Size = new System.Drawing.Size(703, 389);
            this._pbEditor.TabIndex = 1;
            this._pbEditor.TabStop = false;
            // 
            // _lsvSpriteComponents
            // 
            this._lsvSpriteComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lsvSpriteComponents.Font = new System.Drawing.Font("Segoe UI", 12F);
            this._lsvSpriteComponents.FullRowSelect = true;
            this._lsvSpriteComponents.Location = new System.Drawing.Point(779, 113);
            this._lsvSpriteComponents.Name = "_lsvSpriteComponents";
            this._lsvSpriteComponents.OwnerDraw = true;
            this._lsvSpriteComponents.Size = new System.Drawing.Size(174, 180);
            this._lsvSpriteComponents.TabIndex = 2;
            this._lsvSpriteComponents.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._lsvSpriteComponents.UseCompatibleStateImageBehavior = false;
            this._lsvSpriteComponents.UseSelectable = true;
            // 
            // _pnlToolbar
            // 
            this._pnlToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._pnlToolbar.Controls.Add(this._btnAddSprite);
            this._pnlToolbar.HorizontalScrollbarBarColor = true;
            this._pnlToolbar.HorizontalScrollbarHighlightOnWheel = false;
            this._pnlToolbar.HorizontalScrollbarSize = 10;
            this._pnlToolbar.Location = new System.Drawing.Point(23, 91);
            this._pnlToolbar.Name = "_pnlToolbar";
            this._pnlToolbar.Size = new System.Drawing.Size(41, 389);
            this._pnlToolbar.TabIndex = 3;
            this._pnlToolbar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._pnlToolbar.VerticalScrollbarBarColor = true;
            this._pnlToolbar.VerticalScrollbarHighlightOnWheel = false;
            this._pnlToolbar.VerticalScrollbarSize = 10;
            // 
            // _btnAddSprite
            // 
            this._btnAddSprite.Location = new System.Drawing.Point(4, 4);
            this._btnAddSprite.Name = "_btnAddSprite";
            this._btnAddSprite.Size = new System.Drawing.Size(32, 32);
            this._btnAddSprite.TabIndex = 2;
            this._btnAddSprite.Theme = MetroFramework.MetroThemeStyle.Dark;
            this._btnAddSprite.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(863, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(84, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Components";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(779, 91);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(122, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Sprite Components";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // _mnuMenu
            // 
            this._mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._mnuMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.viewToolStripMenuItem});
            this._mnuMenu.Location = new System.Drawing.Point(20, 60);
            this._mnuMenu.Name = "_mnuMenu";
            this._mnuMenu.Size = new System.Drawing.Size(933, 24);
            this._mnuMenu.TabIndex = 5;
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
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.redoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
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
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // AnimationEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(973, 582);
            this.Controls.Add(this._mnuMenu);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this._pnlToolbar);
            this.Controls.Add(this._lsvSpriteComponents);
            this.Controls.Add(this._pbEditor);
            this.Controls.Add(this._pnlTimeline);
            this.Name = "AnimationEditorForm";
            this.Text = "Animation Editor";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.SpriteEditor_Load_1);
            this._pnlTimeline.ResumeLayout(false);
            this._pnlTimeline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pbEditor)).EndInit();
            this._pnlToolbar.ResumeLayout(false);
            this._mnuMenu.ResumeLayout(false);
            this._mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;

        private MetroFramework.Controls.MetroPanel _pnlTimeline;
        private MetroFramework.Controls.MetroButton _btnPlay;
        private MetroFramework.Controls.MetroButton _btnAddKey;
        private MetroFramework.Controls.MetroTrackBar _tbKeyframes;
        private MetroFramework.Controls.MetroPanel _pnlFrameEnd;
        private MetroFramework.Controls.MetroPanel _pnlFrameStart;
        private PictureBox _pbEditor;
        private MetroFramework.Controls.MetroListView _lsvSpriteComponents;
        private MetroFramework.Controls.MetroPanel _pnlToolbar;
        private MetroFramework.Controls.MetroButton _btnAddSprite;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MenuStrip _mnuMenu;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel _lblFrameNumber;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem propertiesToolStripMenuItem;
    }
}