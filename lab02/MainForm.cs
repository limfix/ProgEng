using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using lab06.Director;
using lab06.Builder;
using lab06.ProductText;

namespace lab02
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Statistics stats = new Statistics
            {
                RichTextBox1 = richTextBox1
            };
            stats.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            string[] lines = richTextBox1.Lines;

            for (int i = 0; i < lines.Length; i++)
            {
                string str;
                str = Regex.Replace(lines[i], @"\s{2,}", " ").Trim();
                str = Regex.Replace(lines[i], @"\t{2,}", "\t").Trim();
                if (String.IsNullOrEmpty(lines[i]))
                {
                    str = "";
                }
                else
                {
                    richTextBox2.AppendText(str + System.Environment.NewLine);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dir = @"c:\\logs\\" + DateTime.Today.ToString("dd_MMM_yy");
            string path = @"c:\\logs\\" + DateTime.Today.ToString("dd_MMM_yy") + "\\" + DateTime.Now.ToString("HH.mm.ss") + ".txt";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(path))
            {
                using (File.Create(path));
                richTextBox2.SaveFile(path, RichTextBoxStreamType.UnicodePlainText);
                MessageBox.Show("Saved!", "OK");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FindMenu fm = new FindMenu
            {
                RichTextBox1 = richTextBox1
            };
            fm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog() { Filter = "Rich Text Format|*.rtf", ValidateNames = true, Multiselect = false })
            {
                HtmlBuilder hConverter = new HtmlBuilder(); // строители
                PlainTextBuilder pConverter = new PlainTextBuilder();
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    hConverter.Reset();
                    pConverter.Reset();
                    RtfReader director = new RtfReader(hConverter); // иниц. директора

                    string text = System.IO.File.ReadAllText(opf.FileName);
                    richTextBox1.Rtf = text;
                    text = richTextBox1.Rtf; // переопределение rtf текста (удаление MS заголовков и т.п.)
                    director.BuildText(text);
                    Product htmlText = hConverter.GetProduct();
                    richTextBox2.Text = htmlText.readyText;

                    director = new RtfReader(pConverter); // обращение к другому строителю
                    director.BuildText(text);
                    Product plainText = pConverter.GetProduct();
                    richTextBox1.Text = plainText.readyText;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string dir = @"c:\\logs\\" + DateTime.Today.ToString("dd_MMM_yy");
            string path = @"c:\\logs\\" + DateTime.Today.ToString("dd_MMM_yy") + "\\" + DateTime.Now.ToString("HH.mm.ss") + ".html";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(path))
            {
                using (File.Create(path)) ;
                richTextBox2.SaveFile(path, RichTextBoxStreamType.UnicodePlainText);
                MessageBox.Show("Saved!", "OK");
            }
        }
    }
}
