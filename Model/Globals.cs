using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Interfaces;
using MetroFramework.Components;
using MetroFramework;

namespace Monoedit
{
    public enum LanguageCode
    {
        English = 0,
        Spanish = 1,
    }
    public class Phrase
    {
        public Dictionary<LanguageCode, string> Text = new Dictionary<LanguageCode, string>();
        public int PhraseId { get; } = 0;//English phrase id 
        public Phrase(string english, string spanish)
        {


            Text.Add(LanguageCode.English, english);
            Text.Add(LanguageCode.Spanish, spanish);
            PhraseId = english.GetHashCode();
            Translator.AddPhrase(this);
        }
        //public Phrase(string no_translation_available)
        //{
        //    //Do not add the phrase - this constructor is only for untranslated items
        //    foreach (LanguageCode code in Enum.GetValues(typeof(LanguageCode)))
        //    {
        //        Text.Add(code, no_translation_available);
        //    }
        //    PhraseId = no_translation_available.GetHashCode();
        //    //Do not add the phrase - this constructor is only for untranslated items
        //}
        public string Trans(LanguageCode c)
        {
            string trans = "";
            if (Text.TryGetValue(c, out trans) == false)
            {
                throw new Exception("Failure: all Phrases must have some value (or empty string) for each language code ");
            }
            return trans;

        }

    }

    public class Phrases
    {
        //This does some crazy reverse lookups with a host of dictionaries for performance.
        public static Dictionary<LanguageCode, Dictionary<int, Phrase>> Lexicon = new Dictionary<LanguageCode, Dictionary<int, Phrase>>();
        public static Phrase AddItemToCollection = new Phrase("Add an item to the collection.", "Añadir un artículo a la colección.");
        public static Phrase RemoveItemToCollection = new Phrase("Remove an item from the collection.", "Eliminar un artículo de la colección.");
        public static Phrase Ok = new Phrase("Ok", "Vale");
        public static Phrase Cancel = new Phrase("Cancel", "Cancelar");
        public static Phrase File = new Phrase("File", "Limar");
        public static Phrase Exit = new Phrase("Exit", "Salir");
        public static Phrase Language = new Phrase("Language", "Lengua");
        public static Phrase FolderDoesNotExist = new Phrase("Folder does not exist.", "La carpeta no existe.");
        public static Phrase FileDoesNotExist = new Phrase("File does not exist.", "El archivo no existe.");
        public static Phrase Options = new Phrase("Options", "Opciones");
        public static Phrase View = new Phrase("View", "Ver");
        public static Phrase Sprites = new Phrase("Sprites", "Duendes");
        public static Phrase Objects = new Phrase("Objects", "Objetos");
        public static Phrase Layers = new Phrase("Layers", "Capas");
        public static Phrase Undo = new Phrase("Undo", "Deshacer");
        public static Phrase Redo = new Phrase("Redo", "Rehacer");
        public static Phrase Edit = new Phrase("Edit", "Editar");
        public static Phrase Tools = new Phrase("Tools", "útiles");
        public static Phrase Theme = new Phrase("Theme", "Tema");
        public static Phrase Light = new Phrase("Light", "Ligero");
        public static Phrase Dark = new Phrase("Dark", "Oscuro");
        public static Phrase English = new Phrase("English", "Inglés");
        public static Phrase Spanish = new Phrase("Spanish", "Español");
        public static Phrase Error = new Phrase("Error", "Error");
        public static Phrase Info = new Phrase("Info", "Información");
        public static Phrase New = new Phrase("&New", "&Nuevo");
        public static Phrase Open = new Phrase("&Open", "&Abierto");
        public static Phrase Save = new Phrase("&Save", "&Guardar");
        public static Phrase SaveAs = new Phrase("&Save As..", "&Guardar Como..");
        public static Phrase AddEdit = new Phrase("Add/Edit", "Añadir/Editar.");

    }

