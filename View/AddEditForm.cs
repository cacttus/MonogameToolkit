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
        Action _add;
        Action _remove;
        public AddEditItem()
        {
           
            InitializeComponent();
        }
        public void Init(Action add, Action remove)
        {
            _add = add;
            _remove = remove;
        }
        public Panel SpriteListViewPanel { get{ return _pnlSpriteListView; } }

        private void AddEditItem_Load(object sender, EventArgs e)
        {
            Globals.SetTooltip(_btnAdd, Phrases.AddItemToCollection);
            Globals.SetTooltip(_btnRemove, Phrases.RemoveItemToCollection);

            ThemeApplier.SetBackgroundImage(_btnAdd, "appbar.add.png");
            ThemeApplier.SetBackgroundImage(_btnRemove, "appbar.cancel.png");
        }

        private void _btnAdd_Click(object sender, EventArgs e)
        {
            _add();
        }

        private void _btnRemove_Click(object sender, EventArgs e)
        {
            _remove();
        }
    }
}
