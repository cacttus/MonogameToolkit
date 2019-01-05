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
    public partial class ProjectPropertiesForm : AddEditWindowBase
    {
        ProjectFile ProjectFile = null;

        MonoEditNumericUpDown _nudMaxTextureWidth;

        public ProjectPropertiesForm()
        {
            InitializeComponent();
        }
        private void ProjectPropertiesForm_Load(object sender, EventArgs e)
        {
            _nudMaxTextureWidth = new MonoEditNumericUpDown();
            _nudMaxTextureWidth.Min = 256;
            _nudMaxTextureWidth.Max = 32767;
            _nudMaxTextureWidth.Value = 4096;

            Globals.SwapControl(_pnlMaxTextureWidth, _nudMaxTextureWidth);

            LoadData();
        }

        protected override void AddObject()
        {
            //We aren't "adding" a project file.
            throw new NotImplementedException();
        }
        protected override void EditObject(object obj)
        {
            ProjectFile = obj as ProjectFile;
        }
        protected override void LoadData()
        {
            //throw new NotImplementedException();
            _nudMaxTextureWidth.Value = ProjectFile.MaxAtlasSize;
            _txtOutputDirectory.Text = ProjectFile.OutputPath;
            _txtOutputFilename.Text = ProjectFile.OutputFilename;
        }
        protected override void SaveData()
        {
            ProjectFile.MaxAtlasSize = _nudMaxTextureWidth.Value;
            ProjectFile.OutputPath = _txtOutputDirectory.Text;
            ProjectFile.OutputFilename = _txtOutputFilename.Text;
        }
        protected new virtual List<string> Validate()
        {
            List<string> res = new List<string>();

            if (string.IsNullOrEmpty(_txtOutputDirectory.Text))
            {
                res.Add("Output directory cannot be blank.");
            }

            if (string.IsNullOrEmpty(_txtOutputFilename.Text))
            {
                res.Add("Output filename cannot be blank.");
            }

            return res;
        }
        private void _txtOutputDirectory_Click(object sender, EventArgs e)
        {

        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            ApplyChangesAndClose(() => {

                SaveData();


                return true;
            });
        }

        private void _btnApply_Click(object sender, EventArgs e)
        {
            ApplyChanges(() => {


                return true;
            });
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }
    }
}
