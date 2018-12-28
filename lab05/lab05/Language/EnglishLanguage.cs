using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05.Language
{
    class EnglishLanguage : ILanguage
    {
        public override void SetLanguage()
        {
            base.FileS = "File";
            base.CreateS = "Create";
            base.CanvasS = "Canvas";
            base.RectCanvasS = "Rectangle";
            base.CircCanvasS = "Circle";
            base.LanguageS = "Language";
            base.RussianLangS = "Russian";
            base.EnglishLangS = "English";
            base.CopyButtonS = "Copy";
            base.PasteButtonS = "Paste";
            base.AddTextButtonS = "Add Text";
            Console.WriteLine("Translated to English");
        }
    }
}
