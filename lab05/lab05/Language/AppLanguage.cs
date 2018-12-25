using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05.Language
{
    class AppLanguage : ILanguage
    {
        internal string FileS;
        internal string CreateS;
        internal string CanvasS;
        internal string RectCanvasS;
        internal string CircCanvasS;
        internal string LanguageS;
        internal string RussianLangS;
        internal string EnglishLangS;

        public void SetLanguage(string language)
        {
            if (language == "en")
            {
                this.FileS = "File";
                this.CreateS = "Create";
                this.CanvasS = "Canvas";
                this.RectCanvasS = "Rectangle";
                this.CircCanvasS = "Circle";
                this.LanguageS = "Language";
                this.RussianLangS = "Russian";
                this.EnglishLangS = "English";
            }

            else if (language == "ru")
            {

                this.FileS = "Файл";
                this.CreateS = "Создать";
                this.CanvasS = "Холст";
                this.RectCanvasS = "Прямоугольный";
                this.CircCanvasS = "Круглый";
                this.LanguageS = "Язык";
                this.RussianLangS = "Русский";
                this.EnglishLangS = "Английский";
            }
        }
    }
}
