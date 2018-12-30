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
    public partial class CustomMessageBox : MonoEditForm
    {
        MessageBoxButtons Buttons;
        DialogResult result = DialogResult.OK;
        List<string> CustomButtonOptions = null;

        public CustomMessageBox()
        {
            InitializeComponent();
        }
        private void CustomMessageBox_Load(object sender, EventArgs e)
        {

        }
        private void SetIcon(System.Drawing.Icon icon)
        {
            this.Icon = icon;
        }
        public CustomMessageBox(Phrase contents, Phrase caption, MessageBoxButtons button, MessageBoxIcon img, List<string> customButtonOptions = null)
        {
            CustomButtonOptions = customButtonOptions;
            InitializeComponent();

            Text = Translator.Translate(caption);
            _txtMessage.Text = Translator.Translate(contents);
            Buttons = button;

            if (button == MessageBoxButtons.OK)
            {
                _btnOkYes.Text = Translator.Translate("Ok");
                _btnOkYes.Visible = true;
                _btnCancelNo.Visible = false;
                _btnCancel.Visible = false;
            }
            else if (button == MessageBoxButtons.OKCancel)
            {
                _btnOkYes.Text = Translator.Translate("Ok");
                _btnOkYes.Visible = true;
                _btnCancelNo.Text = Translator.Translate("Cancel");
                _btnCancelNo.Visible = true;
                _btnCancel.Visible = false;
            }
            else if (button == MessageBoxButtons.YesNo)
            {
                _btnOkYes.Text = Translator.Translate("Yes");
                _btnOkYes.Visible = true;
                _btnCancelNo.Text = Translator.Translate("No");
                _btnCancelNo.Visible = true;
                _btnCancel.Visible = false;
            }
            else if (button == MessageBoxButtons.YesNoCancel)
            {
                _btnOkYes.Text = Translator.Translate("Yes");
                _btnOkYes.Visible = true;
                _btnCancelNo.Text = Translator.Translate("No");
                _btnCancelNo.Visible = true;
                _btnCancel.Text = Translator.Translate("Cancel");
                _btnCancel.Visible = true;
            }

            //Change the button text to use pref.
            if (customButtonOptions != null)
            {
                if (button == MessageBoxButtons.OK && customButtonOptions.Count == 1)
                {
                    _btnOkYes.Text = SetTb(customButtonOptions[0]);
                }
                if ((button == MessageBoxButtons.YesNo || button == MessageBoxButtons.OKCancel) && customButtonOptions.Count == 2)
                {
                    _btnOkYes.Text = SetTb(customButtonOptions[0]);
                    _btnCancelNo.Text = SetTb(customButtonOptions[1]);
                }
                if (button == MessageBoxButtons.YesNoCancel && customButtonOptions.Count == 3)
                {
                    _btnOkYes.Text = SetTb(customButtonOptions[0]);
                    _btnCancelNo.Text = SetTb(customButtonOptions[1]);
                    _btnCancel.Text = SetTb(customButtonOptions[2]);
                }
            }

            if (img == MessageBoxIcon.Asterisk) { SetIcon(SystemIcons.Asterisk); }
            if (img == MessageBoxIcon.Error) { SetIcon(SystemIcons.Error); }
            if (img == MessageBoxIcon.Exclamation) { SetIcon(SystemIcons.Exclamation); }
            if (img == MessageBoxIcon.Hand) { SetIcon(SystemIcons.Hand); }
            if (img == MessageBoxIcon.Information) { SetIcon(SystemIcons.Information); }
            if (img == MessageBoxIcon.None) { }
            if (img == MessageBoxIcon.Question) { SetIcon(SystemIcons.Question); }
            //if(img == MessageBoxIcon.Stop) { SetIcon(SystemIcons.Stop); }
            if (img == MessageBoxIcon.Warning) { SetIcon(SystemIcons.Warning); }


            if (button == MessageBoxButtons.OK)
            {
                _btnCancel.Visible = false;
            }
        }
        private string SetTb(string msg)
        {
            return msg;
            //TextBlock b = new TextBlock();
            //b.Text = msg;
            //b.TextWrapping = TextWrapping.Wrap;
            //b.Margin = new Thickness(5, 5, 5, 5);

            //_grdButtonGrid.Columns = 1;
            //_grdButtonGrid.Rows = 3;
            //return b;
        }
        public static DialogResult Show(Phrase contents, Phrase caption, MessageBoxButtons button, MessageBoxIcon img,
            List<string> customButtonOptions = null)
        {
            CustomMessageBox b = new CustomMessageBox(contents, caption, button, img, customButtonOptions);

            b.ShowDialog();

            return b.result;
        }

        private void _btnCancelNo_Click(object sender, EventArgs e)
        {
            if (Buttons == MessageBoxButtons.OK || Buttons == MessageBoxButtons.OKCancel)
            {
                result = DialogResult.OK;
            }
            else if (Buttons == MessageBoxButtons.YesNo || Buttons == MessageBoxButtons.YesNoCancel)
            {
                result = DialogResult.No;
            }

            Hide();
        }

        private void _btnOkYes_Click(object sender, EventArgs e)
        {
            if (Buttons == MessageBoxButtons.OKCancel)
            {
                result = DialogResult.OK;
            }
            else if (Buttons == MessageBoxButtons.YesNo || Buttons == MessageBoxButtons.YesNoCancel)
            {
                result = DialogResult.Yes;
            }
            Hide();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            if (Buttons == MessageBoxButtons.YesNoCancel)
            {
                result = DialogResult.Cancel;
            }
            Hide();
        }

    }
}
