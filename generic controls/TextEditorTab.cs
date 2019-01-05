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
using Newtonsoft.Json;
namespace Monoedit
{
    public partial class TextEditorTab : MonoEditTabContent
    {
        public MonoEditFile File { get; private set; }
        public RichTextBox TextBox { get { return _rtbText; } }
        private RichTextBox _rtbText;//This is in the designer
        bool SuspendTextboxUpdates = false;

        public string SavedFileContents = ""; //used to compare for changes

        public TextEditorTab()
        {
            InitializeComponent();
        }
        private void TextEditorTab_Load(object sender, EventArgs e)
        {

        }
        public override void Save()
        {
            File.Save();
        }
        public override void SaveAs()
        {
            string initdir = System.IO.Path.GetDirectoryName(Globals.MainForm.ProjectFile.LoadedOrSavedFileName);

            string[] files = Globals.GetValidOpenSaveUserFile(this, true, Globals.ProjectFilter, Globals.ProjectExt, initdir);
            if (files.Length == 1)
            {
                File.SaveAs(files[0]);
            }
        }
        public override void Populate(object obj)
        {
            MonoEditFile file = obj as MonoEditFile;

            System.Diagnostics.Debug.Assert(file != null);
            File = file;
            string text = System.IO.File.ReadAllText(File.LoadedOrSavedFileName);
            SavedFileContents = text;
            _rtbText.Text = text;
        }
        public override string GetTabHeaderText()
        {
            if (this.File != null)
            {
                return System.IO.Path.GetFileName(File.LoadedOrSavedFileName);
            }
            return "";
        }
        private bool IsDelim(char c)
        {
            return Char.IsWhiteSpace(c) || c == ',' || c == ':' || c == '}' || c == '{';
        }
        public void PrettyPrint(string input)
        {
            _rtbText.Clear();

            Color StringColor = ThemeApplier.StringColor();
            Color NumberColor = ThemeApplier.NumberColor();
            Color TextForeColor = ThemeApplier.EditorTextColor();

            _rtbText.BackColor = ThemeApplier.EditorBackColor();

            int brace_level = 0;
            string build = "";
            bool in_nr = false;
            bool in_text = false;
            bool in_string = false;
            char parent_string = '\"';//whether we are in single/or dobule quote string
            Color fore = TextForeColor;

            Action spit = () =>
            {
                //End token.
                if (build.Length > 0)
                {
                    TextBox.AppendText(build, fore);
                    build = "";
                }

                //Reset parse state
                in_nr = false;
                in_text = false;
                fore = TextForeColor;
            };

            foreach (char c in input)
            {
                //A - if delim, then spit out current build and reset state.
                //B - set font and soforth.
                if (IsDelim(c))
                {
                    if (in_string == false)
                    {
                        spit();
                    }
                }
                else if (Char.IsNumber(c))
                {
                    if (in_string == false)
                    {
                        if (in_nr == false && in_text == false)
                        {
                            spit();

                            fore = NumberColor;
                            in_nr = true;
                        }
                    }
                }
                else if (char.IsLetter(c))
                {
                    if (in_string == false)
                    {
                        if (in_text == false)
                        {
                            if (in_nr == false)
                            {
                                spit();//only spit if we aren't in an identifier
                            }
                            fore = TextForeColor;
                            in_text = true;
                        }
                    }
                }
                else if (c == '\"' || c == '\'')
                {
                    if (in_string == false)
                    {
                        spit();

                        in_string = true;
                        fore = StringColor;
                        parent_string = c;
                    }
                    else
                    {
                        //Allow for nested string types.
                        if (parent_string == c)
                        {
                            in_string = false;
                        }
                    }
                }
                else
                {
                    if (in_string == false)
                    {
                        fore = TextForeColor;
                    }
                }

                build += c;
            }

            TextBox.AppendText(build, fore);
        }
        public void Format()
        {
            string e = System.IO.Path.GetExtension(File.LoadedOrSavedFileName);
            if (e.ToLower().Equals(".json"))
            {
                //Format JSON
                PrettyPrint(FormatJson(TextBox.Text));
            }
            else
            {
                Globals.LogError("Could not format file type '" + e + "'");
            }
        }
        private static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        private void TextEditor_Load(object sender, EventArgs e)
        {
            TextBox.ForeColor = ThemeApplier.MenuForeColor();
            TextBox.BackColor = ThemeApplier.MenuBackColor();
        }

        private void _rtbText_TextChanged(object sender, EventArgs e)
        {
            if (SuspendTextboxUpdates == false)
            {
                SuspendTextboxUpdates = true;
                string t = _rtbText.Text;
                _rtbText.Text = "";
                PrettyPrint(t);

                if (String.Equals(_rtbText.Text, SavedFileContents) == false)
                {
                    MarkChanged();
                }
                else
                {
                    ClearChanged();
                }
                SuspendTextboxUpdates = false;
            }
        }
    }
}
