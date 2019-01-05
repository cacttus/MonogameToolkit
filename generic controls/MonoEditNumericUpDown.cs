using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monoedit
{
    public partial class MonoEditNumericUpDown : MetroFramework.Controls.MetroUserControl
    {
        public MonoEditNumericUpDown()
        {
            InitializeComponent();
        }

        public int Min { get; set; } = 0;
        public int Max { get; set; } = 100;
        public int Value
        {
            get
            {
                int n = 0;
                Int32.TryParse(_txtValue.Text, out n);
                return n;
            }
            set
            {
                _txtValue.Text = value.ToString();
            }
        }

        private void MonoEditNumericUpDown_Load(object sender, EventArgs e)
        {

        }

        private void _btnUp_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (Int32.TryParse(_txtValue.Text, out n))
            {
                n = CheckRange(n + 1);
                _txtValue.Text = n.ToString();
            }

        }
        private int CheckRange(int n)
        {
            if (n > Max) n = Max;
            if (n < Min) n = Min;
            return n;
        }
        private void _btnDown_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (Int32.TryParse(_txtValue.Text, out n))
            {
                n = CheckRange(n - 1);
                _txtValue.Text = n.ToString();
            }
        }

        private void _txtValue_Click(object sender, EventArgs e)
        {

        }
    }
}
