using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Monoedit
{
    public enum StartupOption
    {
        [Description("None")]
        None,
        [Description("Load Last Project File")]
        LoadLastProject
    }

    public class OptionsFile : JsonFile<OptionsFile>
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public LanguageCode SelectedLanguage { get; set; } = LanguageCode.English;

        [JsonConverter(typeof(StringEnumConverter))]
        public MetroFramework.MetroThemeStyle Theme { get; set; } = MetroFramework.MetroThemeStyle.Dark;

        [JsonProperty]
        public string AutoLoadFilePath = "";

        [JsonConverter(typeof(StringEnumConverter))]
        public StartupOption StartupOption = StartupOption.None;

        [JsonProperty]
        public List<string> RecentFiles = new List<string>();

        public string FileLoc()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                "MonoEditOptions.json");
            return fileName;
        }

        public override void PostLoad()
        {
            //Init everything after loading.
            Translator.SwitchLanguage(SelectedLanguage);

            ThemeApplier.SwitchTheme(Theme);

        }
    }
}
