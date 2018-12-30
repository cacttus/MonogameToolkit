using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Monoedit
{
    //Fucky shit right here.
    public class JsonFile <T> where T : JsonFile<T>
    {
        [JsonIgnore]
        protected string LoadedOrSavedFileName { get; set; } = "";

        public virtual void PostLoad()
        {
            //Override to post load stuff
        }

        public T CreateOrLoad(string loc)
        {
            if (!File.Exists(loc))
            {
                Save(loc);
            }

            return Load(loc);
        }

        public void Save(string loc)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            {
                LoadedOrSavedFileName = loc;
                string jsonLoc = Path.Combine(Path.GetDirectoryName(loc), Path.GetFileNameWithoutExtension(loc) + ".json");
                try
                {
                    string output = JsonConvert.SerializeObject(this as T);
                    File.WriteAllText(loc, output);
                }
                catch (Exception ex)
                {
                    Globals.MainForm.LogError("Failed to save Json File: " + ex.ToString());
                }
            }
            sw.Stop();
            Globals.MainForm.SetStatus("Saved '" + loc + "' in " + Globals.TimeSpanToString(sw.Elapsed));
        }

        public static T Load(string loc)
        {
            T ret = null;
            try
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                {
                    string text = System.IO.File.ReadAllText(loc);
                    ret = JsonConvert.DeserializeObject<T>(text);
                    ret.LoadedOrSavedFileName = loc;

                    ret.PostLoad();
                }
                sw.Stop();
                Globals.MainForm.SetStatus("Loaded '" + loc + "' in " + Globals.TimeSpanToString(sw.Elapsed));
            }
            catch (Exception ex)
            {
                Globals.MainForm.LogError("Failed to save Json File: " + ex.ToString());
            }
            return ret;
        }


    }
}
