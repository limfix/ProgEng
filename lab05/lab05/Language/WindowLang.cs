using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05.Language
{
    abstract class WindowLang
    {
        internal ILanguage language;

        public ILanguage Language
        {
            set { language = value; }
        }
        public WindowLang (ILanguage lang)
        {
            language = lang;
        }
        public virtual void Translate()
        {
            language.SetLanguage();
        }
    }
}
