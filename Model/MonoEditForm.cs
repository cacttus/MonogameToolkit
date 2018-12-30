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
using MetroFramework.Interfaces;

namespace Monoedit
{
    public partial class MonoEditForm : MetroForm
    {
        public MonoEditForm()
        {
            InitializeComponent();
        }

        private void MonoEditForm_Load(object sender, EventArgs e)
        {
            ApplyStyle();
        }

        public void ApplyStyle()
        {
            var manager = new MetroFramework.Components.MetroStyleManager(new Container());
            manager.Owner = this;
            if(Globals.MainForm!=null && Globals.MainForm.OptionsFile != null)
            {

                manager.Theme = Globals.MainForm.OptionsFile.Theme;
            }
            else
            {
                manager.Theme = MetroFramework.MetroThemeStyle.Dark;
            }
            Theme = manager.Theme;

            foreach (Control c in this.Controls)
            {
                if (c != null)
                {
                    if (c as IMetroControl != null)
                    {
                        if (manager != null)
                        {
                            (c as IMetroControl).Theme = manager.Theme;
                            c.Refresh();
                        }
                    }
                    if(c as MenuStrip != null)
                    {
                        SetMenuColor(c as MenuStrip);
                    }
                }
            }
            Refresh();
        }
        void SetMenuColor(MenuStrip ms)
        {
            foreach (ToolStripMenuItem m in ms.Items)
            {
                SetMenuColor(m);
            }
            ms.ForeColor = ThemeApplier.ForeColor();
            ms.BackColor = ThemeApplier.BackColor();
        }
        void SetMenuColor(ToolStripMenuItem m)
        {
            //ToolStripMenuItem mi = m as ToolStripMenuItem;
            m.ForeColor = ThemeApplier.ForeColor();
            m.BackColor = ThemeApplier.BackColor();
            foreach (ToolStripMenuItem m2 in m.DropDownItems)
            {
                SetMenuColor(m2);
            }
        }
    }
}
