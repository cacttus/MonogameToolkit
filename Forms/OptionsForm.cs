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
using MetroFramework;
using MetroFramework.Controls;
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

            string startupOptionDesc = Globals.GetDescription(Globals.MainForm.OptionsFile.StartupOption);
            Globals.SelectCboItem(_cboOnStartup, startupOptionDesc, 0);
        }

        private void SaveData()
        {
            Globals.MainForm.OptionsFile.SelectedLanguage = SelectedLang();
            Globals.MainForm.OptionsFile.StartupOption = Globals.GetEnumFromComboBox<StartupOption>(_cboOnStartup);
            Globals.MainForm.OptionsFile.SaveAs(Globals.MainForm.OptionsFile.FileLoc());
        }

        LanguageCode SelectedLang()
        {
            return Globals.GetEnumFromComboBox<LanguageCode>(_cboLanguage);
        }

        MetroThemeStyle SelectedTheme()
        {
            MetroThemeStyle style = Globals.GetEnumFromComboBox<MetroFramework.MetroThemeStyle>(_cboTheme);
            return style;
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
            Globals.MainForm.LoadOptions();
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

        private void _btnClearRecentFiles_Click(object sender, EventArgs e)
        {
            Globals.MainForm.OptionsFile.RecentFiles.Clear();
            Globals.MainForm.OptionsFile.Save();
            Globals.MainForm.LoadRecentFiles();
        }
    }
}
