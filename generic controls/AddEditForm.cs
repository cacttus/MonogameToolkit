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
    public partial class AddEditItem : MonoEditForm
    {
        Action<SpriteListView> _addClick = null;
        Action<SpriteListView, object> _editClick = null;
        Action<SpriteListView, List<object>> _removeClick = null;
        SpriteListView SpriteListView = null;

        public AddEditItem()
        {
            InitializeComponent();
        }
        private void AddEditItem_Load(object sender, EventArgs e)
        {
            Globals.SetTooltip(_btnAdd, Phrases.AddItem);
            Globals.SetTooltip(_btnRemove, Phrases.RemoveItem);
            Globals.SetTooltip(_btnCopy, Phrases.CopyItem);
            Globals.SetTooltip(_btnEdit, Phrases.EditItem);
            Globals.SetTooltip(_btnRefresh, Phrases.RefreshForm);

            ThemeApplier.SetBackgroundImage(_btnAdd, "appbar.add.png");
            ThemeApplier.SetBackgroundImage(_btnCopy, "appbar.page.copy.png");
            ThemeApplier.SetBackgroundImage(_btnRefresh, "appbar.refresh.png");
            ThemeApplier.SetBackgroundImage(_btnEdit, "appbar.edit.png");
            ThemeApplier.SetBackgroundImage(_btnRemove, "appbar.cancel.png");
        }
        public void Init(Action<SpriteListView> add,
            Action<SpriteListView, object> edit,
            Action<SpriteListView, List<object>> remove, 
            Func<SpriteListView, List<SpriteListViewItem>> getframes)
        {
            _addClick = add;
            _editClick = edit;
            _removeClick = remove;

            SpriteListView = new SpriteListView(getframes, remove);
            Globals.SwapControl(_pnlSpriteListView, SpriteListView);
            SpriteListView.OnRefresh = () => {
                bool isSel = SpriteListView.GetSelectedObject() != null;
                _btnEdit.Enabled = _btnRemove.Enabled = _btnCopy.Enabled = isSel;

                if (isSel == false)
                {
                    ThemeApplier.SetBackgroundImage(_btnEdit, "appbar.edit.png", true);
                    ThemeApplier.SetBackgroundImage(_btnRemove, "appbar.cancel.png", true);
                    ThemeApplier.SetBackgroundImage(_btnCopy, "appbar.page.copy.png", true);
                }
                else
                {
                    ThemeApplier.SetBackgroundImage(_btnEdit, "appbar.edit.png");
                    ThemeApplier.SetBackgroundImage(_btnRemove, "appbar.cancel.png");
                    ThemeApplier.SetBackgroundImage(_btnCopy, "appbar.page.copy.png");
                }
            };

            SpriteListView.UpdateListView();
        }

        private void _btnAdd_Click(object sender, EventArgs e)
        {
            _addClick?.Invoke(SpriteListView);
        }
        private void _btnRemove_Click(object sender, EventArgs e)
        {
            _removeClick?.Invoke(SpriteListView, SpriteListView.GetSelectedObjects());
        }
        private void _btnRefresh_Click(object sender, EventArgs e)
        {
            SpriteListView.UpdateListView();
        }
        private void _btnEdit_Click(object sender, EventArgs e)
        {
            _editClick?.Invoke(SpriteListView, SpriteListView.GetSelectedObject());
        }
    }
}
