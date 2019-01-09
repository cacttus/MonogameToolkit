// Decompiled with JetBrains decompiler
// Type: IsoPack.Model
// Assembly: IsoTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A40E7877-59D4-416C-9526-ACFD66F37CC4
// Assembly location: C:\Program Files\Iso Tool\IsoTool.exe

using System;
using System.Collections.Generic;
using System.IO;

namespace Monoedit
{
    public enum ScriptStatus
    {
        None,
        Success,
        Error,
        NoChanges,
    }
    public class Model3D
    {
        public string Name { get; set; }
        public string BlendFile { get; set; }
        public ModelRenderParameters RenderParams { get; set; } = new ModelRenderParameters();
        public BlendFileInfo BlendFileInfo { get; set; } = new BlendFileInfo();
        public SpriteObject DisplaySprite { get; set; } = (SpriteObject)null;
        public ScriptStatus ScriptStatus { get; set; } = ScriptStatus.None;
        public int Errors { get; set; } = 0;
        public List<SpriteObject> Sprites { get; set; } = new List<SpriteObject>();

        //public void Serialize(BinaryWriter stream, int version)
        //{
        //    BinUtils.WriteString(Name, stream);
        //    BinUtils.WriteString(BlendFile, stream);
        //    RenderParams.Serialize(stream, (float)version);
        //    BlendFileInfo.Serialize(stream);
        //    BinUtils.WriteInt32(Sprites.Count, stream);
        //    foreach (Sprite sprite in Sprites)
        //    {
        //        sprite.Serialize(stream, version);
        //    }
        //}

        //public void Deserialize(BinaryReader stream, int version)
        //{
        //    Name = BinUtils.ReadString(stream);
        //    BlendFile = BinUtils.ReadString(stream);
        //    RenderParams.Deserialize(stream, (float)version);
        //    BlendFileInfo.Deserialize(stream);
        //    int num = BinUtils.ReadInt32(stream);
        //    for (int index = 0; index < num; ++index)
        //    {
        //        Sprite sprite = new Sprite();
        //        sprite.Deserialize(stream, version);
        //        sprite.Model = this;
        //        Sprites.Add(sprite);
        //    }
        //}

        public static string MakeSpriteName(string ob, string act)
        {
            return ob + "|" + act;
        }

        //public void UpdateRenderedSprite(string ob, string act, MainForm objMainForm)
        //{
        //    string strNewSpriteName = Model.MakeSpriteName(ob, act);
        //    Sprites.RemoveAll((Predicate<Sprite>)(x => x.Name == strNewSpriteName));
        //    Model model = this;
        //    string pathForModelName = objMainForm.IsoPackFile.AppSettings.GetTemporaryOutputPathForModelName(model.Name);
        //    if (!Directory.Exists(pathForModelName))
        //        return;
        //    foreach (string directory1 in Directory.GetDirectories(pathForModelName))
        //    {
        //        int result;
        //        if (!int.TryParse(Path.GetFileName(directory1), out result))
        //        {
        //            objMainForm.Log("Error: angle " + directory1 + " directory couldn't parse angle as integer.");
        //        }
        //        else
        //        {
        //            foreach (string directory2 in Directory.GetDirectories(directory1))
        //            {
        //                Path.GetFileName(directory2);
        //                foreach (string directory3 in Directory.GetDirectories(directory2))
        //                {
        //                    if (Path.GetFileName(directory3) == act)
        //                    {
        //                        Sprite spriteAction = CreateSpriteAction(result, directory3, objMainForm, strNewSpriteName);
        //                        spriteAction.Model = model;
        //                        model.Sprites.Add(spriteAction);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //private Sprite CreateSpriteAction(int iangle, string strActionDir, MainForm objMainForm, string strNewSpriteName)
        //{
        //    Sprite sprite = new Sprite();
        //    sprite.Name = strNewSpriteName;
        //    sprite.Direction = iangle;
        //    foreach (string file in Directory.GetFiles(strActionDir))
        //    {
        //        string lower = Path.GetExtension(file).ToLower();
        //        if (lower == ".png" || lower == ".jpg" || lower == ".bmp" || lower == ".gif")
        //        {
        //            try
        //            {
        //                if (File.Exists(file))
        //                {
        //                    string withoutExtension = Path.GetFileNameWithoutExtension(file);
        //                    string s = withoutExtension.Substring(withoutExtension.Length - 7, 7);
        //                    int result = 0;
        //                    if (int.TryParse(s, out result))
        //                    {
        //                        Frame frame = new Frame();
        //                        frame.Sprite = sprite;
        //                        frame.FrameId = result;
        //                        frame.Name = strNewSpriteName + "|" + result.ToString();
        //                        frame.LoadFrameImage(file, objMainForm);
        //                        sprite.Frames.Add(frame);
        //                    }
        //                    else
        //                        objMainForm.Log("Could not parse frame ID for frame file " + file);
        //                }
        //                else
        //                    objMainForm.Log("File " + file + " does not exist!");
        //            }
        //            catch (Exception ex)
        //            {
        //                objMainForm.Log(ex.ToString());
        //            }
        //        }
        //        else
        //            objMainForm.Log("Warning: Found a file " + file + " with invalid (not .png) extension.");
        //    }
        //    sprite.SortFrames();
        //    return sprite;
        //}
    }
}
