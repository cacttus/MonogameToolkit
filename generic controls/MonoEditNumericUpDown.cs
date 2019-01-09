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

        public Action ValueChanged { get; set; } = null;
        public double Min { get; set; } = 0;
        public double Max { get; set; } = 100;
        public double Value
        {
            get
            {
                double n = 0;
                Double.TryParse(_txtValue.Text, out n);
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
            double n = 0;
            if (Double.TryParse(_txtValue.Text, out n))
            {
                n = CheckRange(n + 1);
                _txtValue.Text = n.ToString();
            }

        }
        private double CheckRange(double n)
        {
            if (n > Max) n = Max;
            if (n < Min) n = Min;
            return n;
        }
        private void _btnDown_Click(object sender, EventArgs e)
        {
            double n = 0;
            if (double.TryParse(_txtValue.Text, out n))
            {
                n = CheckRange(n - 1);
                _txtValue.Text = n.ToString();
            }
        }
        private void _txtValue_Click(object sender, EventArgs e)
        {
        }
        private void _txtValue_TextChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke();
        }
        private void _txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            MetroFramework.Controls.MetroTextBox mt = (sender as MetroFramework.Controls.MetroTextBox);
            if (mt != null)
            {
                if ((e.KeyChar == '.') && (mt.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
