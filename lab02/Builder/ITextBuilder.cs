using lab06.ProductText;

namespace lab06.Builder
{
    interface ITextBuilder
    {
        void GetText(string text);
        string ConvertBold(string str);
        string ConvertItalic(string str);
        string ConvertUnderline(string str);
        string ConvertText(string str);
        string Paragraph(string str);
        void Reset();
        Product GetProduct();
    }
}