    //Applies global/General translation.
    public class Translator
    {
        public static string GetEnglish(string lang)
        {
            Phrase p = FindPhrase(lang, Globals.MainForm.OptionsFile.SelectedLanguage);
            if (p != null)
            {
                return p.Trans(LanguageCode.English);
            }
            return lang;
        }
        private static void AddPhraseForLang(LanguageCode code, Phrase p)
        {
            Dictionary<int, Phrase> dict = null;
            if (Phrases.Lexicon.TryGetValue(code, out dict) == false)
            {
                dict = new Dictionary<int, Phrase>();
                Phrases.Lexicon.Add(code, dict);
            }

            string trans = p.Trans(code);
            int hash = trans.GetHashCode();
            if (dict.Keys.Contains(hash))
            {
                //You'll get this if you have untranslated phrases. 
                //Forget empty strings.
                if (trans.Length > 0)
                {
                    Globals.MainForm.LogError("The phrase " + p + " was already found in the dictionary.");
                }
            }
            dict.Add(hash, p);
        }

        public static void AddPhrase(Phrase p)
        {
            //Don't call this directly, instead create a new phrase manuall.
            foreach (LanguageCode val in Enum.GetValues(typeof(LanguageCode)))
            {
                AddPhraseForLang(val, p);
            }
        }

        public static Phrase FindPhrase(string in_selected_lang, LanguageCode code)
        {
            //For the currently selected language find the translated phrase.
            string err = "No translation for '"
                    + in_selected_lang
                    + "' exists for the currently seelcted lang: '"
                    + code.ToString() + "'.";

            Dictionary<int, Phrase> dict = null;
            if (Phrases.Lexicon.TryGetValue(code, out dict) == false)
            {
                Globals.MainForm.LogError(err);

                //Return bad phrase.
                return null;
            }

            Phrase trans = null;
            if (dict.TryGetValue(in_selected_lang.GetHashCode(), out trans) == false)
            {
                Globals.MainForm.LogError(err);
                return null;
            }

            return trans;
        }

        private static bool SwitchingLanguage = false;
        public static void SwitchLanguage(LanguageCode newCode)
        {
            if (SwitchingLanguage == false)
            {
                SwitchingLanguage = true;

                TranslateUI(Globals.MainForm, Globals.MainForm.OptionsFile.SelectedLanguage, newCode);
                
                foreach (MetroForm f in Globals.MainForm.Forms)
                {
                    if (f.Visible)
                    {
                        TranslateUI(f, Globals.MainForm.OptionsFile.SelectedLanguage, newCode);
                    }
                }

                Globals.MainForm.OptionsFile.SelectedLanguage = newCode;
            }
            SwitchingLanguage = false;
        }

