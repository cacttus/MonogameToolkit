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
    public partial class MainForm : MonoEditForm
    {
        public ProjectFile ProjectFile { get; set; } = new ProjectFile();
        public OptionsFile OptionsFile = new OptionsFile();
        public UndoManager UndoManager { get; set; } = null;

        public List<MonoEditForm> Forms { get; } = new List<MonoEditForm>();

        public ToolStripMenuItem UndoMenuItem { get { return undoToolStripMenuItem; } }
        public ToolStripMenuItem RedoMenuItem { get { return redoToolStripMenuItem; } }

        public MainForm()
        {
            InitializeComponent();
            Globals.SetMainWindow(this);

            UndoManager = new UndoManager();

            
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            OptionsFile = OptionsFile.CreateOrLoad(OptionsFile.FileLoc());

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
                Globals.ShowError(new Phrase(e,e),  this);
            }
        }

        public void SetStatus(string stat)
        {
            _lblStatus.BeginInvoke((Action)(() =>
            {
                _lblStatus.Text = stat;
            }));
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void AddEditObject(Model3D m, bool bClose)
        {
        }

        public void AddEditObject(Sprite s, Model3D m, bool bClose)
        {
        }

        public void AddEditObject(Frame fr, Sprite s, bool bClose)
        {
        }

        void ShowAddEdit(Action add, Action remove, Func<List<SpriteListViewItem>> GetFramesFunc, Action<List<object>> deleteFunc)
        {
            AddEditItem f = new AddEditItem();
            f.Init(add, remove);
            SpriteListView sv = new SpriteListView(GetFramesFunc, deleteFunc);
            Globals.SwapControl(f.SpriteListViewPanel, sv);
            f.ShowDialog(this);
        }
        
        private void objectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddEdit(
                ()=> {

                },
                () => {

                },
                () => {
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
                (x) => {}
            );
        }

        private void layersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm off = new OptionsForm();
            off.ShowDialog(this);
        }

        private void imagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAddEdit(
                ()=> {

                },
                () => {

                },
                () =>
                {
                    List<SpriteListViewItem> items = new List<SpriteListViewItem>();
                    if (ProjectFile != null)
                    {
                        foreach (ImageResource r in ProjectFile.Images)
                        {
                            SpriteListViewItem li = new SpriteListViewItem(r, r.BitmapImage);
                            items.Add(li);
                        }
                    }
                    return items;
                },
                (x) => {
                }
            );
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool makeNew = true;

            if (ProjectFile.DataChanged)
            {
                DialogResult dr = ShowUnsavedChangesMbox();

                if (dr == DialogResult.Yes)
                {
                    makeNew = true;
                }
                else
                {
                    makeNew = false;
                }
            }
            if (makeNew)
            {
                this.ProjectFile = new ProjectFile();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private DialogResult ShowUnsavedChangesMbox()
        {
            return Globals.MessageBox(
                    new Phrase("Unsaved changes exist.  Discard?",
                    "Existen cambios no guardados. ¿Descarte?"),
                    new Phrase("Unsaved Changes", "Cambios no guardados"),
                    MessageBoxButtons.YesNo, this);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool exit = true;
            if (ProjectFile.DataChanged)
            {
                DialogResult dr = ShowUnsavedChangesMbox();

                if (dr == DialogResult.Yes)
                {
                    exit = true;
                }
                else
                {
                    exit = false;
                }
            }
            if (exit)
            {

            Environment.Exit(0);
            }
        }
    }
}
