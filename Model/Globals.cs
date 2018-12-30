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

namespace Monoedit
{
    public class Globals
    {
        private static MainForm _objMainForm = null;
        public static MainForm MainForm { get { return _objMainForm; } }
        public static void SetMainWindow(MainForm w) { _objMainForm = w; }

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

        public static void ShowError(string s, string caption = "Error", Form owner = null)
        {
            CustomMessageBox.Show(s, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowInfo(string s, string caption = "Info", Form owner = null)
        {

            CustomMessageBox.Show(s, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public static string[] GetValidOpenSaveUserFile(bool bSave, string saveFilter,
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



    }
}




