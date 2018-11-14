using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab05.Canvas
{
    class CircleCanvas : DrawWindow, ICanvas
    {
        public string canvasType = "Circle";
        #region IAbstractCanvas interface
        public string GetCanvasType()
        {
            return canvasType;
        }
        public PictureBox SetDrawBox(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox.Width - 3, pictureBox.Height - 3);
            Region rg = new Region(gp);
            pictureBox.Region = rg;
            return pictureBox;
        }
        #endregion IAbstractCanvas interface
    }
}
