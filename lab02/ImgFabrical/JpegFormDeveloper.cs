using System.Drawing;

namespace lab06.ImgFabrical
{
    class JpegFormDeveloper : FormDeveloper
    {
        public JpegFormDeveloper(Bitmap btMap) : base(btMap)
        {

        }

        public override PictureForm Create()
        {
            JpegForm jpegForm = new JpegForm();
            jpegForm.mainPictureBox.Image = BtMap;
            return jpegForm;
        }
    }
}