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
    public partial class NewProjectForm : ToolWindowBase
    {
        public ProjectFile ProjectFile { get; private set; } = null;
        SelectFile SelectFile = new SelectFile();

        public NewProjectForm()
        {
            InitializeComponent();
        }

        private void NewProjectForm_Load(object sender, EventArgs e)
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

            UpdatePath();
        }
        void CreateSelectFile()
        {
            SelectFile.Filter = ".cs|*.cs";
            SelectFile.DefaultExt = ".cs";
            SelectFile.InitialDir = "C:/";
            SelectFile.Instruction = "Select Folder";
            SelectFile.PathText = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Monogame Toolkit Projects");
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
            if (string.IsNullOrEmpty(_txtProjectName.Text))
            {
                errs.Add(Translator.Translate(Phrases.ProjectNameIsEmpty));
            }
            if (System.IO.Directory.Exists(GetFilePath()))
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
            SaveAndClose(() => {
                try
                {
                    string filePath = _txtFinalPath.Text;
                    string fileDirPath = GetFilePath();

                    if (!System.IO.Directory.Exists(fileDirPath))
                    {
                        System.IO.Directory.CreateDirectory(fileDirPath);
                    }

                    ProjectFile = new ProjectFile();
                    ProjectFile.ProjectName = _txtProjectName.Text;
                    ProjectFile.SaveAs(filePath);

                    //Must call afterr we've saved project file to ensure the cached path is set.
                    string images_path = ProjectFile.ImagesPath();
                    if (!System.IO.Directory.Exists(images_path))
                    {
                        System.IO.Directory.CreateDirectory(images_path);
                    }

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
            Close();
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
                SelectFile.PathText, _txtProjectName.Text, ProjectFileName());

        }
    }
}
