using System;
using System.Drawing;
using System.Windows.Forms;
using lab05.Language;
using lab05.TextBoxAdapter;
using lab05.FigureProt;

namespace lab05
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Factory.IAbstractFactory factoryCircle;
        private Factory.IAbstractFactory factoryRectangle;
        public Color currentColor = Color.Black;
        public int size = 5;
        public DrawWindow tempDw;
        public int x, y;
        internal WindowLang localization = new WindowTranslator(new RussianLanguage());

        private void DoTranslate()
        {
            this.FileMenuItem.Text = localization.language.FileS;
            this.CreateMenuItem.Text = localization.language.CreateS;
            this.CanvasMenuItem.Text = localization.language.CanvasS;
            this.RectangleMenuItem.Text = localization.language.RectCanvasS;
            this.CircleMenuItem.Text = localization.language.CircCanvasS;
            this.LanguageMenuItem.Text = localization.language.LanguageS;
            this.EnglishMenuItem.Text = localization.language.EnglishLangS;
            this.RussianMenuItem.Text = localization.language.RussianLangS;
            this.addTextButton.Text = localization.language.AddTextButtonS;
            foreach (DrawWindow frm in this.MdiChildren)
            {
                frm.copyButton.Text = localization.language.CopyButtonS;
                frm.pasteButton.Text = localization.language.PasteButtonS;
            }
        }

        public Color CurrentColor()
        {
            return currentColor;
        }

        public int CurrentSize()
        {
            return size;
        }

        private void RectangleMenuItem_Click(object sender, EventArgs e)
        {
            InitCanvas(factoryRectangle);
        }

        private void CircleMenuItem_Click(object sender, EventArgs e)
        {
            InitCanvas(factoryCircle);
        }

        private void InitCanvas(Factory.IAbstractFactory factory)
        {
            Canvas.ICanvas canvas = factory.CreateCanvas();
            DrawWindow dw = new DrawWindow();
            dw.drawType = canvas.GetCanvasType();
            dw.DrawBox = canvas.SetDrawBox(dw.DrawBox);
            dw.MdiParent = this;
            dw.currentLocalization = localization;
            Console.WriteLine(localization.language.CopyButtonS);
            dw.Show();
            tempDw = dw;
        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            DialogResult D = ColorPickerDialog.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
            {
                currentColor = ColorPickerDialog.Color;
                ButtonColor.BackColor = currentColor;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            SizeBar.Value = size;
            ButtonColor.BackColor = currentColor;
            factoryCircle = new Factory.ConcreteFactoryCircle();
            factoryRectangle = new Factory.ConcreteFactoryRectangle();
        }

        private void SizeBar_ValueChanged(object sender, EventArgs e)
        {
            size = SizeBar.Value;
        }

        private void RussianMenuItem_Click(object sender, EventArgs e)
        {
            localization.Language = new RussianLanguage();
            localization.Translate();
            DoTranslate();
        }

        private void EnglishMenuItem_Click(object sender, EventArgs e)
        {
            localization.Language = new EnglishLanguage();
            localization.Translate();
            DoTranslate();
        }

        private void addTextButton_Click(object sender, EventArgs e)
        {
            TextBox tb = new TextBox();
            tb.BorderStyle = BorderStyle.None;
            tb.Multiline = true;
            tb.Text = "text";

            Adapter textBox = new Adapter();
            textBox.text = tb;
            textBox.text.MouseMove += textBox1_MouseMove;
            textBox.text.MouseDown += textBox1_MouseDown;
            textBox.text.TextChanged += textBox.TextChange;


            Point pos = new Point(30, 32);
            tb.Location = pos;
            this.Controls.Add(tb);
            tb.BringToFront();
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // или любую другую, какая удобнее
            {
                Point pos = new Point();
                pos = new Point(Cursor.Position.X - x, Cursor.Position.Y - y);
                ((TextBox)sender).Location = PointToClient(pos);
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}
