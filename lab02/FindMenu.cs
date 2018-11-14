using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace lab02
{
    public partial class FindMenu : Form
    {
        public FindMenu()
        {
            InitializeComponent();
        }

        public RichTextBox RichTextBox1 { get; set; }

        private void FindMenu_Activated(object sender, EventArgs e)
        {
            label11.Text = TextStats.FindName(RichTextBox1,"full");
            label12.Text = TextStats.FindName(RichTextBox1, "initials");
            label13.Text = TextStats.FindAnyCSWord(RichTextBox1);
            label14.Text = TextStats.FindAdress(RichTextBox1);
            label15.Text = TextStats.FindEmail(RichTextBox1);
            label16.Text = TextStats.FindConst(RichTextBox1,"int");
            label17.Text = TextStats.FindConst(RichTextBox1, "float");
            label18.Text = TextStats.FindConst(RichTextBox1, "complex");
            //string pattern = @"[A-Za-z]+\.[A-Za-z]+\.[A-Za-z]+";
            string pattern = @"(\n|\t)[a-z]+\.(edu\.ua|net\.ua|com\.ua))";
            Regex flnames = new Regex(pattern);
            Match match = flnames.Match(RichTextBox1.Text);
            while (match.Success)
            {
                //Console.WriteLine(match.Value);
                listBox1.Items.Add(match);
                match = match.NextMatch();
            }
        }
    }

    
}
