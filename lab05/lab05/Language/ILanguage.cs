using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05.Language
{
    public abstract class ILanguage
    {
        internal string FileS;
        internal string CreateS;
        internal string CanvasS;
        internal string RectCanvasS;
        internal string CircCanvasS;
        internal string LanguageS;
        internal string RussianLangS;
        internal string EnglishLangS;
        internal string CopyButtonS;
        internal string PasteButtonS;
        internal string AddTextButtonS;

        public virtual void SetLanguage()
        {

        }
    }
}
