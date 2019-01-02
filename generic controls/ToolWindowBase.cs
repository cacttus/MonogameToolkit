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
    public enum AddEditMode
    {
        Add, Edit
    }
    public partial class ToolWindowBase : MonoEditForm
    {
        public AddEditMode AddEditMode { get; set; } = AddEditMode.Add;
        public new bool? DialogResult { get; set; } = null;
        public EditStatus EditStatus { get; set; } = EditStatus.Unchanged;
        public int WindowId { get; set; }
        public string Title { get; set; } = "Title";

        protected Action AfterShowDialog { get; set; } = null;
        private static int WindowIdGen = 1;

        
        public ToolWindowBase()
        {
            WindowId = WindowIdGen++;

            //**Must be set to true
            AllowDrop = true;
        }
        private void ToolWindowBase_Load(object sender, EventArgs e)
        {

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
        //public virtual void ShowForm(AddEditMode mode, IWin32Window owner, Action afterShowDialog)
        //{

        //}
        protected new virtual List<string> Validate()
        {
            return new List<string>();
        }
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
  
    }
}
