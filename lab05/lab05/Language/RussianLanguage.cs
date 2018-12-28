using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05.Language
{
    class RussianLanguage : ILanguage
    {
        public override void SetLanguage()
        {
            base.FileS = "Файл";
            base.CreateS = "Создать";
            base.CanvasS = "Холст";
            base.RectCanvasS = "Прямоугольный";
            base.CircCanvasS = "Круглый";
            base.LanguageS = "Язык";
            base.RussianLangS = "Русский";
            base.EnglishLangS = "Английский";
            base.CopyButtonS = "Копировать";
            base.PasteButtonS = "Вставить";
            base.AddTextButtonS = "Текст";

            Console.WriteLine("Переведено на русский");
        }
    }
}