        public static void TranslateUI(Control cont, LanguageCode from, LanguageCode to)
        {
            //Translates the entire static form.
            try
            {
                TranslateGenericControl(cont, from, to);

                //Translates all elements on the page who have a "text" element
                foreach (Control child in cont.Controls)
                {
                    TranslateUI(child, from, to);
                }

                if (cont as MenuStrip != null)
                {
                    foreach (object child in (cont as MenuStrip).Items)
                    {
                        if (child as ToolStripMenuItem != null)
                        {
                            TranslateUI(child as ToolStripMenuItem, from, to);
                        }
                        else
                        {
                            Globals.MainForm.LogError("Failed to translate a menu item - no cast availabele for type '"
                                + child.GetType().ToString() + "'");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Globals.MainForm.LogError(ex.ToString());
            }
        }

        public static void TranslateUI(ToolStripMenuItem cont, LanguageCode from, LanguageCode to)
        {
            //Translates an entire UI of toolstripmenuitem
            try
            {
                TranslateGenericControl(cont, from, to);

                foreach (ToolStripMenuItem child in cont.DropDownItems)
                {
                    TranslateUI(child, from, to);
                }
            }
            catch (Exception ex)
            {
                Globals.MainForm.LogError(ex.ToString());
            }
        }

        private static void TranslateGenericControl(object cont, LanguageCode from, LanguageCode to)
        {
            //Translates a control if it has a "text" field.
            if (cont == null)
            {
                return;
            }


            //Try to translate combobox items.
            if (cont as ComboBox != null)
            {
                try
                {
                    string selected = "";
                    if ((cont as ComboBox).SelectedItem as string != null)
                    {
                        selected = (cont as ComboBox).SelectedItem as string;
                    }

                    List<string> data = new List<string>();
                    foreach (object item in (cont as ComboBox).Items)
                    {
                        if (item as String != null)
                        {
                            data.Add(Translate(item as string, from, to));
                        }
                    }

                (cont as ComboBox).Items.Clear();
                    foreach (string item in data)
                    {
                        (cont as ComboBox).Items.Add(item);
                    }

                    //Restore selected item
                    (cont as ComboBox).SelectedItem = selected;


                }
                catch (Exception ex)
                {
                    Globals.MainForm.LogError("Error translating combobox " + ex.ToString());
                }
            }

            //Generic "Text" Property translation
            if (cont.GetType().GetProperty("Text") != null)
            {
                string txt = cont.GetType().GetProperty("Text").GetValue(cont, null) as string;

                if (!string.IsNullOrEmpty(txt))
                {
                    string trans = Translator.Translate(txt, from, to);

                    cont.GetType().InvokeMember("Text",
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
                        Type.DefaultBinder, cont, new object[] { trans });

                    
                }
            }

            //A Refresh is required for Metro UI to update the header
            if (cont as MainForm != null)
            {
                (cont as MainForm).Refresh();
            }
        }

        public static string Translate(string in_english)
        {
            return Translate(in_english, LanguageCode.English, Globals.MainForm.OptionsFile.SelectedLanguage);
        }
        public static string Translate(string in_selected_lang, LanguageCode from, LanguageCode to)
        {
            Phrase p = FindPhrase(in_selected_lang, from);
            if (p == null)
            {
                return in_selected_lang;
            }
            return Translate(p, to);
        }

        public static string Translate(Phrase p, LanguageCode? toLang = null)
        {
            if (p == null)
            {
                return "";
            }
            if (toLang == null)
            {
                toLang = Globals.MainForm.OptionsFile.SelectedLanguage;
            }

            if (p.Text == null || p.Text.Count <= (int)toLang)
            {
                Globals.MainForm.LogError("Phrase " + p.PhraseId + " : '"
                    + ((p.Text != null && p.Text.Count > 0) ? p.Text[0] : "No Text Avail")
                    + "', didn't have a translated item for code : " + toLang.ToString());
            }

            return p.Trans(toLang.Value);
        }

    }


    /// <summary>
    /// Applies themes generally to MetroUI controls.
    /// </summary>
    public static class ThemeApplier
    {
        public static Color MenuColorBackDark = Color.FromArgb(255, 64, 64, 64);
        public static Color MenuColorForeDark = Color.FromArgb(255, 224, 224, 224);

        public static Color MenuColorBackLight = Color.FromArgb(255, 224, 224, 224);
        public static Color MenuColorForeLight = Color.FromArgb(255, 17, 17, 17);

        public static void SetBackgroundImage(Control a, string loc)
        {
            string dir = Assembly.GetEntryAssembly().Location;

            dir = Path.GetDirectoryName(dir);

            string theme = "dark";
            if (Globals.MainForm.OptionsFile.Theme == MetroThemeStyle.Dark)
            {
                theme = "dark";
            }
            else
            {
                theme = "light";
            }
            dir = Path.Combine(dir, "rsc", theme, loc);

            try
            {
                a.BackgroundImage = new Bitmap(dir);
                a.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

            }
            catch (Exception ex)
            {
                Globals.MainForm.LogError("Failed to load image '" + dir + "': " + ex.ToString());
            }
        }

        public static Color ForeColor()
        {
            if (Globals.MainForm.OptionsFile.Theme == MetroThemeStyle.Dark)
            {
                return MenuColorForeDark;
            }
            else
            {
                return MenuColorForeLight;
            }
        }
        public static Color BackColor()
        {
            if (Globals.MainForm.OptionsFile.Theme == MetroThemeStyle.Dark)
            {
                return MenuColorBackDark;
            }
            else
            {
                return MenuColorBackLight;
            }
        }

        public static void SwitchTheme(MetroFramework.MetroThemeStyle theme)
        {
            Globals.MainForm.OptionsFile.Theme = theme;
            Globals.MainForm.ApplyStyle();
            //ThemeUI(Globals.MainForm);
            //Globals.MainForm.MainForm_Load(new object(), new EventArgs());
            foreach (MonoEditForm f in Globals.MainForm.Forms)
            {
                f.ApplyStyle();
                //ThemeUI(f);
            }
        }


    }

    public class Globals
    {

        private static MainForm _objMainForm = null;
        public static MainForm MainForm { get { return _objMainForm; } }
        public static void SetMainWindow(MainForm w) { _objMainForm = w; }



        public static void SetTooltip(Control ctl, Phrase p, int show_duration = 3000)
        {
            ctl.MouseHover += (object xsender, EventArgs xe) =>
            {
                MetroFramework.Components.MetroToolTip t = new MetroFramework.Components.MetroToolTip();
                t.ReshowDelay = 1000;
                t.Theme = MetroFramework.MetroThemeStyle.Dark;
                t.UseFading = true;
                t.AutoPopDelay = show_duration;
                t.InitialDelay = 1500;
                t.IsBalloon = true;
                t.Show(Translator.Translate(p, Globals.MainForm.OptionsFile.SelectedLanguage), ctl);
            };

        }

        public static void SwapControl(Control a, Control b)
        {
            b.Width = a.Width;
            b.Height = a.Height;
            b.Dock = a.Dock;
            b.Anchor = a.Anchor;

            Control parent = a.Parent;
            if (parent != null)
            {
                parent.Controls.Remove(a);
                parent.Controls.Add(b);
            }

        }
        //public const string ProgramVersion = "0.01";
        public const string ProgramVersion = "0.02";
        public static double GetProgramVersion()
        {
            double d = 0;
            Double.TryParse(ProgramVersion, out d);
            return d;
        }
        public const string ApplicationTitle = "Indieworks";

        public static string SupportedLoadSpriteImageFilter = "Image Files (*.png;*.bmp;*.gif;*.jpg)|*.png;*.bmp;*.gif;*.jpg|All files (*.*)|*.*";
        public static string GifFilter = "Gif Files (*.gif)|*.gif;|All files (*.*)|*.*";
        public static string ExeFilter = "Exe Files (*.exe)|*.exe|All files (*.*)|*.*";
        public static string ProjectExt = ".iwp";
        public static string ProjectFilter = "Project Files (*" + ProjectExt + ")|*" + ProjectExt + "";
        public static string AllFilter = "All files (*.*)|*.*";


        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();

        }

        private static Random Random = new Random();
        public static double RandomDouble(double min, double max)
        {
            if (min > max)
            {
                double tmp = max;
                max = min;
                min = tmp;
            }
            return min + (max - min) * Random.NextDouble();
        }
        #region File & Path IO
        public static bool PathIsDirectory(string path)
        {
            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return true;
            }
            return false;
        }
        public static void CountItemsInDirectoryTree(string path, out int out_files, out int out_dirs)
        {
            out_files = 0;
            out_dirs = 0;

            if (!Globals.PathIsDirectory(path))
            {
                path = System.IO.Path.GetDirectoryName(path);
            }

            List<string> pathsToSearch = new List<string>();
            pathsToSearch.Add(path);

            while (pathsToSearch.Count > 0)
            {
                string curpath = pathsToSearch[0];
                pathsToSearch.RemoveAt(0);

                out_files += System.IO.Directory.GetFiles(curpath).Length;

                string[] dirs = System.IO.Directory.GetDirectories(curpath);

                out_dirs += dirs.Length;
                foreach (string dir in dirs)
                {
                    pathsToSearch.Add(dir);
                }
            }

        }
        public static void WipeDirectory(string path, bool deleteFileStructure = true, bool swallowErrors = true)
        {
            //Deletes all files from a directory tree and optionally wipes the whole thing.
            ProgressWindow pr = new ProgressWindow();
            pr.Execute((token) =>
            {
                if (!Globals.PathIsDirectory(path))
                {
                    path = System.IO.Path.GetDirectoryName(path);
                }

                int fileCount = 0, dirCount = 0;
                Globals.CountItemsInDirectoryTree(path, out fileCount, out dirCount);

                int maxFileCount = fileCount;

                List<string> pathsToSearch = new List<string>();
                pathsToSearch.Add(path);

                while (pathsToSearch.Count > 0)
                {
                    token.ThrowIfCancellationRequested();

                    string curpath = pathsToSearch[0];
                    pathsToSearch.RemoveAt(0);

                    string[] files = System.IO.Directory.GetFiles(curpath);
                    foreach (string file in files)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            if (swallowErrors == false)
                            {
                                throw ex;
                            }
                        }
                        fileCount--;
                        pr.UpdateProgressAsync(1.0f - ((float)fileCount / (float)maxFileCount));
                    }
                    string[] dirs = System.IO.Directory.GetDirectories(curpath);
                    foreach (string dir in dirs)
                    {
                        pathsToSearch.Add(dir);
                    }
                }
                if (deleteFileStructure)
                {
                    try
                    {
                        Directory.Delete(path, true);
                    }
                    catch (Exception ex)
                    {
                        if (swallowErrors == false)
                        {
                            throw ex;
                        }
                    }
                }
            });
        }
        public static bool PathsAreEqual(string a, string b)
        {
            return string.Equals(System.IO.Path.GetFullPath(a),
                            System.IO.Path.GetFullPath(b), StringComparison.OrdinalIgnoreCase);
        }
        public static string GetRelativePath(string fileOrPath, string folder)
        {
            Uri pathUri = new Uri(fileOrPath);
            // Folders must end in a slash
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }
        public static string GetDocumentsFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        public static string GetDesktopFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        public static string GetLocalSettingsFilePath()
        {
            string loc = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "IndyWorks");
            loc = System.IO.Path.Combine(loc, "localsettings." + Globals.ProgramVersion + ".dat");
            return loc;
        }
        public static string ShortenFilePath(string ts, int maxlen = 16)
        {
            string ret = ts;

            if (ts.Length > maxlen)
            {
                ret = ts.Substring(0, maxlen) + "..." + ts.Substring((ts.Length - maxlen), maxlen);
            }

            return ret;
        }
        public static string NormalizePath(string path)
        {
            string p = "";
            if (string.IsNullOrEmpty(path) == false)
            {
                try
                {
                    p = Path.GetFullPath(new Uri(path).LocalPath)
                              .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                              .ToUpperInvariant();
                }
                catch (Exception ex)
                {
                    //blah
                    //blah
                    Globals.MainForm.LogError("Normalize Path exception: " + ex.ToString());
                }

                return p;
            }

            return p;

        }
        public static void SafeWriteFile(string fn, string data)
        {
            string dir = System.IO.Path.GetDirectoryName(fn);
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            using (FileStream file = new FileStream(fn, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                {
                    writer.Write(data);
                }
            }
        }
        public static string SafeReadFile(string fn)
        {
            string dir = System.IO.Path.GetDirectoryName(fn);
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            using (FileStream file = new FileStream(fn, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader reader = new StreamReader(file, Encoding.Unicode))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        #endregion

        #region Registry (Unused)
        public static string RecentFilesRegKey = "RecentFiles";
        private static string GetLocalSettingsRegKey(string Keyname)
        {
            return "Software" + "/" + ApplicationTitle + "/" + ProgramVersion + "/" + Keyname;
        }
        public static void SaveRegistryValue(string skey, string value)
        {

            RegistryKey key;
            key = Registry.LocalMachine.OpenSubKey(GetLocalSettingsRegKey(skey), true);

            if (key == null)
            {
                key = Registry.LocalMachine.OpenSubKey("Software", true);

                key.CreateSubKey(ApplicationTitle);
                key = key.OpenSubKey(ApplicationTitle, true);

                key.CreateSubKey(ProgramVersion);
                key = key.OpenSubKey(ProgramVersion, true);
            }

            key.SetValue(skey, value);

        }
        public static string LoadRegistryValue(string skey)
        {
            RegistryKey key;
            key = Registry.LocalMachine.OpenSubKey(GetLocalSettingsRegKey(skey), true);

            if (key == null)
            {
                return "";
            }
            else
            {
                return key.GetValue(skey) as string;
            }

        }
        #endregion

        public static string TimeSpanToString(TimeSpan t)
        {
            string shortForm = "";
            if (t.Hours > 0)
            {
                shortForm += string.Format("{0}h", t.Hours.ToString());
            }
            if (t.Minutes > 0)
            {
                shortForm += string.Format("{0}m", t.Minutes.ToString());
            }
            if (t.Seconds > 0)
            {
                shortForm += string.Format("{0}s", t.Seconds.ToString());
            }
            if (t.Milliseconds > 0)
            {
                shortForm += string.Format("{0}ms", t.Milliseconds.ToString());
            }
            return shortForm;
        }

        public static void ShowError(Phrase s, Form owner = null)
        {
            CustomMessageBox.Show(s, Phrases.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowInfo(Phrase s, Form owner = null)
        {
            CustomMessageBox.Show(s, Phrases.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult MessageBox(Phrase text, Phrase caption, MessageBoxButtons but, Form owner)
        {
            return CustomMessageBox.Show(text, caption, but, MessageBoxIcon.Question);
        }
        public static string ResourceDirectory = "Resources/";
        public static Bitmap DefaultImage = null;
        public static Bitmap GetDefaultXImage()
        {
            // new BitmapImage(new Uri("Resources/invalid_file.png", UriKind.Absolute));

            //    //    string str = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "no.png");
            //    //    if (File.Exists(str))
            //    //    {
            //    //        this.DefaultImage = new Bitmap(str);
            //    //    }
            //    //    else
            //    //    {
            //    //        Bitmap bitmap = new Bitmap(64, 64, PixelFormat.Format24bppRgb);
            //    //    }
            if (DefaultImage == null)
            {
                try
                {
                    DefaultImage = new Bitmap("Resources/invalid_file.png");
                }
                catch (Exception ex)
                {
                    Globals.MainForm.LogError("Could nto find fiel: " + ex.ToString());
                    DefaultImage = new Bitmap(64, 64);
                }
            }
            return DefaultImage;
        }
        public static void CopyRegionIntoImage(Bitmap srcBitmap, Rectangle srcRegion,
            ref Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics graphics = Graphics.FromImage((Image)destBitmap))
            {
                graphics.DrawImage((Image)srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
        }

        public static byte[] Combine(byte[] a, byte[] b)
        {
            byte[] numArray = new byte[a.Length + b.Length];
            Buffer.BlockCopy((Array)a, 0, (Array)numArray, 0, a.Length);
            Buffer.BlockCopy((Array)b, 0, (Array)numArray, a.Length, b.Length);
            return numArray;
        }

        public static string[] GetValidUserFolder(string initialdir, bool multiple)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    return new string[1]
                    {
                        folderBrowserDialog.SelectedPath
                    };
            }
            return new string[0];
        }

        public static string[] GetValidOpenSaveUserFile(IWin32Window owner, bool bSave, string saveFilter,
            string loadFilter, string defaultext, string initialdir, bool multiple = false, string defaultName = "")
        {
            int num = 0;
            FileDialog fileDialog;
            string str;
            if (!bSave)
            {
                fileDialog = (FileDialog)new OpenFileDialog();
                str = loadFilter;
                (fileDialog as OpenFileDialog).Multiselect = multiple;
            }
            else
            {
                fileDialog = (FileDialog)new SaveFileDialog();
                str = saveFilter;
            }
            string fullPath = Path.GetFullPath(initialdir);
            fileDialog.InitialDirectory = fullPath;
            fileDialog.DefaultExt = defaultext;
            fileDialog.Filter = str;
            fileDialog.FilterIndex = num;
            if (string.IsNullOrEmpty(defaultName) == false)
            {
                fileDialog.FileName = defaultName + defaultext;
            }
            if (fileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return new string[0];
            }
            if (!bSave && !File.Exists(fileDialog.FileName))
            {
                return new string[0];
            }
            return fileDialog.FileNames;
        }

        public static void SelectCboItem(System.Windows.Forms.ComboBox cb, string s, int defIndex)
        {
            for (int i = 0; i < cb.Items.Count; ++i)
            {
                if ((cb.Items[i] as string).Equals(s))
                {
                    cb.SelectedIndex = i;
                    return;
                }
            }
            if (cb.Items.Count > 0)
            {
                if (defIndex < cb.Items.Count)
                {
                    cb.SelectedIndex = defIndex;
                }

            }
        }


    }
}




