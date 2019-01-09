using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Monoedit
{
    //**We need something besides xmlserializer
    public class ProjectFile : Monoedit.JsonFile<ProjectFile>
    {
        #region Private:Members
        [JsonProperty]
        private string _strProjectName = "";
        [JsonProperty]
        private List<ImageResource> _lstImages = new List<ImageResource>();
        [JsonProperty]
        private List<TileMap> _lstTileMaps = new List<TileMap>();
        [JsonProperty]
        private List<GameObject> _lstGameObjects = new List<GameObject>();
        [JsonProperty]
        private List<SpriteObject> _lstSpriteObjects = new List<SpriteObject>();
        [JsonProperty]
        private Int64 IdGen = 1000;
        [JsonProperty]
        public int MaxUndo { get; set; }
        [JsonProperty]
        public int MaxAtlasSize { get; set; }
        [JsonProperty]
        public int GrowAtlasBy { get; set; }
        [JsonProperty]
        public string OutputPath { get; set; } = "";
        [JsonProperty]
        public string OutputFilename { get; set; } = "";

        public void SetDefaults()
        {
            //Defaults
            ProjectName = "MyProject";
            LoadedOrSavedFileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Monogame Toolkit Projects");
            OutputFilename = Globals.ProjectNamePlaceholder + ".json";
            OutputPath = Globals.ProjectRootPlaceholder + "/Output";
            MaxUndo = 100;
            MaxAtlasSize = 4096;
            GrowAtlasBy = 128;
        }

        public Int64 GenId()
        {
            return IdGen++;
        }
        #endregion

        #region Properties
        //Ignore properties to prevent MarkChanged from getting called on load.
        [JsonIgnore]
        public string ProjectName
        {
            get
            {
                return _strProjectName;
            }
            set
            {
                _strProjectName = value;
                MarkChanged();
            }
        }
        [JsonIgnore]
        public List<ImageResource> Images
        {
            get
            {
                return _lstImages;
            }
            set
            {
                _lstImages = value;
                MarkChanged();
            }
        }
        [JsonIgnore]
        public List<GameObject> GameObjects
        {
            get
            {
                return _lstGameObjects;
            }
            set
            {
                _lstGameObjects = value;
                MarkChanged();
            }
        }
        [JsonIgnore]
        public List<SpriteObject> SpriteObjects
        {
            get
            {
                return _lstSpriteObjects;
            }
            set
            {
                _lstSpriteObjects = value;
                MarkChanged();
            }
        }
        [JsonIgnore]
        public List<TileMap> Maps
        {
            get
            {
                return _lstTileMaps;
            }
            set
            {
                _lstTileMaps = value;
                MarkChanged();
            }
        }

        [JsonIgnore]
        public bool DataChanged { get; private set; } = false;//do not serialize
        #endregion

        public ProjectFile()
        {
        }

        public string Path()
        {
            string r = System.IO.Path.GetDirectoryName(this.LoadedOrSavedFileName);
            return r;
        }

        public string ImagesPath()
        {
            string r = System.IO.Path.Combine(Path(), "Images");
            return r;
        }

        //public ResourceBase GetResourceById(Int64 id)
        //{
        //    ResourceBase r;
        //    r = _lstImages.Where(x => x.Id == id).FirstOrDefault();
        //    if (r != null) { return r; }
        //    r = _lstTileMaps.Where(x => x.Id == id).FirstOrDefault();
        //    if (r != null) { return r; }
        //    r = _lstSpriteObjects.Where(x => x.Id == id).FirstOrDefault();
        //    if (r != null) { return r; }

        //    foreach (SpriteObject s in _lstSpriteObjects)
        //    {
        //        r = s.Frames.Where(x => x.Id == id).FirstOrDefault();
        //        if (r != null) { return r; }
        //    }
        //    //TODO: more here

        //    return null;
        //}

        public void SetCwdToRoot()
        {
            Directory.SetCurrentDirectory(GetProjectRoot());
        }

        public string GetProjectRoot()
        {
            return System.IO.Path.GetDirectoryName(LoadedOrSavedFileName);
        }

        public string GetImageResourcePath()
        {
            string bp = GetProjectRoot();
            string imagesPath = System.IO.Path.Combine(bp, "images");

            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            return imagesPath;
        }

        public void MarkChanged()
        {
            DataChanged = true;
            Globals.MainForm.MarkChanged(true);
        }

        public void ClearChanged()
        {
            DataChanged = false;
            Globals.MainForm.MarkChanged(false);
        }

        private void ValidateFileWaypoint(string s, BinaryReader r, BinaryWriter w)
        {
            //this method reads or writes a small string value to make sure file isn't jacked up.
            if (r != null)
            {
                string test = BinUtils.ReadString(r);

                if (s.Equals(test) == false)
                {
                    //Error*!
                    Globals.LogError("File load failed: Validation failed at '" + s + " (validation value was " + test + ").");
                }
            }
            else if (w != null)
            {
                BinUtils.WriteString(s, w);
            }
        }
        //public void Save(string loc, bool textures)
        //{
        //    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        //    sw.Start();
        //    {
        //        LoadedOrSavedProjectFileName = loc;
        //        SaveBinary(loc, textures);

        //        //string xmlLoc = Path.Combine(Path.GetDirectoryName(loc), Path.GetFileNameWithoutExtension(loc) + ".xml");
        //        //SaveXML(xmlLoc, true, this);

        //        string jsonLoc = Path.Combine(Path.GetDirectoryName(loc), Path.GetFileNameWithoutExtension(loc) + ".json");
        //        SaveJson(jsonLoc, true, this);
        //    }
        //    sw.Stop();
        //    Globals.MainForm.SetStatus("Saved '" + loc + "' in " + Globals.TimeSpanToString(sw.Elapsed));
        //}
        //public void Load(string loc)
        //{
        //    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        //    sw.Start();
        //    {
        //        LoadedOrSavedProjectFileName = loc;
        //        if (LoadBinary(loc) == false)
        //        {
        //            //LoadXML(loc);
        //            LoadJson(loc);
        //        }
        //    }
        //    sw.Stop();
        //    Globals.MainForm.SetStatus("Loaded '" + loc + "' in " + Globals.TimeSpanToString(sw.Elapsed));
        //}
        //public static void SaveXML(string loc, bool textures, ProjectFile pf)
        //{

        //    //Problem is we can't serialize private properties and we want that.
        //    //Eiteher implement custom xmlserializer OR
        //    //Use theother approach (which is..?)
        //    try
        //    {


        //        XmlSerializer xsSubmit = new XmlSerializer(typeof(ProjectFile));
        //        var xml = "";
        //        using (var sww = new StringWriter())
        //        {
        //            using (XmlWriter writer = XmlWriter.Create(sww))
        //            {
        //                xsSubmit.Serialize(writer, pf);
        //                xml = sww.ToString(); // Your XML
        //            }
        //        }

        //        File.WriteAllText(loc, xml);
        //    }
        //    catch (Exception ex)
        //    {
        //        Globals.LogError("Failed to save XML File: " + ex.ToString());
        //    }
        //}

        //public static ProjectFile LoadXML(string loc)
        //{
        //    try
        //    {
        //        using (var stream = System.IO.File.OpenRead(loc))
        //        {
        //            var serializer = new XmlSerializer(typeof(ProjectFile));
        //            return serializer.Deserialize(stream) as ProjectFile;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Globals.LogError("Failed to Load XML File: " + ex.ToString());
        //    }
        //    return null;
        //}
        //public static void SaveJson(string loc, bool textures, ProjectFile pf)
        //{
        //    try
        //    {
        //        string output = JsonConvert.SerializeObject(pf);
        //        File.WriteAllText(loc, output);
        //    }
        //    catch (Exception ex)
        //    {
        //        Globals.LogError("Failed to save XML File: " + ex.ToString());
        //    }
        //}
        //public static ProjectFile LoadJson(string loc)
        //{
        //    try
        //    {
        //        string text = System.IO.File.ReadAllText(loc);
        //        return JsonConvert.DeserializeObject<ProjectFile>(text);
        //    }
        //    catch (Exception ex)
        //    {
        //        Globals.LogError("Failed to save XML File: " + ex.ToString());
        //    }
        //    return null;
        //}
        //private bool SaveBinary(string loc, bool textures)
        //{
        //    bool success = false;
        //    try
        //    {
        //        string dirname = System.IO.Path.GetDirectoryName(loc);
        //        if (!System.IO.Directory.Exists(loc))
        //        {
        //            System.IO.Directory.CreateDirectory(dirname);
        //        }

        //        using (BinaryWriter w = new BinaryWriter((Stream)File.Open(loc, FileMode.Create)))
        //        {
        //            BinUtils.WriteString(Globals.ProgramVersion, w);
        //            BinUtils.WriteInt32(80085, w);
        //            BinUtils.WriteInt16((short)8080, w);
        //            BinUtils.WriteBlock(new byte[1] { (byte)1 }, w);
        //            BinUtils.WriteFloat(3.14f, w);
        //            BinUtils.WriteBool(true, w);
        //            BinUtils.WriteBlock(new byte[5] { 5, 4, 3, 2, 1 }, w);

        //            BinUtils.WriteInt64(IdGen, w);
        //            BinUtils.WriteInt32(MaxUndo, w);

        //            BinUtils.WriteString(ProjectName, w);

        //            string version = Globals.ProgramVersion;

        //            WriteGroup<ImageResource>("ImageResources", Images, w, version);
        //            WriteGroup<Sprite>("Sprites", Sprites, w, version);
        //            WriteGroup<TileMap>("TileMaps", Maps, w, version);
        //            //**Other file stuff

        //            ValidateFileWaypoint("EndOfFile", null, w);
        //            ClearChanged();
        //        }

        //        success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Globals.LogError("Failed to load IWP Project file binary: " + ex.ToString());
        //    }
        //    return success;
        //}
        //private bool LoadBinary(string loc)
        //{
        //    bool success = true;
        //    try
        //    {
        //        using (BinaryReader r = new BinaryReader((Stream)File.Open(loc, FileMode.Open)))
        //        {
        //            string version = BinUtils.ReadString(r);

        //            if (version != Globals.ProgramVersion)
        //            {
        //                string str = "Note: This was created with an older version. " +
        //                    version + ".  Press 'OK' to upgrade to version " +
        //                    Globals.ProgramVersion + ".";

        //                Globals.LogError(str);

        //                Globals.ShowError(str, "Upgrade Notification");
        //            }
        //            BinUtils.ReadInt32(r);
        //            BinUtils.ReadInt16(r);
        //            BinUtils.ReadBlock(1, r);
        //            BinUtils.ReadFloat(r);
        //            BinUtils.ReadBool(r);
        //            BinUtils.ReadBlock(5, r);

        //            if (Convert.ToDouble(version) > 0.01)
        //            {
        //                IdGen = BinUtils.ReadInt64(r);
        //                MaxUndo = BinUtils.ReadInt32(r);
        //            }

        //            ProjectName = BinUtils.ReadString(r);

        //            ReadGroup<ImageResource>("ImageResources", Images, r, version);
        //            ReadGroup<Sprite>("Sprites", Sprites, r, version);
        //            ReadGroup<TileMap>("TileMaps", Maps, r, version);

        //            ValidateFileWaypoint("EndOfFile", r, null);
        //            success = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Globals.LogError("Failed to load file binary " + ex.ToString());
        //        success = false;
        //    }
        //    return success;
        //}
        //private void ReadGroup<T>(string groupname, List<T> group, BinaryReader r, string version) where T : ResourceBase
        //{
        //    ValidateFileWaypoint(groupname, r, null);

        //    group = new List<T>();
        //    int count = BinUtils.ReadInt32(r);
        //    for (int i = 0; i < count; ++i)
        //    {
        //        T x = (T)Activator.CreateInstance(typeof(T), new object[] { this, -1 });

        //        x.Deserialize( r, version);
        //        group.Add(x);
        //    }
        //}
        //private void WriteGroup<T>(string groupname, List<T> group, BinaryWriter w, string version) where T : ResourceBase
        //{
        //    ValidateFileWaypoint(groupname, null, w);

        //    BinUtils.WriteInt32(group.Count, w);
        //    foreach (T x in group)
        //    {
        //        x.Serialize(w, version);
        //    }
        //}
    }
}
