using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace Monoedit
{

    public partial class MainForm : MonoEditForm
    {
        public ProjectFile ProjectFile { get; set; } = null;// new ProjectFile();
        public OptionsFile OptionsFile = new OptionsFile();
        public UndoManager UndoManager { get; set; } = null;
        public List<MonoEditForm> Forms { get; } = new List<MonoEditForm>();
        public ToolStripMenuItem UndoMenuItem { get { return undoToolStripMenuItem; } }
        public ToolStripMenuItem RedoMenuItem { get { return redoToolStripMenuItem; } }
        public List<string> Errors { get; private set; } = new List<string>();
        PictureBox TitleImage = null;

        public MainForm()
        {
            InitializeComponent();
            Globals.SetMainWindow(this);

            _mnuMenu.Renderer = new MonoEditToolStripRenderer();
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            UnloadAndRefresh();
        }

        #region Public: Window Methods
        public void RefreshAllWindows()
        {

        }
        public DialogResult? ShowForm(string header, AddEditWindowBase f,
            bool bModal = false, Action<DialogResult?> afterShow = null, IWin32Window owner = null)
        {
            DialogResult? dr = null;
            if (bModal)
            {
                //Do not use system dialog result
                f.ShowDialog(owner);
                if (f.DialogResult == null)
                {
                    throw new Exception("Dialog result was not set for tool window");
                }
                dr = f.DialogResult.Value == true ? DialogResult.OK : DialogResult.Cancel;
                afterShow?.Invoke(dr);
            }
            else
            {
                Forms.Add(f);
                f.Closing += (x, e) =>
                {
                    afterShow?.Invoke(dr);
                };
                f.Show();
            }
            return dr;
        }
        #endregion

        #region Public: Methods
        public void LogError(string e, bool messagebox = false)
        {
            e = DateTime.Now.ToString("hh:mm:ss:fff") + ":" + e;
            Errors.Add(e);
            SetStatus(e);
            if (messagebox)
            {
                Globals.ShowError(new Phrase(e, e), this);
            }
        }
        public void SetStatus(string stat)
        {
            _lblStatus.BeginInvoke((Action)(() =>
            {
                _lblStatus.Text = stat;
            }));
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
        public void MarkChanged(bool changed)
        {
            if (this.ProjectFile != null)
            {
                this.Text = Globals.ApplicationTitle + " - " + ProjectFile.ProjectName + (changed ? "*" : "");
            }
        }
        private void UnloadAndRefresh()
        {
            ProjectFile = null;
            GC.Collect();

            UndoManager = new UndoManager();

            //Disable UI until user loads something or makes a new
            AfterProjectFileLoaded(false);

            LoadOptions();

            //Load Prefs, autoload file.
            foreach (Form f in this.Forms)
            {
                f.Close();
            }

            Forms.Clear();

            InitializeTabControl();

            LoadRecentFiles();

            CreateTitleImage();
            TitleImage.Show();

            GC.Collect();
        }

        private void CreateTitleImage()
        {
            if (TitleImage != null)
            {
                return;
            }

            TitleImage = new PictureBox();

            Rectangle bounds = _tabEditor.Bounds;

            TitleImage.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            TitleImage.BackColor = Color.Transparent;
            float xpadding = 0.2f;
            float ypadding = 0.3f;

            TitleImage.Bounds = new Rectangle()
            {
                X = (int)((float)bounds.X + (float)bounds.Width * xpadding)
                ,
                Y = (int)((float)bounds.Y + (float)bounds.Height * ypadding)
                ,
                Width = (int)((float)bounds.Width - (float)bounds.Width * xpadding * 2)
                ,
                Height = (int)((float)bounds.Height - (float)bounds.Height * ypadding * 2)
            };

            Controls.Add(TitleImage);
            TitleImage.BringToFront();
            Bitmap bmp = Globals.LoadBitmapResource(Globals.TitleImageName);

            if (bmp != null)
            {
                TitleImage.Image = new ImageMaker(bmp).BlackAndWhite().SetAlpha(0.09f).Bitmap;
                TitleImage.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        #endregion

        #region File Handling
        private void FileOpen()
        {
            try
            {
                bool keepgoing = CheckDiscardChanges();
                if (keepgoing)
                {
                    string[] files = Globals.GetValidOpenSaveUserFile(this, false, Globals.ProjectFilter,
                        Globals.ProjectExt, Globals.GetDocumentsFolderPath(), false,
                        ProjectFile != null ? ProjectFile.ProjectName : Globals.GetDocumentsFolderPath());

                    if (files.Length == 1)
                    {
                        LoadProjectFile(files[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }
        private void FileCreateNew()
        {
            try
            {
                if (CheckDiscardChanges())
                {
                    NewProjectForm d = new NewProjectForm();
                    d.ShowForm(AddEditMode.Add, this, Phrases.CreateProject, null,
                        (DialogResult? dr) =>
                        {
                            if (dr != null && dr == DialogResult.OK)
                            {
                                if (d.ProjectFile != null)
                                {
                                    ProjectFile = d.ProjectFile;
                                    ProjectFile.MarkChanged();

                                    //Run initial save so we have it.
                                    FileSaveProject();

                                    AfterProjectFileLoaded(true);
                                }
                            }

                        }
                    );
                }
            }
            catch (Exception ex)
            {
                LogError(ex.ToString(), true);
            }
        }
        private void FileCloseProject()
        {
            UnloadAndRefresh();

        }
        private void FileSaveProject()
        {
            if (ProjectFile != null)
            {
                //User file -> save - save to last path
                if (string.IsNullOrEmpty(ProjectFile.LoadedOrSavedFileName) == false)
                {
                    //if (File.Exists(ProjectFile.ProjectFileName))
                    {
                        ProjectFile.Save();
                        SaveRecentFile(ProjectFile.LoadedOrSavedFileName);

                        SetAutoLoadFile(ProjectFile.LoadedOrSavedFileName);
                    }
                }
                else
                {
                    //If no last path set save as
                    PromptSaveAs();
                }
            }
        }
        private void PromptSaveAs()
        {
            if (ProjectFile == null)
            {
                LogError("Project file wasn't set.");
            }
            else
            {
                string[] files = Globals.GetValidOpenSaveUserFile(this, true, Globals.ProjectFilter, "",
                    Globals.ProjectExt, Globals.GetDocumentsFolderPath(), false, ProjectFile.ProjectName);

                if (files.Length == 1)
                {
                    ProjectFile.SaveAs(files[0]);
                    SaveRecentFile(files[0]);
                    SetAutoLoadFile(files[0]);

                    AfterProjectFileLoaded(true);
                }
            }
        }
        public void SaveRecentFile(string path)
        {
            try
            {
                LoadOptions();
                string full = Globals.NormalizePath(path);

                if (!OptionsFile.RecentFiles.Contains(full))
                {
                    OptionsFile.RecentFiles.Add(full);

                    if (OptionsFile.RecentFiles.Count > 10)
                    {
                        OptionsFile.RecentFiles.RemoveAt(0);
                    }
                }
                OptionsFile.Save();

                LoadRecentFiles();
            }
            catch (Exception ex)
            {
                //log silently
                LogError(ex.ToString(), false);
            }
        }
        public void LoadOptions()
        {
            OptionsFile = Globals.SafeCast<OptionsFile>(OptionsFile.CreateOrLoad(OptionsFile.FileLoc()));
        }
        public void LoadRecentFiles()
        {
            try
            {
                LoadOptions();
                int i = 0;
                _mnuRecentFiles.DropDownItems.Clear();
                foreach (string mnuitem in OptionsFile.RecentFiles)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Name = "recent_file_" + i.ToString();
                    item.Text = Globals.ShortenFilePath(mnuitem, 16);
                    item.Tag = mnuitem;
                    item.Click += (x, y) =>
                    {
                        LoadProjectFile(mnuitem);
                    };
                    _mnuRecentFiles.DropDownItems.Add(item);
                    i++;
                }
            }
            catch (Exception ex)
            {
                //log silently
                LogError(ex.ToString(), false);
            }
        }
        private bool CheckDiscardChanges()
        {
            bool keepgoing = true;
            if (ProjectFile != null && ProjectFile.DataChanged)
            {
                DialogResult r = Globals.MessageBox(
                    new Phrase("Unsaved changes exist.  Discard?",
                    "Existen cambios no guardados. ¿Descarte?"),
                    new Phrase("Unsaved Changes", "Cambios no guardados"),
                    MessageBoxButtons.YesNo, this);

                //DialogResult r = CustomMessageBox.Show(
                //    "The current file has unsaved changes.  These will be lost.  Continue?",
                //    Phrases.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                keepgoing = (r == DialogResult.Yes);
            }
            return keepgoing;
        }
        private void LoadProjectFile(string fn)
        {
            try
            {
                //Unload everything.
                UnloadAndRefresh();

                ProjectFile = new ProjectFile();
                ProjectFile = Globals.SafeCast<ProjectFile>(ProjectFile.Load(fn));
                SaveRecentFile(fn);
                SetAutoLoadFile(fn);

                AfterProjectFileLoaded(true);
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }
        private void AfterProjectFileLoaded(bool loaded)
        {
            //Enable UI when we have a project loaded.
            spritesToolStripMenuItem.Enabled =
            objectsToolStripMenuItem.Enabled =
            imagesToolStripMenuItem.Enabled =
            layersToolStripMenuItem.Enabled =
            closeProjectToolStripMenuItem.Enabled =
            saveToolStripMenuItem.Enabled =
            saveAsToolStripMenuItem.Enabled =
            propertiesToolStripMenuItem.Enabled =
            (ProjectFile != null);

            //Update Title.
            MarkChanged(false);

            if (loaded)
            {
                OpenProjectFileTextEditor();
            }

            if (loaded && ProjectFile != null)
            {
                Text = Globals.ApplicationTitle + " - " + ProjectFile.ProjectName;
                //Set CWD
                System.IO.Directory.SetCurrentDirectory(ProjectFile.GetProjectRoot());
            }
            else
            {
                Text = Globals.ApplicationTitle;
            }

            RefreshAllWindows();

        }
        private void SetAutoLoadFile(string l)
        {
            //This is for automatically loading a file... for preferences window... 
            string full = Globals.NormalizePath(l);
            this.OptionsFile.AutoLoadFilePath = full;
            OptionsFile.SaveAs(Globals.MainForm.OptionsFile.FileLoc());
        }
        #endregion

        #region private: UI Methods
        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEditorTab tab = GetSelectedTabControl() as TextEditorTab;

            if (tab != null)
            {
                tab.Format();
            }

        }
        private void saveFileAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonoEditTabContent tab = GetSelectedTabControl();
            if (tab != null)
            {
                tab.SaveAs();
            }
        }
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonoEditTabContent tab = GetSelectedTabControl();
            if (tab != null)
            {
                tab.Save();
            }
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void objectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void spritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            AddEditContainer addEditItemForm = new AddEditContainer();

            Action<SpriteListView> add = (SpriteListView view) =>
            {
                AddEditImage f = new AddEditImage();
                f.ShowForm(AddEditMode.Add, addEditItemForm,
                    Phrases.AddImage, null, (DialogResult? dr) => { });
                view.UpdateListView();
            };
            Action<SpriteListView, object> edit = (SpriteListView view, object obj) =>
            {
                AddEditImage f = new AddEditImage();
                ImageResource r = obj as ImageResource;
                if (obj != null)
                {
                    f.ShowForm(AddEditMode.Edit, addEditItemForm,
                        Phrases.EditImage, r, (DialogResult? dr) => { });
                    view.UpdateListView();
                }
            };
            Action<SpriteListView, List<object>> remove = (SpriteListView view, List<object> xs) =>
            {
                view.Refresh();
            };
            Func<SpriteListView, List<SpriteListViewItem>> getframes = (SpriteListView view) =>
            {
                List<SpriteListViewItem> items = new List<SpriteListViewItem>();
                if (ProjectFile != null)
                {
                    foreach (ImageResource r in ProjectFile.Images)
                    {
                        SpriteListViewItem li = new SpriteListViewItem(r, r.Bitmap);
                        items.Add(li);
                    }
                }

                return items;
            };

            addEditItemForm.Init(add, edit, remove, getframes);
            addEditItemForm.ShowDialog(this);
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSaveProject();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileCreateNew();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOpen();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckDiscardChanges())
            {
                Environment.Exit(0);

            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog(this);
        }
        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileCloseProject();

        }

        #endregion

        #region Private: Tabs 
        int g_tabId = 0;
        private void InitializeTabControl()
        {
            //Delete tabs if present
            foreach (TabPage tp in _tabEditor.TabPages)
            {
                //TODO: do somethign
            }

            _tabEditor.TabPages.Clear();

            //Reset menu options.
            ToggleTabMenuOptions();

            //Enable / disable menu options when tab changed
            _tabEditor.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                ToggleTabMenuOptions();
            };
            //_tabEditor.ControlAdded += (object sender, ControlEventArgs e) =>
            //{
            //    ToggleTabMenuOptions();
            //};
            //_tabEditor.ControlRemoved += (object sender, ControlEventArgs e) =>
            //{
            //    ToggleTabMenuOptions();
            //};
        }



        private void OpenProjectFileTextEditor()
        {
            if (ProjectFile != null)
            {
                TextEditorTab tb = new TextEditorTab();
                MakeTab(tb, ProjectFile);
            }
        }
        private void CloseTab(int? tabId)
        {
            foreach (TabPage tp in _tabEditor.TabPages)
            {
                if (tp.Tag as int? == tabId)
                {
                    _tabEditor.TabPages.Remove(tp);
                    break;
                }
            }

            if (_tabEditor.TabPages.Count == 0)
            {
                TitleImage.Show();
            }
        }
        public void TabHeaderChanged(MonoEditTabContent cont)
        {
            TabPage tp = GetTabPageByTabContent(cont);
            if (tp != null)
            {
                tp.Text = cont.TabHeader;
            }
        }
        private TabPage GetTabPageByTabContent(MonoEditTabContent cont)
        {
            foreach (TabPage tp in _tabEditor.TabPages)
            {
                foreach (Control c in tp.Controls)
                {
                    if (c == cont)
                    {
                        return tp;
                    }
                }
            }
            return null;
        }
        private void MakeTab(MonoEditTabContent ctl, object toPopulate)
        {
            //Testin tabs
            //Load project file in new tab
            TabPage tp = new TabPage();
            int capture_tag = g_tabId++;
            tp.Tag = capture_tag;
            //Force a dock fill.
            ctl.Dock = DockStyle.Fill;
            tp.Controls.Add(ctl);

            MetroContextMenu cm = new MetroContextMenu(null);
            ApplyStyle(cm);
            cm.Theme = this.Theme;
            ToolStripMenuItem item = new ToolStripMenuItem(Translator.Translate(Phrases.Close));
            item.Click += (x, y) =>
            {
                CloseTab(capture_tag as int?);
            };
            cm.Items.Add(item);

            _tabEditor.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    cm.Show(_tabEditor, _tabEditor.PointToClient(Cursor.Position));
                }
            };
            _tabEditor.TabPages.Add(tp);

            //The order of things here is to ensure the form is visible before populating, that way
            //the control callbacks get fired.
            ctl.Populate(toPopulate);

            //Call this again.
            ToggleTabMenuOptions();

            TitleImage.Hide();
        }
        private void ToggleTabMenuOptions()
        {
            DisableAllTabMenuOptions();

            string rep = "";
            MonoEditTabContent tab = GetSelectedTabControl();
            if (tab != null)
            {
                TextEditorTab ed = tab as TextEditorTab;
                if (ed != null)
                {
                    saveFileAsToolStripMenuItem.Enabled = true;
                    saveFileToolStripMenuItem.Enabled = true;
                    if (ed.File != null)
                    {
                        rep = System.IO.Path.GetFileName(ed.File.LoadedOrSavedFileName);
                    }
                    EnableTextEditorTabOptions(true);
                }
            }

            if (string.IsNullOrEmpty(rep))
            {
                //set to blank and disable
                saveFileAsToolStripMenuItem.Enabled = false;
                saveFileToolStripMenuItem.Enabled = false;
            }
            saveFileAsToolStripMenuItem.Text = Translator.Translate(Phrases.SaveFileAs).Replace("{1}", rep);
            saveFileToolStripMenuItem.Text = Translator.Translate(Phrases.SaveFile).Replace("{1}", rep);

        }
        private void DisableAllTabMenuOptions(bool enable = false)
        {
            saveFileAsToolStripMenuItem.Enabled = false;
            saveFileToolStripMenuItem.Enabled = false;

            EnableTextEditorTabOptions(enable);
        }
        private void EnableTextEditorTabOptions(bool enable)
        {
            this.formatToolStripMenuItem.Enabled = enable;
        }
        MonoEditTabContent GetSelectedTabControl()
        {
            MetroUserControl ctl = null;
            if (_tabEditor.SelectedTab != null)
            {
                TabPage tp = _tabEditor.SelectedTab;
                foreach (Control c in tp.Controls)
                {
                    if (c is MonoEditTabContent)
                    {
                        return c as MonoEditTabContent;
                    }
                }
            }

            return null;
        }

        #endregion

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Export as a file thing.
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectPropertiesForm pf = new ProjectPropertiesForm();
            pf.ShowForm(AddEditMode.Edit, this, Phrases.EditProjectProperties, ProjectFile,
                (DialogResult? d) =>
                {

                }
            );
        }

    }
}
