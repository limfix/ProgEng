using System.Drawing;

namespace lab06.ImgFabrical
{
    abstract class FormDeveloper
    {
        public static Bitmap BtMap { get; set; }

        public FormDeveloper(Bitmap btMap)
        {
            BtMap = btMap;
        }
        // фабричный метод
        abstract public PictureForm Create();
    }
}
