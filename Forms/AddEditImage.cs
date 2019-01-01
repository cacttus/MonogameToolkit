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
    public partial class AddEditImage : AddEditBase
    {
        public ImageResource ImageResource { get; private set; }

        private SelectFile _objSelectFile = new SelectFile();

        public AddEditImage()
        {
            InitializeComponent();

            Globals.SetTooltip(
            _optCopyToProjectDir,
            new Phrase(
                "Check this to copy the image to the project directory.  It is recommended you keep all images under /Images.  If the file you select is alread in the /Images folder no copy is performed."
                    ,
                "Marque esto para copiar la imagen al directorio del proyecto. Se recomienda mantener todas las imágenes en / Imágenes (/Images). Si el archivo que seleccionó ya está en la carpeta / Imágenes, no se realiza ninguna copia."
                ));
        }
        private void AddEditImage_Load(object sender, EventArgs e)
        {
            _objSelectFile.Filter = Globals.SupportedLoadSpriteImageFilter;
            _objSelectFile.DefaultExt = Globals.SupportedLoadSpriteImageFilterDefault;
            _objSelectFile.InitialDir = Globals.MainForm.ProjectFile.GetProjectRoot();
            _objSelectFile.Instruction = "Select Image";
            _objSelectFile.PathText = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Mono Projects", "MyProject");
            _objSelectFile.Mode = SelectFileMode.File;
            _objSelectFile.TextChanged = () =>
            {
                //when selected file changed load and update.
                TryLoadImagePreview();
            };
            Globals.SwapControl(_pnlLocation, _objSelectFile);

            _pbImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = true;
            Globals.MainForm.ProjectFile.Images.Add(ImageResource);
            Globals.MainForm.ProjectFile.MarkChanged();

            Close();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void _btnReload_Click(object sender, EventArgs e)
        {
            TryLoadImagePreview();
        }

        private void TryLoadImagePreview()
        {
            Bitmap bmp = null;
            try
            {
                if (System.IO.File.Exists(_objSelectFile.PathText))
                {
                    bmp = new System.Drawing.Bitmap(_objSelectFile.PathText);
                }
            }
            catch (Exception ex)
            {
                Globals.LogError(ex.ToString());
            }
            _pbImage.Image = bmp;
        }

        private void _optCopyToProjectDir_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePathPreview();
        }

        private void _optUseSelectedPath_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePathPreview();
        }
        void UpdatePathPreview()
        {
            try
            {
                if (_optCopyToProjectDir.Checked)
                {
                    string fn = System.IO.Path.GetFileName(_objSelectFile.PathText);

                    string image = System.IO.Path.Combine(
                        Globals.MainForm.ProjectFile.ImagesPath(), fn);
                    _txtImagePathPreview.Text = image;
                }
                else if (_optUseSelectedPath.Checked)
                {
                    _txtImagePathPreview.Text = _objSelectFile.PathText;
                }
            }
            catch (Exception ex)
            {
                Globals.LogError(ex.ToString());
            }
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void _optImage_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected override List<String> Validate()
        {
            List<string> results = new List<string>();
            _txtImageName.ForeColor = Color.Black;
            _objSelectFile.FileLocationTextBox.ForeColor = Color.Black;

            if (String.IsNullOrEmpty(ImageResource.Name))
            {
                results.Add("Please set the resource name.");
                _txtImageName.ForeColor = Color.Red;
            }

            foreach (ImageResource ir in Globals.MainForm.ProjectFile.Images)
            {
                if (ir.Name.Equals(ImageResource.Name))
                {
                    if (ir != ImageResource)
                    {
                        results.Add("Resource name '" + ir.Name + "' must be unique.");
                        _txtImageName.ForeColor = Color.Red;
                        break;
                    }
                }
            }

            if (String.IsNullOrEmpty(ImageResource.Path))
            {
                results.Add("Please set image path.");
                _objSelectFile.FileLocationTextBox.ForeColor = Color.Red;
            }

            if (System.IO.File.Exists(ImageResource.Path) == false)
            {
                results.Add("Image file does not exist.");
                _objSelectFile.FileLocationTextBox.ForeColor = Color.Red;
            }

            return results;
        }

        public override bool OkButtonClicked()
        {
            SaveAndClose(() =>
            {
                //Most if not all resources should be copied to the project folder.
                if (_optCopyToProjectDir.Checked == true)
                {
                    string p0 = System.IO.Path.GetFullPath(_txtImagePathPreview.Text);
                    string p1 = System.IO.Path.GetFullPath(ImageResource.Path);

                    if ((AddEditMode == AddEditMode.Edit && p0 != p1) || AddEditMode == AddEditMode.Add)
                    {
                        if (CopyResourceToLocalResourceFolder() == false)
                        {
                            return false;
                        }
                    }
                }

                //Run this when we validate successfully
                DialogResult = true;

                //Add resource to project file.
                if (AddEditMode == AddEditMode.Add)
                {
                    if (!Globals.MainForm.ProjectFile.Images.Contains(ImageResource))
                    {
                        Globals.MainForm.ProjectFile.Images.Add(ImageResource);
                    }
                    else
                    {
                        //test
                        System.Diagnostics.Debugger.Break();
                    }
                }
                else if (AddEditMode == AddEditMode.Edit)
                {

                }
                else
                {
                    throw new NotImplementedException();
                }

                return true;
            });
            return false;
        }
        private bool CopyResourceToLocalResourceFolder()
        {
            //Copy the given image to the ./{ProjectRoot}/images folder
            //Returns false if the user cancelled the operation
            try
            {
                Globals.MainForm.ProjectFile.SetCwdToRoot();

                //Copy File.
                string imgCurFolder = System.IO.Path.GetDirectoryName(ImageResource.Path);
                string imgCurFilename = System.IO.Path.GetFileName(ImageResource.Path);
                string imgNewFilename = System.IO.Path.Combine(Globals.MainForm.ProjectFile.GetImageResourcePath(), imgCurFilename);
                string imgNewFolder = System.IO.Path.GetDirectoryName(imgNewFilename);

                if (Globals.PathsAreEqual(imgCurFolder, imgNewFolder))
                {
                    Globals.MainForm.SetStatus("Image " + imgNewFilename + " already located in /images folder, no copy performed.");
                }
                else
                {
                    //Check to see if the file exists.  If it does then prompt hte user that there is a conflict.
                    bool? continueCopy = CheckImageDoesntExistBeforeCopying(imgNewFilename);

                    if (continueCopy == null)
                    {
                        return false;
                    }
                    else if (continueCopy == true)
                    {
                        if (System.IO.File.Exists(imgNewFilename))
                        {
                            System.IO.File.Delete(imgNewFilename);
                        }
                        System.IO.File.Copy(ImageResource.Path, imgNewFilename);
                        ImageResource.Path = Globals.GetRelativePath(imgNewFilename, Globals.MainForm.ProjectFile.GetProjectRoot());
                    }
                    //Otherwise wer're goign to use the image in that folder.

                    //Set path and reload.
                    ImageResource.LoadIfNecessary(true);
                }
            }
            catch (Exception ex)
            {
                Globals.LogError("Failed to copy image to ouput directory: " + ex.ToString(), true);
                throw ex;
            }
            return true;
        }
        private bool? CheckImageDoesntExistBeforeCopying(string imgNewFileName)
        {
            //Check to see if the file exists.  If it does then prompt hte user that there is a conflict.
            //returns true if teh copy continues
            //return null if the user cancelled the operation
            //return false to stop the copy.
            if (System.IO.File.Exists(imgNewFileName))
            {
                string msg = "The file '' already exists.";

                string newRelpath = Globals.GetRelativePath(imgNewFileName, Globals.MainForm.ProjectFile.GetProjectRoot());

                List<ImageResource> rs = Globals.MainForm.ProjectFile.Images.Where(x => Globals.PathsAreEqual(x.Path, newRelpath)).ToList();
                if (rs != null && rs.Count > 0)
                {
                    string tots = string.Join(", ", rs.Select(x => "  " + x.Name + "\r\n"));

                    msg += "It appears that the resource(s):\r\n '" + tots + "' \r\n is/are using this path.";
                }
                else
                {
                    msg += "No resources were found to use this resource. ";
                }
                msg += "Would you like to overwrite this resource? Note: Clicking 'No' will cause this new resource to use the " +
                "existing resource in the resource folder.  " +
                "To use a new resource click 'Cancel' , uncheck 'copy resource' above, and try saving again.";

                //file already exists! ask user about this.
                DialogResult r = CustomMessageBox.Show(msg, Phrases.Warning,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (r == System.Windows.Forms.DialogResult.Cancel)
                {
                    return null;
                }
                else if (r == System.Windows.Forms.DialogResult.Yes)
                {
                    return true;
                }
                else if (r == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }



















    }
}
