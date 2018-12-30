using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Monoedit
{
    public enum SelectFileMode
    {
        File, Folder
    }
    public partial class SelectFile : UserControl
    {
        public string Filter { get; set; } = ".cs|*.cs";
        public string DefaultExt { get; set; } = ".cs";
        public string InitialDir { get; set; } = "C:/";
        public string Instruction { get { return _lblInstruction.Text; } set { _lblInstruction.Text = value; } }
        public string PathText { get { return _txtFileLocation.Text; } set { _txtFileLocation.Text = value; } }
        public SelectFileMode Mode { get; set; } = SelectFileMode.File;

        public SelectFile()
        {
            InitializeComponent();
        }
        private void SelectFile_Load(object sender, EventArgs e)
        {
            // this._btnOpenFile.BackgroundImage = global::Monoedit.Properties.Resources.appbar_folder_open;
            // this._btnOpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            ThemeApplier.SetBackgroundImage(_btnOpenFile, "appbar.folder.open.png");

        }
        private void _btnOpenFile_Click(object sender, EventArgs e)
        {
            string[] values = null;
            if(Mode == SelectFileMode.Folder)
            {
                values = Globals.GetValidUserFolder(InitialDir, false);
            }
            else
            {
                values = Globals.GetValidOpenSaveUserFile(this,false, Filter, Filter, DefaultExt, InitialDir);
            }
            if (values !=null && values.Length > 0)
            {
                _txtFileLocation.Text = values[0];
              
            }
        }

        private void _txtFileLocation_Click(object sender, EventArgs e)
        {

        }

        private void _txtFileLocation_TextChanged(object sender, EventArgs e)
        {
            if (_txtFileLocation.Text.Length > 0)
            {
                string dir = _txtFileLocation.Text;
                if(Mode == SelectFileMode.Folder)
                {
                    if (System.IO.Directory.Exists(dir))
                    {
                        _lblError.Text = Translator.Translate(Phrases.FolderDoesNotExist);
                    }
                }
                else
                {
                    if (System.IO.File.Exists(dir))
                    {
                        _lblError.Text = Translator.Translate(Phrases.FileDoesNotExist);
                    }
                }
            }
        }
    }
}
