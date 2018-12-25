using System.Drawing;
using System.Windows.Forms;

namespace lab05.FigureProt
{
    class CopyFigure : IFigure
    {
        public override IFigure Clone(IFigure result)
        {
            Clipboard.SetDataObject(result.pBox.Image);
            return result;
        }

        public override IFigure Paste(IFigure result)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Bitmap))
            {
                result.pBox.Image = (Bitmap)iData.GetData(DataFormats.Bitmap);
            }
            return result;
        }

    }
}
