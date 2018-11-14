using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab02
{
    public partial class Statistics : Form
    {

        public Statistics()
        {
            InitializeComponent();
        }

        public RichTextBox RichTextBox1 { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Statistics_Activated(object sender, EventArgs e)
        {
            //Console.WriteLine(RichTextBox1);
            label2.Text = TextStats.TextToKylobytes(RichTextBox1) + "Kb";
            label4.Text = TextStats.CharsCount(RichTextBox1).ToString();
            label6.Text = TextStats.CharCount(RichTextBox1, 9).ToString();
            label8.Text = TextStats.EmptyLines(RichTextBox1).ToString();
            label10.Text = TextStats.AutorPages(RichTextBox1).ToString();
            label14.Text = TextStats.CountWords(RichTextBox1, "cv").ToString();
            label16.Text = TextStats.CountWords(RichTextBox1, "cc").ToString();
            label19.Text = TextStats.CountWords(RichTextBox1, "lv").ToString();
            label20.Text = TextStats.CountWords(RichTextBox1, "lc").ToString();
            label24.Text = TextStats.CountWords(RichTextBox1, "sc").ToString();
            label26.Text = TextStats.CountWords(RichTextBox1, "pc").ToString();
            label28.Text = TextStats.CountWords(RichTextBox1, "tc").ToString();
            label30.Text = TextStats.CountWords(RichTextBox1, "tl").ToString();
            label22.Text = TextStats.CountNumbers(RichTextBox1).ToString();
        }
    }
}
