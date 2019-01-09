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
    public partial class SpriteObjectForm : AddEditWindowBase
    {
        SpriteObject SpriteObject = null;

        public SpriteObjectForm()
        {
            InitializeComponent();
        }

        private void AddEditSpriteObject_Load(object sender, EventArgs e)
        {
            //Don't use object here.
            _btnEditAnimations.Text = Translator.Translate(Phrases.AddEditAnimations);
        }

        #region Override Methods
        protected override List<String> Validate()
        {
            List<string> results = new List<string>();

            CheckValidName(results, _txtName, _lblName.Text);

            return results;
        }
        protected override void LoadData()
        {
            _txtName.Text = SpriteObject.Name;
        }
        protected override void SaveData()
        {
            SpriteObject.Name = _txtName.Text;
        }
        protected override void AddObject()
        {
            SpriteObject = new SpriteObject();
            MarkChanged(true);
        }
        protected override void EditObject(object obj)
        {
            SpriteObject = obj as SpriteObject;
            MarkChanged(false);
            
        }

        #endregion

        private bool ApplyChanges()
        {
            SaveData();
            if (AddEditMode == AddEditMode.Add)
            {
                if (!Globals.MainForm.ProjectFile.SpriteObjects.Contains(SpriteObject))
                {
                    Globals.MainForm.ProjectFile.SpriteObjects.Add(SpriteObject);
                }
                else
                {
                    //test
                    Globals.LogError("Sprite Object was already found in project.");
                    System.Diagnostics.Debugger.Break();
                }
            }
            else if (AddEditMode == AddEditMode.Edit)
            {
                //Do nothin
            }
            else
            {
                throw new NotImplementedException();
            }
            MarkChanged(false);

            return true;
        }
        private void _btnApply_Click(object sender, EventArgs e)
        {
            ApplyChanges(ApplyChanges);
        }
        private void _btnCancel_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }
        private void MarkChanged(bool changed)
        {
            _btnApply.Enabled = changed;
        }
        private void _btnOk_Click(object sender, EventArgs e)
        {
            ApplyChangesAndClose(ApplyChanges);
        }
        private void _btnSelectPreview_Click(object sender, EventArgs e)
        {
            MarkChanged(true);
        }

        private void _txtName_TextChanged(object sender, EventArgs e)
        {
            MarkChanged(true);
        }

        private void _btnEditAnimations_Click(object sender, EventArgs e)
        {
            MarkChanged(true);
        }
    }
}
