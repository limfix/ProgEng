using System;
using System.Text.RegularExpressions;
using lab06.Builder;

namespace lab06.Director
{
    class RtfReader
    {
        readonly ITextBuilder builder; // builder

        public RtfReader(ITextBuilder builder) {
            this.builder = builder;
        }

        public void BuildText(string text)
        {
            builder.GetText(text);
        }
    }
}
