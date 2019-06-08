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
    public partial class AnimationEditorForm : AddEditWindowBase
    {
        SpriteObjectAnimation SpriteObjectAnimation = null;
        public AnimationEditorForm()
        {
            InitializeComponent();
        }
        private void SpriteEditor_Load(object sender, EventArgs e)
        {

        }

        private void SpriteEditor_Load_1(object sender, EventArgs e)
        {

        }

        protected override void AddObject()
        {
            SpriteObjectAnimation = new SpriteObjectAnimation();
        }
        protected override void EditObject(object obj)
        {
            SpriteObjectAnimation = obj as SpriteObjectAnimation;
        }
        protected override void LoadData()
        {
            throw new NotImplementedException();
        }
        protected override void SaveData()
        {
            throw new NotImplementedException();
        }

        private void _btnSetPreview_Click(object sender, EventArgs e)
        {
            //Sets the current sprite animation (visually, as a bitmap) as the preview image for the sprite in the editor.
        }

        private bool ApplyChanges()
        {

            return true;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyChanges(ApplyChanges);
        }
        private void saveCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyChangesAndClose(ApplyChanges);
        }
        private void closeWithoutSavingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }
    }
}
