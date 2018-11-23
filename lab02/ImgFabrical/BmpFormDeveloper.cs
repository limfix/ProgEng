using System.Drawing;

namespace lab06.ImgFabrical
{
    class BmpFormDeveloper : FormDeveloper
    {
        public BmpFormDeveloper(Bitmap btMap) : base(btMap)
        {
            
        }

        public override PictureForm Create()
        {
            BmpForm bmpForm = new BmpForm();
            bmpForm.mainPictureBox.Image = BtMap;
            return bmpForm;
        }
    }
}
