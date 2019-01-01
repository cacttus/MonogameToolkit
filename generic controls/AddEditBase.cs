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
    public enum AddEditMode
    {
        Add, Edit
    }
    public partial class AddEditBase : ToolWindowBase
    {
        private string _strBaseTitle = "";
        private AddEditMode _mode = AddEditMode.Add;
        public AddEditMode AddEditMode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
                UpdateTitle();
            }
        }
        public AddEditBase()
        {
        //needed to move settitle
        }
        private void SetTitle(string title)
        {
            _strBaseTitle = title;
            Title = title;
        }
        private void UpdateTitle()
        {
            if (AddEditMode == AddEditMode.Add)
            {
                Title = "Add " + _strBaseTitle;
            }
            else
            {
                Title = "Edit " + _strBaseTitle;
            }

        }

        private void AddEditBase_Load(object sender, EventArgs e)
        {

        }
    }
}
