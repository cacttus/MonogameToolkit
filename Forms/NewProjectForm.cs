using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monoedit
{
    public partial class NewProjectForm : AddEditWindowBase
    {
        public ProjectFile ProjectFile { get; private set; } = null;
        SelectFile SelectFile = new SelectFile();

        public NewProjectForm()
        {
            InitializeComponent();
        }

        private void NewProjectForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected override void SaveData()
        {
        }
        protected override void LoadData()
        {
            CreateSelectFile();

            Globals.SetTooltip(_chkOverwrite,
                new Phrase("Overwrite an existing folder in the given path, and any existing files in that path.",
                "Sobrescribirá una carpeta existente en la ruta dada, y cualquier archivo existente en esa ruta.")
                );

            Globals.SetTooltip(new List<Control>() { _txtProjectName, _lblProjectName },
                new Phrase("Name of the Project (also name of folder and project file).",
                "Nombre del proyecto(también nombre de la carpeta y archivo del proyecto)")
                );


            _txtProjectName.Text = ProjectFile.ProjectName;
            SelectFile.PathText = ProjectFile.LoadedOrSavedFileName;
            UpdatePath();
        }
        protected override void AddObject()
        {
            ProjectFile = new ProjectFile();

            ProjectFile.SetDefaults();

        }
        protected override void EditObject(object obj)
        {
            ProjectFile = obj as ProjectFile;
        }

        private void CreateSelectFile()
        {
            SelectFile.Filter = ".cs|*.cs";
            SelectFile.DefaultExt = ".cs";
            SelectFile.InitialDir = "C:/";
            SelectFile.Instruction = "Select Folder";
            SelectFile.PathText = "";
            SelectFile.Mode = SelectFileMode.Folder;
            SelectFile.TextChanged += () => {
                UpdatePath();
            };
            Globals.SwapControl(_pnlProjectDir, SelectFile);
        }
        string GetFilePath()
        {
            return System.IO.Path.GetDirectoryName(_txtFinalPath.Text);
        }
        protected override List<string> Validate()
        {
            List<string> errs = new List<string>();

            CheckValidName(errs, _txtProjectName, _lblProjectName.Text);

            string filePath = GetFilePath();
            if (System.IO.Directory.Exists(filePath))
            {
                if (_chkOverwrite.Checked == false)
                {
                    errs.Add(Translator.Translate(Phrases.ProjectFolderExists));
                }
            }
            if (Globals. FilePathHasInvalidChars(GetFilePath()))
            {
                errs.Add(Translator.Translate(Phrases.PathHasInvalidChars));
            }
            return errs;
        }
        private void _btnOk_Click(object sender, EventArgs e)
        {
            ApplyChangesAndClose(() => {
                try
                {
                    string filePath = _txtFinalPath.Text;
                    string fileDirPath = GetFilePath();

                    if (!System.IO.Directory.Exists(fileDirPath))
                    {
                        System.IO.Directory.CreateDirectory(fileDirPath);
                    }

                    //ProjectFile = new ProjectFile();
                    ProjectFile.ProjectName = _txtProjectName.Text;
                    ProjectFile.SaveAs(filePath);

                    //Must call afterr we've saved project file to ensure the cached path is set.
                    string images_path = ProjectFile.ImagesPath();
                    if (!System.IO.Directory.Exists(images_path))
                    {
                        System.IO.Directory.CreateDirectory(images_path);
                    }
                    DialogResult = true;

                    return true;
                }
                catch (Exception ex)
                {
                    Globals.LogError("Could not create project: " + ex.ToString());
                    return false;
                }
            });

        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }

        private void _pnlProjectDir_Paint(object sender, PaintEventArgs e)
        {
        }

        private void _txtProjectName_Click(object sender, EventArgs e)
        {
        }

        private void _txtProjectName_TextChanged(object sender, EventArgs e)
        {
            UpdatePath();
        }
        string ProjectFileName()
        {
            return _txtProjectName.Text + Globals.ProjectExt;
        }
        void UpdatePath()
        {
            _txtFinalPath.Text = System.IO.Path.Combine(
                SelectFile.PathText, 
                _chkCreateProjectDirectory.Checked ? _txtProjectName.Text : String.Empty
                , ProjectFileName());

        }

        private void _chkCreateProjectDirectory_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePath();
        }
    }
}
