using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Monoedit
{
    public partial class MonoEditTabContent : MetroUserControl
    {
        public string TabHeader { get; set; }
        private bool _bChanged = false;
        public bool Changed
        {
            get { return _bChanged; }
            set
            {
                _bChanged = value;
                UpdateTabHeader();
            }
        }

        public void UpdateTabHeader()
        {
            if (TabHeader == null)
            {
                TabHeader = "";
            }

            TabHeader = GetTabHeaderText();

            if (_bChanged)
            {
                TabHeader = TabHeader + '*';
            }

            Globals.MainForm.TabHeaderChanged(this);
        }
        public virtual void Populate(object obj)
        {
            //You must implement this method. ina  superclass
            throw new NotImplementedException();
        }
        public virtual string GetTabHeaderText()
        {
            throw new NotImplementedException();
        }

        public void MarkChanged() { Changed = true; }
        public void ClearChanged() { Changed = false; }

        //Must override
        public virtual void Save()
        {
        }
        public virtual void SaveAs()
        {
        }


        public MonoEditTabContent()
        {
            InitializeComponent();
        }

        private void MonoEditTab_Load(object sender, EventArgs e)
        {

        }
    }
}
