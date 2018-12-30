// Decompiled with JetBrains decompiler
// Type: IsoPack.ModelRenderParameters
// Assembly: IsoTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A40E7877-59D4-416C-9526-ACFD66F37CC4
// Assembly location: C:\Program Files\Iso Tool\IsoTool.exe

using System;
using System.IO;

namespace Monoedit
{
    public enum ObjectInfoType
    {
        Armature,
        Mesh,
        Both,
    }
    public class ModelRenderParameters
    {
        public float RenderDistance { get; set; } = 5f;
        public int RenderWidth { get; set; } = 128;
        public int RenderHeight { get; set; } = 128;
        public int Directions { get; set; } = 4;
        public int AASamples { get; set; } = 0;
        public int KeyframeGrain { get; set; } = 1;
        public bool FitModel { get; set; } = false;
        public ObjectInfoType InfoType { get; set; } = ObjectInfoType.Both;
        public float IsoHeight { get; set; } = 1f;

        public void Serialize(BinaryWriter stream, float version)
        {
            BinUtils.WriteFloat(RenderDistance, stream);
            BinUtils.WriteInt32(RenderWidth, stream);
            BinUtils.WriteInt32(RenderHeight, stream);
            BinUtils.WriteInt32(Directions, stream);
            BinUtils.WriteInt32(AASamples, stream);
            BinUtils.WriteInt32(KeyframeGrain, stream);
            BinUtils.WriteString(InfoType.ToString(), stream);
            BinUtils.WriteBool(FitModel, stream);
            BinUtils.WriteFloat(IsoHeight, stream);
        }

        public void Deserialize(BinaryReader stream, float version)
        {
            RenderDistance = BinUtils.ReadFloat(stream);
            RenderWidth = BinUtils.ReadInt32(stream);
            RenderHeight = BinUtils.ReadInt32(stream);
            Directions = BinUtils.ReadInt32(stream);
            AASamples = BinUtils.ReadInt32(stream);
            KeyframeGrain = BinUtils.ReadInt32(stream);
            InfoType = (ObjectInfoType)Enum.Parse(typeof(ObjectInfoType), BinUtils.ReadString(stream));
            if (!Enum.IsDefined(typeof(ObjectInfoType), (object)InfoType) && !InfoType.ToString().Contains(","))
                throw new InvalidOperationException("Enum Cast To ObjectInfoType Failed.");
            FitModel = BinUtils.ReadBool(stream);
            IsoHeight = BinUtils.ReadFloat(stream);
        }
    }
}
