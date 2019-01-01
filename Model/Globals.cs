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
    public static class Globals
    {
        public static string TitleImageName = "Icon.png";

        #region Public: Props
        private static MainForm _objMainForm = null;
        //public const string ProgramVersion = "0.01";
        public const string ProgramVersion = "0.01";
        public const string ProgramName = "Monogame Toolkit";
        public static double GetProgramVersion()
        {
            double d = 0;
            Double.TryParse(ProgramVersion, out d);
            return d;
        }
        public const string ApplicationTitle = "Indieworks";

        public static string SupportedLoadSpriteImageFilter = "Image Files (*.png;*.bmp;*.gif;*.jpg)|*.png;*.bmp;*.gif;*.jpg|All files (*.*)|*.*";
        public static string SupportedLoadSpriteImageFilterDefault = "(*.png;)|*.png";
        public static string GifFilter = "Gif Files (*.gif)|*.gif;|All files (*.*)|*.*";
        public static string ExeFilter = "Exe Files (*.exe)|*.exe|All files (*.*)|*.*";
        public static string ProjectExt = ".json";
        public static string ProjectFilter = "Project Files (*" + ProjectExt + ")|*" + ProjectExt + "";
        public static string AllFilter = "All files (*.*)|*.*";

        public static MainForm MainForm { get { return _objMainForm; } }
        public static void SetMainWindow(MainForm w) { _objMainForm = w; }
        private static Random Random = new Random();
        #endregion

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
                    Globals.LogError("Normalize Path exception: " + ex.ToString());
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

        #region Public: Static Methods
        public static void SetTooltip(List<Control> ctls, Phrase p, int show_duration = 3000)
        {
            foreach (Control c in ctls)
            {
                SetTooltip(c, p, show_duration);
            }
        }
        public static void SetTooltip(Control ctl, Phrase p, int show_duration = 3000)
        {
            ctl.MouseHover += (object xsender, EventArgs xe) =>
            {
                MetroFramework.Components.MetroToolTip t = new MetroFramework.Components.MetroToolTip();
                t.ReshowDelay = 1000;
                t.Theme = Globals.MainForm.OptionsFile.Theme;
                t.UseFading = true;
                t.AutoPopDelay = show_duration;
                t.InitialDelay = 1500;
                t.IsBalloon = true;
                t.Show(Translator.Translate(p, Globals.MainForm.OptionsFile.SelectedLanguage), ctl);
            };
        }
        public static void SwapControl(Control toRemove, Control toAdd)
        {
            toAdd.Top = toRemove.Top;
            toAdd.Left = toRemove.Left;
            toAdd.Width = toRemove.Width;
            toAdd.Height = toRemove.Height;
            toAdd.Dock = toRemove.Dock;
            toAdd.Anchor = toRemove.Anchor;


            Control parent = toRemove.Parent;
            if (parent != null)
            {
                parent.Controls.Remove(toRemove);
                parent.Controls.Add(toAdd);
            }

        }
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
        public static void ShowInfo(string s, Form owner = null)
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
                    Globals.LogError("Could nto find fiel: " + ex.ToString());
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
        public static string[] GetValidOpenSaveUserFile(IWin32Window owner, bool bSave,
            string filter, string defaultext, string initialdir, bool multiple = false, string defaultName = "")
        {
            return GetValidOpenSaveUserFile(owner, bSave,
             filter, filter, defaultext, initialdir, multiple, defaultName);
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
        public static void SelectCboItem(System.Windows.Forms.ComboBox cb, string selected, int defIndex)
        {
            //Translate s
            string selected_trans = Translator.Translate(selected);
            for (int i = 0; i < cb.Items.Count; ++i)
            {
                //Do some translation voodoo
                string item = (cb.Items[i] as string);
                Phrase p = Translator.FindPhrase(item, Globals.MainForm.OptionsFile.SelectedLanguage);
                string item_trans = Translator.Translate(p, Globals.MainForm.OptionsFile.SelectedLanguage);

                if (item_trans.Equals(selected_trans))
                {
                    cb.SelectedIndex = i;
                    return;
                }
            }
            if (cb.Items.Count > 0)
            {
                Globals.LogError("Could not find combobox item: " + selected);
                if (defIndex < cb.Items.Count)
                {
                    cb.SelectedIndex = defIndex;
                }
            }
        }
        public static void BottomFolder(string path, out string parents, out string childfolder)
        {
            parents = "";
            childfolder = "";
            //Bottom folder of path, or top folder..
            path = path.TrimEnd('/', '\\');
            int a = path.LastIndexOf('/');
            int b = path.LastIndexOf('\\');
            if (b > a)
            {
                a = b;
            }
            a++;//remove the first /
            if (a != -1 && a < path.Length)
            {
                childfolder = path.Substring(a);
                parents = path.Substring(0, a);
            }
        }
        public static bool FilePathHasInvalidChars(string path)
        {
            return (!string.IsNullOrEmpty(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0);
        }
        public static T SafeCast<T>(object obj) where T : class
        {
            T obj2 = obj as T;
            if (obj2 == null)
            {
                //Failure.
                Globals.LogError("Could not cast object of type " + typeof(T));
                System.Diagnostics.Debugger.Break();
            }
            return obj2;
        }
        public static void LogError(string e, bool messageBox = false)
        {
            Globals.MainForm.LogError(e, messageBox);
        }
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }
        public static T GetEnumFromComboBox<T>(MetroComboBox b) where T : struct, IConvertible
        {
            //Gets the enum for combo box - with translation support
            //https://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum/
            string lang = b.SelectedItem as string;
            //Set default enum value to first value
            T code = (T)Enum.ToObject(typeof(T), 0);

            string eng = Translator.GetEnglish(lang);

            Enum.TryParse(eng, out code);
            return code;
        }
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        #endregion


        public static Bitmap LoadThemedBitmapResource(string name)
        {
            Bitmap bmp = null;
            try
            {
                string theme = "dark";
                if (Globals.MainForm.OptionsFile.Theme == MetroThemeStyle.Dark)
                {
                    theme = "dark";
                }
                else
                {
                    theme = "light";
                }

                bmp = LoadBitmapResource(name, theme);
            }
            catch (Exception ex)
            {
                Globals.LogError("Failed to load image '" + name + "': " + ex.ToString());
            }
            return bmp;
        }
        public static Bitmap LoadBitmapResource(string name, string subdir = "")
        {
            string dir = Assembly.GetEntryAssembly().Location;
            dir = Path.GetDirectoryName(dir);
            if (string.IsNullOrEmpty(subdir) == false)
            {
                dir = Path.Combine(dir, "rsc", subdir, name);
            }
            else
            {
                dir = Path.Combine(dir, "rsc", name);
            }
            Bitmap bmp = new Bitmap(dir);
            return bmp;
        }
        public static Icon LoadIconResource(string name, string subdir = "")
        {
            Icon ico = null;
            try
            {
                string dir = Assembly.GetEntryAssembly().Location;
                dir = Path.GetDirectoryName(dir);
                if (string.IsNullOrEmpty(subdir) == false)
                {
                    dir = Path.Combine(dir, "rsc", subdir, name);
                }
                else
                {
                    dir = Path.Combine(dir, "rsc", name);
                }
                ico = new Icon(dir);
            }
            catch (Exception ex)
            {
                Globals.LogError(ex.ToString());   
            }
            return ico;
        }
    }
}




