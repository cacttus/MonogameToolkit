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

                if (TabHeader == null)
                {
                    TabHeader = "";
                }

                TabHeader.Replace("*", "");
                

                if (_bChanged)
                {
                    TabHeader = TabHeader + '*';
                }


            }
        }

        public void MarkChanged() { Changed = true; }
        public void ClearChanged() { Changed = true; }

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
