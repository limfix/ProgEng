using System;
using System.Drawing;
using System.Windows.Forms;
using lab02;
using lab06.ImgFabrical;

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

        private void openPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length < 2)
            {
                using (OpenFileDialog opf = new OpenFileDialog() { Filter = "BMP|*.bmp|JPG|*.jpg;*.jpeg", ValidateNames = true, Multiselect = false })
                {
                    if (opf.ShowDialog() == DialogResult.OK)
                    {
                        PictureBox mainPicture = new PictureBox();
                        Bitmap btMap = new Bitmap(opf.FileName);
                        //PictureForm pc = new PictureForm();
                        //pc.mainPictureBox.Image = btMap;
                        //pc.Show();
                        switch (opf.FilterIndex)
                        {
                            case 1:
                                FormDeveloper fd = new BmpFormDeveloper(btMap);
                                PictureForm bmpForm = fd.Create();
                                bmpForm.Show();
                                break;
                            case 2:
                                fd = new JpegFormDeveloper(btMap);
                                PictureForm jpegForm = fd.Create();
                                jpegForm.Show();
                                break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Превышен лимит создания MDI окон (макс. 2)", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
