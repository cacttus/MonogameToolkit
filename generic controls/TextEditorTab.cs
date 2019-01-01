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

            string[] files = Globals.GetValidOpenSaveUserFile(this, true, Globals.ProjectFilter,Globals.ProjectExt, initdir);
            if (files.Length == 1)
            {
                File.SaveAs(files[0]);
            }
        }
        public void Populate(MonoEditFile file)
        {
            File = file;

            string text = System.IO.File.ReadAllText(File.LoadedOrSavedFileName);
            SavedFileContents = text;
            PrettyPrint(text);
            //TextBox.Text = text;
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
            Color fore = TextForeColor;

            foreach (char c in input)
            {
                if (Char.IsWhiteSpace(c) || c==',' || c==':')
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
                }
                else if (Char.IsNumber(c))
                {
                    if (in_text == false)
                    {
                        if (in_string == false)
                        {
                            fore = NumberColor;
                            in_nr = true;
                        }
                    }
                }
                else if(c=='\"' || c == '\'')
                {
                    if (in_string)
                    {
                        in_string = false;
                    }
                    else
                    {
                        in_string = true;
                        fore = StringColor;
                    }
                }
                else if (char.IsLetter(c))
                {
                    if (in_string == false)
                    {
                        fore = TextForeColor;
                        in_text = true;
                    }
                }
                else
                {
                    fore = TextForeColor;
                }

                build += c;
            }

            TextBox.AppendText(build, fore);


        }
        public void Format()
        {
            string e = System.IO.Path.GetExtension(File.LoadedOrSavedFileName);
            if(e.ToLower().Equals(".json"))
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
            if (String.Equals(_rtbText.Text, Equals(SavedFileContents)) == false)
            {
                MarkChanged();
            }
            else
            {
                ClearChanged();
            }
        }
    }
}
