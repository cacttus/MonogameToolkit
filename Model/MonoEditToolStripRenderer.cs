using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monoedit
{
    //Need to custom render toolstrip separators
    //https://social.msdn.microsoft.com/Forums/windows/en-US/6cceab5b-7e06-40cf-82da-56cdcc57eb5d/change-backcolor-of-toolstripseparator?forum=winforms

    public class MonoEditToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if (e.Vertical || (e.Item as ToolStripSeparator) == null)
            {
                base.OnRenderSeparator(e);
            }
            else
            {
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);

                //Draw Background
                SolidBrush bg = new SolidBrush(ThemeApplier.MenuBackColor());
                RectangleF r = new RectangleF();
                r = bounds;
                e.Graphics.FillRectangle(bg, bounds);
                bg.Dispose();

                //Force 1 pixel size
                e.Graphics.PageUnit = GraphicsUnit.Pixel;

                //Draw foreground
                Pen fgpen = new Pen(ThemeApplier.MenuForeColor(), 1);
                fgpen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                int y = bounds.Top + bounds.Height / 2;

                int pad = 6;

                e.Graphics.DrawLine(fgpen, bounds.X +pad, y,
                    bounds.X + bounds.Width - pad, y);
                fgpen.Dispose();

            }
        }
    }
} 

