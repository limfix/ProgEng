using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using lab02;

namespace lab06
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        private void editorFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length < 2)
            {
                MainForm textEditor = new MainForm();
                textEditor.MdiParent = this;
                textEditor.Show();
            }
            else
            {
                MessageBox.Show("Превышен лимит создания MDI окон (макс. 2)", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
