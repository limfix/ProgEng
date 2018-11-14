using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace lab02
{
    public static class TextStats
    {
        public static int EmptyLines(RichTextBox textbox)
        {
            string[] lines = textbox.Lines;
            int count = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (String.IsNullOrEmpty(lines[i]))
                {
                    count++;
                }
            }
            return count;
        }
        public static double TextToKylobytes(RichTextBox textbox)
        {
            string mainText = textbox.Text;
            int bytes = System.Text.Encoding.ASCII.GetByteCount(mainText);
            float kbytes = 0.0f;
            kbytes = bytes / 1024.0f;
            return Math.Round(kbytes, 2);
        }
        public static int CharCount(RichTextBox textbox, int symbol)
        {
            char asciiNumber = (char)symbol;
            int count = textbox.Text.Count(x => x == asciiNumber);
            return count;
        }
        public static int CharsCount(RichTextBox textbox)
        {
            int textLength = textbox.Text.Length;

            return textLength;
        }
        public static int AutorPages(RichTextBox textbox)
        {
            int count = textbox.Text.Length / 1800;
            return count;
        }
        public static int CountWords(RichTextBox textbox, string wordtype)
        {
            int count = 0;
            char[] lvow = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };
            char[] cvow = new char[] { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            char[] lcons = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
            char[] ccons = new char[] { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
            char[] spec = new char[] { '@', '#', '$', '%', '^', '&', '*', '-', '_', '+', '=', '/', '?' };
            char[] punct = new char[] { '.', ',', '!', '?', ';', ':', '—', '(', ')', '"' };
            switch (wordtype)
            {
                case "cv":
                    count = textbox.Text.ToLower().Count(x => cvow.Contains(x));
                    break;
                case "cc":
                    count = textbox.Text.ToLower().Count(x => ccons.Contains(x));
                    break;
                case "lv":
                    count = textbox.Text.ToLower().Count(x => lvow.Contains(x));
                    break;
                case "lc":
                    count = textbox.Text.ToLower().Count(x => lcons.Contains(x));
                    break;
                case "tc":
                    count = count = textbox.Text.ToLower().Count(x => cvow.Contains(x)) + textbox.Text.ToLower().Count(x => ccons.Contains(x));
                    break;
                case "tl":
                    count = textbox.Text.ToLower().Count(x => lvow.Contains(x)) + textbox.Text.ToLower().Count(x => lcons.Contains(x));
                    break;
                case "sc":
                    count = textbox.Text.ToLower().Count(x => spec.Contains(x));
                    break;
                case "pc":
                    count = textbox.Text.ToLower().Count(x => punct.Contains(x));
                    break;
            }
            return count;
        }
        public static int CountNumbers(RichTextBox textbox)
        {
            int count = 0;
            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            count = textbox.Text.Count(x => numbers.Contains(x));
            return count;
        }
        public static RichTextBox FixText(RichTextBox textbox)
        {
            RichTextBox editbox = new RichTextBox();
            string[] lines = textbox.Lines;

            for (int i = 0; i < lines.Length; i++)
            {
                string str = System.Text.RegularExpressions.Regex.Replace(lines[i], @"\s+", " ");
                //str = System.Text.RegularExpressions.Regex.Replace(lines[i], @"\t+", "\t");
                if (String.IsNullOrEmpty(lines[i]))
                {
                    str = "";
                }
                editbox.AppendText(str);
            }
            return editbox;
        }
        public static string FindName(RichTextBox textbox, string form)
        {
            string pattern = "";
            switch (form)
            {
                case "initials":
                    pattern = @"[А-Я][а-я]+[ |\t]+[А-Я]+.[А-Я]+.";
                    break;
                case "full":
                    pattern = @"[А-Я][а-я]+\s+[А-Я][а-я]+";
                    break;
            }
            //string pattern = @"[А-Яа-я]+\s+[А-Яа-я]+.+[А-Яа-я]+."; // Фамилия И.Н.
            //string pattern = @"[А-Я]+\s+[А-Я]+";

            Regex flnames = new Regex(pattern);

            string match = Convert.ToString(flnames.Match(textbox.Text));
            Console.WriteLine(match);
            return match;
        }
        public static string FindConst(RichTextBox textbox, string option)
        {
            string pattern = "";
            switch (option)
            {
                case "int":
                    pattern = @"(“|’|‘)[0-9]+(“|’|‘)";
                    break;
                case "float":
                    pattern = @"(“|’|‘)[0-9]+(.|,)[0-9]+(“|’|‘)";
                    break;
                case "complex":
                    pattern = @"(“|’|‘)[0-9]+(\+|\-)(i|[0-9]+([i]|\*([i])))(“|’|‘)";
                    break;
            }
            //string pattern = @"[А-Яа-я]+\s+[А-Яа-я]+.+[А-Яа-я]+."; // Фамилия И.Н.
            //string pattern = @"[А-Я]+\s+[А-Я]+";

            Regex flnames = new Regex(pattern);

            string match = Convert.ToString(flnames.Match(textbox.Text));
            Console.WriteLine(match);
            return match;
        }
        public static string FindEmail(RichTextBox textbox)
        {
            string pattern = @"[a-zA-Z1-9\-\._]+@[a-z1-9]+(.[a-z1-9]+){1,}";
            Regex flnames = new Regex(pattern);

            string match = Convert.ToString(flnames.Match(textbox.Text));
            Console.WriteLine(match);
            return match;
        }
        public static string FindAdress(RichTextBox textbox)
        {
            string pattern = @"(г\.[А-Я][а-я]+)\,\s[0-9]{5}";
            Regex flnames = new Regex(pattern);

            string match = Convert.ToString(flnames.Match(textbox.Text));
            Console.WriteLine(match);
            return match;
        }
        public static string FindAnyCSWord(RichTextBox textbox)
        {
            string pattern = @"(\t|\n)+(while|for|if|else|break|char)";
            Regex flnames = new Regex(pattern);

            string match = Convert.ToString(flnames.Match(textbox.Text));
            Console.WriteLine(match);
            return match;
        }
    }
}
