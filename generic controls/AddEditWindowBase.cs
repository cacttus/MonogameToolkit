using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

    public partial class AddEditWindowBase : MonoEditForm
    {
        public AddEditMode AddEditMode { get; set; } = AddEditMode.Add;
        public new bool? DialogResult { get; set; } = null;
        public EditStatus EditStatus { get; set; } = EditStatus.Unchanged;
        public int WindowId { get; set; }
        public string Title { get; set; } = "Title";

        private static int WindowIdGen = 1;

        //Create or copy your add/edit form object with these
        protected virtual void AddObject() { throw new NotImplementedException(); }
        protected virtual void EditObject(object obj) { throw new NotImplementedException(); }
        protected virtual void LoadData() { throw new NotImplementedException(); }
        protected virtual void SaveData() { throw new NotImplementedException(); }

        protected bool CheckValidName(List<string> results, MetroTextBox textValue, string fieldName)
        {
            bool b = true;
            if (string.IsNullOrEmpty(textValue.Text))
            {
                results.Add(Translator.Translate(Phrases.NoTextField).Replace("{0}", fieldName));
                b = false;
            }

            if (!Regex.IsMatch(textValue.Text, @"^[a-zA-Z0-9_-]+$"))
            {
                results.Add(Translator.Translate(Phrases.InvalidTextField).Replace("{0}", fieldName));
                b = false;
            }


            return b;
        }

        private void ToolWindowBase_Load(object sender, EventArgs e)
        {

        }

        public void ShowForm(AddEditMode e, IWin32Window owner,
            Phrase addEditTitle, 
            object rsc, Action<DialogResult?> afterShow)
        {
            AddEditMode = e;

            if (AddEditMode == AddEditMode.Add)
            {
                AddObject();
            }
            else
            {
                EditObject(rsc);
            }

            Title = Translator.Translate(addEditTitle);

            Globals.MainForm.ShowForm(Title, this, true, afterShow, owner);
        }

        public AddEditWindowBase()
        {
            WindowId = WindowIdGen++;

            //**Must be set to true
            AllowDrop = true;
        }

        //"Ok" button
        protected void ApplyChangesAndClose(Func<bool> postValidate)
        {
            DialogResult = true;
            if (ApplyChanges(postValidate))
            {
                Close();
            }
        }
        //"Cancel" button
        public virtual bool CancelChanges()
        {
            DialogResult = false;
            Close();
            return true;
        }
        // "Apply" button
        protected bool ApplyChanges(Func<bool> postValidate)
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
                    bool post = postValidate();

                    //**After we save and validate then set the mode to edit.
                    AddEditMode = AddEditMode.Edit;

                    return post;
                }
            }
            catch (Exception ex)
            {
                Globals.LogError(ex.ToString());
                return false;
            }
        }

        protected new virtual List<string> Validate()
        {
            throw new NotImplementedException();
            return new List<string>();
        }


    }
}
