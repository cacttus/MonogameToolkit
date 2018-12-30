using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace Monoedit
{
    public partial class OptionsForm : MonoEditForm
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            LoadData();
            
            Globals.MainForm.Forms.Add(this);
        }

        private void LoadData()
        {
            //The file is already loaded from MainForm don't load it again 
            Globals.SelectCboItem(_cboLanguage, Globals.MainForm.OptionsFile.SelectedLanguage.ToString(), 0);
            Globals.SelectCboItem(_cboTheme, Globals.MainForm.OptionsFile.Theme.ToString(), 0);
        }

        private void SaveData()
        {
            Globals.MainForm.OptionsFile.SelectedLanguage = SelectedLang();
            Globals.MainForm.OptionsFile.Save(Globals.MainForm.OptionsFile.FileLoc());
        }

        LanguageCode SelectedLang()
        {
            string lang = _cboLanguage.SelectedItem as string;
            LanguageCode code = LanguageCode.English;

            string eng = Translator.GetEnglish(lang);

            Enum.TryParse(eng, out code);
            return code;
        }
        MetroFramework.MetroThemeStyle SelectedTheme()
        {
            string lang = _cboTheme.SelectedItem as string;
            MetroFramework.MetroThemeStyle code = MetroFramework.MetroThemeStyle.Dark;

            string eng = Translator.GetEnglish(lang);

            Enum.TryParse(eng, out code);
            return code;
        }

        
        private void _cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Translator.SwitchLanguage(SelectedLang());
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            SaveData();
            LoadData();
            Close();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {

            Globals.MainForm.OptionsFile = OptionsFile.Load(Globals.MainForm.OptionsFile.FileLoc());


            Close();
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globals.MainForm.Forms.Remove(this);
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThemeApplier.SwitchTheme(SelectedTheme());
        }
    }
}
