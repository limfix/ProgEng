using System.Windows.Forms;

namespace lab05.FigureProt
{
    abstract class IFigure
    {
        public PictureBox pBox;
        public abstract IFigure Clone(IFigure result);
        public abstract IFigure Paste(IFigure result);
    }
}
