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
        MonoEditNumericUpDown _nudGrowBy;

        public ProjectPropertiesForm()
        {
            InitializeComponent();
        }
        private void ProjectPropertiesForm_Load(object sender, EventArgs e)
        {
            //Texture Width
            _nudMaxTextureWidth = new MonoEditNumericUpDown();
            _nudMaxTextureWidth.Min = 256;
            _nudMaxTextureWidth.Max = 32767;
            _nudMaxTextureWidth.Value = 4096;
            _nudMaxTextureWidth.DataType = DataType.Int32;
            _nudMaxTextureWidth.ValueChanged = () => {
                MarkChanged(true);
            };
            Globals.SwapControl(_pnlMaxTextureWidth, _nudMaxTextureWidth);

            //Grow By
            _nudGrowBy = new MonoEditNumericUpDown();
            _nudGrowBy.Min = 32;
            _nudGrowBy.Max = 1024;
            _nudGrowBy.Value = 128;
            _nudGrowBy.DataType = DataType.Int32;
            _nudGrowBy.ValueChanged = () => {
                MarkChanged(true);
            };
            Globals.SwapControl(_pnlGrowBy, _nudGrowBy);

            _cboExportFileType.Items.Add("PNG");
            _cboExportFileType.SelectedIndex = 0;


            LoadData();

            MarkChanged(false);
        }
        protected override void AddObject()
        {
            //We aren't "adding" a project file.
            throw new NotImplementedException();
        }
        protected override void EditObject(object obj)
        {
            ProjectFile = obj as ProjectFile;
            MarkChanged(false);
        }
        protected override void LoadData()
        {
            //throw new NotImplementedException();
            _nudMaxTextureWidth.Value = ProjectFile.MaxAtlasSize;
            _nudGrowBy.Value = ProjectFile.GrowAtlasBy;
            _txtOutputDirectory.Text = ProjectFile.OutputPath;
            _txtOutputFilename.Text = ProjectFile.OutputFilename;
        }
        protected override void SaveData()
        {
            ProjectFile.MaxAtlasSize = (int)_nudMaxTextureWidth.Value;
            ProjectFile.GrowAtlasBy = (int)_nudGrowBy.Value;
            ProjectFile.OutputPath = _txtOutputDirectory.Text.Trim();
            ProjectFile.OutputFilename = _txtOutputFilename.Text.Trim();
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
                SaveData();
                MarkChanged(false);
                return true;
            });

        }
        private void _btnCancel_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }
        private void _txtOutputDirectory_TextChanged(object sender, EventArgs e)
        {
            MarkChanged(true);
        }
        private void MarkChanged(bool changed)
        {
            _btnApply.Enabled = changed;
        }
        private void _txtOutputFilename_TextChanged(object sender, EventArgs e)
        {
            MarkChanged(true);
        }
        private void _cboExportFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarkChanged(true);
        }


    }
}
