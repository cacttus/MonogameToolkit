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
    public partial class AddEditItem : Form
    {
        public AddEditItem()
        {
            InitializeComponent();
        }
        public Panel SpriteListViewPanel { get{ return _pnlSpriteListView; } }

        private void AddEditItem_Load(object sender, EventArgs e)
        {

        }
    }
}
