using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab05.Canvas
{
    class RectangleCanvas : Form, ICanvas
    {
        public string canvasType = "Rectangle";

        public string GetCanvasType()
        {
            return canvasType;
        }
        #region IAbstractCanvas interface
        public PictureBox SetDrawBox(PictureBox pictureBox)
        {
            return pictureBox;
        }
        #endregion IAbstractCanvas interface
    }
}
