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
    public partial class MainForm : MetroForm
    {
        public ProjectFile ProjectFile { get; set; } = null;
        public UndoManager UndoManager { get; set; } = null;

        public MainForm()
        {
            InitializeComponent();

            Globals.SetMainWindow(this);

            UndoManager = new UndoManager();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }


        public void MarkChanged(bool changed)
        {
            if (this.ProjectFile != null)
            {
                Text = Globals.ApplicationTitle + " - " + ProjectFile.ProjectName + (changed ? "*" : "");
            }
        }

        private void spritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        public void LogError(string e, bool messagebox = false)
        {
            SetStatus(e);
            if (messagebox)
            {
                Globals.ShowError(e, "Error", this);
            }
        }

        public void SetStatus(string stat)
        {
            BeginInvoke((Action)(() =>
            {
                _lblStatus.Text = stat;
            }));
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public ToolStripMenuItem UndoMenuItem { get { return undoToolStripMenuItem; } }
        public ToolStripMenuItem RedoMenuItem { get { return redoToolStripMenuItem; } }


        public void AddEditObject(Model m, bool bClose)
        {
        //    AddEditModel addEditModel1 = (AddEditModel)null;
        //    foreach (AddEditForm addEditForm in this.AddEditForms)
        //    {
        //        if (addEditForm is AddEditModel && (addEditForm as AddEditModel).Model == m)
        //        {
        //            addEditModel1 = addEditForm as AddEditModel;
        //            break;
        //        }
        //    }
        //    if (addEditModel1 == null && !bClose)
        //    {
        //        AddEditModel addEditModel2 = new AddEditModel(this);
        //        this.AddEditForms.Add((AddEditForm)addEditModel2);
        //        addEditModel2.Show(m);
        //    }
        //    else if (bClose)
        //        this.AddEditForms.Remove((AddEditForm)addEditModel1);
        //    else
        //        addEditModel1.BringToFront();
        }

        public void AddEditObject(Sprite s, Model m, bool bClose)
        {
            //AddEditSprite addEditSprite1 = (AddEditSprite)null;
            //foreach (AddEditForm addEditForm in this.AddEditForms)
            //{
            //    if (addEditForm is AddEditSprite && (addEditForm as AddEditSprite).Sprite == s)
            //    {
            //        addEditSprite1 = addEditForm as AddEditSprite;
            //        break;
            //    }
            //}
            //if (addEditSprite1 == null && !bClose)
            //{
            //    AddEditSprite addEditSprite2 = new AddEditSprite(this);
            //    this.AddEditForms.Add((AddEditForm)addEditSprite2);
            //    addEditSprite2.Show(s, m);
            //}
            //else if (bClose)
            //    this.AddEditForms.Remove((AddEditForm)addEditSprite1);
            //else
            //    addEditSprite1.BringToFront();
        }

        public void AddEditObject(Frame fr, Sprite s, bool bClose)
        {
            //AddEditFrame addEditFrame1 = (AddEditFrame)null;
            //foreach (AddEditForm addEditForm in this.AddEditForms)
            //{
            //    if (addEditForm is AddEditFrame && (addEditForm as AddEditFrame).Frame == fr)
            //    {
            //        addEditFrame1 = addEditForm as AddEditFrame;
            //        break;
            //    }
            //}
            //if (addEditFrame1 == null && !bClose)
            //{
            //    AddEditFrame addEditFrame2 = new AddEditFrame(this);
            //    this.AddEditForms.Add((AddEditForm)addEditFrame2);
            //    addEditFrame2.Show(fr, s);
            //}
            //else if (bClose)
            //    this.AddEditForms.Remove((AddEditForm)addEditFrame1);
            //else
            //    addEditFrame1.BringToFront();
        }

        private void objectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditItem f = new AddEditItem();

            SpriteListView sv = new SpriteListView(this, () =>
            {
                List<SpriteListViewItem> items = new List<SpriteListViewItem>();
                if (ProjectFile != null)
                {
                    foreach (GameObject go in ProjectFile.GameObjects)
                    {
                        SpriteListViewItem li = new SpriteListViewItem(go, go.DisplayFrame);
                        items.Add(li);
                    }
                }
                return items;
            },
            (x) =>
            {

            }
            );

            Globals.SwapControl(f.SpriteListViewPanel, sv);

            f.Show();
        }

        private void layersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
