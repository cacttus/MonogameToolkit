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
        Action<SpriteListView, List<object>> _removeClick = null;

        public AddEditItem()
        {

            InitializeComponent();
        }

        SpriteListView SpriteListView = null;

        public void Init(Action<SpriteListView> add, Action<SpriteListView, List<object>> remove, 
            Func<SpriteListView, List<SpriteListViewItem>> getframes)
        {
            _addClick = add;
            _removeClick = remove;

            SpriteListView = new SpriteListView(getframes, remove);
            Globals.SwapControl(_pnlSpriteListView, SpriteListView);
        }

        private void AddEditItem_Load(object sender, EventArgs e)
        {
            Globals.SetTooltip(_btnAdd, Phrases.AddItemToCollection);
            Globals.SetTooltip(_btnRemove, Phrases.RemoveItemToCollection);

            ThemeApplier.SetBackgroundImage(_btnAdd, "appbar.add.png");
            ThemeApplier.SetBackgroundImage(_btnRemove, "appbar.cancel.png");
            ThemeApplier.SetBackgroundImage(_btnCopy, "appbar.page.copy.png");
        }
        private void _btnAdd_Click(object sender, EventArgs e)
        {
            _addClick?.Invoke(SpriteListView);
        }
        private void _btnRemove_Click(object sender, EventArgs e)
        {
            _removeClick?.Invoke(SpriteListView, SpriteListView.GetSelectedObjects());
        }
    }
}
