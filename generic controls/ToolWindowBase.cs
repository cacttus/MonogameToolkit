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
    public enum EditStatus
    {
        Unchanged,
        Modified
    }

    public partial class ToolWindowBase : MonoEditForm
    {
        // public string Title = "";
        public new bool? DialogResult = null;

        public EditStatus EditStatus { get; set; }

        public Action AfterShowDialog = null;
        public int WindowId { get; set; }
        static int WindowIdGen = 1;
        public string Title { get; set; } = "Title";
        //TODO: implement these things
        //public SizeToContent SizeToContent { get; set; } = SizeToContent.Manual;
        //public ResizeMode ResizeMode { get; set; } = ResizeMode.CanResize;
        public ToolWindowBase()
        {
            WindowId = WindowIdGen++;

            //**Must be set to true
            AllowDrop = true;
            this.DragEnter += (x, e) =>
            {
                int n = 0;
                n++;

            };
            //this.Drop += (x, e) =>
            //{
            //    int n = 0;
            //    n++;
            //};
        }


        public virtual bool OkButtonClicked()
        {
            DialogResult = true;
            Close();
            return true;
        }
        public virtual bool CancelButtonClicked()
        {
            DialogResult = false;
            Close();
            return true;
        }

        public virtual bool OnClose()
        {
            //Return false to prevent hte window from closing, and doing some other logic
            return true;
        }

        //public void Show()
        //{
        //    Globals.MainWindow.ShowForm(Title, this, false);
        //}
        public void ShowDialog(Action afterShowDialog)
        {
            AfterShowDialog = afterShowDialog;
            Globals.MainForm.ShowForm(Title, this, true, afterShowDialog);
        }
        //public void Hide()
        //{
        //    Globals.MainWindow.HideForm(WindowId);
        //}
        //public void Close()
        //{
        //    Globals.MainWindow.CloseWindow(WindowId);
        //}
        protected new virtual List<string> Validate() { return new List<string>(); }

        protected bool SaveOnly(Func<bool> postValidate)
        {
            try
            {
                List<string> results = Validate();
                if (results.Count > 0)
                {
                    //ShowValidationError()
                    string msg = Translator.Translate(Phrases.PleaseCorrectTheFollowingErrors) + 
                        Environment.NewLine + results.Aggregate((x, y) => x + Environment.NewLine + y) + Environment.NewLine;
                    Globals.ShowInfo(msg);
                    return false;
                }
                else
                {
                    return postValidate();
                }
            }
            catch (Exception ex)
            {
                Globals.LogError(ex.ToString());
                return false;
            }
        }

        protected void SaveAndClose(Func<bool> postValidate)
        {
            if (SaveOnly(postValidate))
            {
                Close();
            }
        }

        private void ToolWindowBase_Load(object sender, EventArgs e)
        {

        }
    }
}
