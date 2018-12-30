// Decompiled with JetBrains decompiler
// Type: IsoPack.SpriteListView
// Assembly: IsoTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A40E7877-59D4-416C-9526-ACFD66F37CC4
// Assembly location: C:\Program Files\Iso Tool\IsoTool.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Monoedit
{
    public enum SpriteListViewMode
    {
        Sprite,
        Frame,
        Model,
    }
    public class SpriteListViewItem
    {
        public object Object { get; set; } = null;
        public Frame Frame { get; set; } = null;

        public SpriteListViewItem(object tag, Frame frame)
        {
            Object = tag;
            Frame = frame;
        }
    }

    public class SpriteListView : ListView
    {
        private int iIconSize = 32;
        private MainForm _objMainForm = (MainForm)null;
        private Func<List<SpriteListViewItem>> GetFrames;
        private Action<List<object>> DeleteFunc;

        public SpriteListView(MainForm mf, Func<List<SpriteListViewItem>> GetFramesFunc, Action<List<object>> deleteFunc)
        {
            GetFrames = GetFramesFunc;
            DeleteFunc = deleteFunc;
            _objMainForm = mf;
            DoubleClick += new EventHandler(SpriteListView_DoubleClick);
            MouseClick += new MouseEventHandler(SpriteListView_Click);
            KeyDown += new KeyEventHandler(SpriteListView_KeyDown);
            ContextMenu = new ContextMenu(new MenuItem[4]
            {
                new MenuItem("Small Icons", new EventHandler(ContextMenu_Click)),
                new MenuItem("Medium Icons", new EventHandler(ContextMenu_Click)),
                new MenuItem("Large Icons", new EventHandler(ContextMenu_Click)),
                new MenuItem("Huge Icons", new EventHandler(ContextMenu_Click))
            });
        }

        private void SpriteListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            List<object> objectList = new List<object>();
            foreach (ListViewItem selectedItem in SelectedItems)
            {
                objectList.Add(selectedItem.Tag);
            }
            DeleteFunc(objectList);
        }

        private void ContextMenu_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            if (menuItem != null)
            {
                if (menuItem.Text == "Small Icons")
                    iIconSize = 32;
                if (menuItem.Text == "Medium Icons")
                    iIconSize = 64;
                if (menuItem.Text == "Large Icons")
                    iIconSize = 128;
                if (menuItem.Text == "Huge Icons")
                    iIconSize = 256;
                UpdateListView();
            }
        }

        private void SpriteListView_Click(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || !FocusedItem.Bounds.Contains(e.Location))
            {
                return;
            }
            ContextMenu.Show((Control)this, new Point(e.X, e.Y));
        }

        public object GetSelectedObject()
        {
            if (SelectedItems.Count == 0)
            {
                return (object)null;
            }
            return SelectedItems[0].Tag;
        }

        private string GetObjectName(object f)
        {
            if (f != null)
            {
                if (f is Model)
                {
                    return (f as Model).Name;
                }
                else if (f is Sprite)
                {
                    return (f as Sprite).Name;
                }
                else if (f is Frame)
                {
                    return (f as Frame).Name;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            return "Unknown-Name*";
        }

        private void SpriteListView_DoubleClick(object sender, EventArgs e)
        {
            object selectedObject = GetSelectedObject();
            if (selectedObject == null)
                return;
            if (selectedObject is Model)
            {
                _objMainForm.AddEditObject(selectedObject as Model, false);
            }
            else if (selectedObject is Sprite)
            {
                _objMainForm.AddEditObject(selectedObject as Sprite, (selectedObject as Sprite).Model, false);
            }
            else if (selectedObject is Frame)
            {
                _objMainForm.AddEditObject(selectedObject as Frame, (selectedObject as Frame).Sprite, false);
            }
        }

        public void UpdateListView()
        {
            //if (_objMainForm.TextureInfo.PackedTexture == null)
            //{
            //    _objMainForm.LogError("File was not loaded. or texture was null.");
            //}
            //else
            //{
            object selectedObject = GetSelectedObject();
            Items.Clear();
            View = System.Windows.Forms.View.LargeIcon;
            Alignment = ListViewAlignment.Top;
            HideSelection = false;
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(iIconSize, iIconSize);
            List<SpriteListViewItem> spriteListViewItemList = GetFrames();
            for (int index = 0; index < spriteListViewItemList.Count; ++index)
            {
                Frame frame = spriteListViewItemList[index].Frame;
                if (frame == null)
                {
                    imageList.Images.Add((Image)Globals.GetDefaultXImage());
                }
                else
                {
                    Bitmap imageForFrame = frame.GetImageForFrame();// _objMainForm.ProjectFile.PackedTexture.GetImageForFrame(frame);
                    imageList.Images.Add((Image)imageForFrame);
                }
                Items.Add(new ListViewItem()
                {
                    ImageIndex = index,
                    Text = GetObjectName(spriteListViewItemList[index].Object),
                    Tag = spriteListViewItemList[index].Object
                });
            }
            if (View == System.Windows.Forms.View.SmallIcon)
            {
                SmallImageList = imageList;
            }
            if (View == System.Windows.Forms.View.LargeIcon)
            {
                LargeImageList = imageList;
            }
            if (View == System.Windows.Forms.View.Tile)
            {
                TileSize = new Size(64, 64);
                LargeImageList = imageList;
            }
            SetListViewToSelectedObjectTag((ListView)this, selectedObject);
            //}
        }

        private static void SetListViewToSelectedObjectTag(ListView lv, object selected)
        {
            if (lv.Items.Count > 0 && selected != null)
            {
                foreach (ListViewItem listViewItem in lv.Items)
                    listViewItem.Selected = listViewItem.Tag == selected;
            }
            lv.Select();
        }

    }
}
