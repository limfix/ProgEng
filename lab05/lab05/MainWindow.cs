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

        private void SetLanguage(string lang)
        {
            AppLanguage bridgeLang = new AppLanguage();
            bridgeLang.SetLanguage(lang);
            this.FileMenuItem.Text = bridgeLang.FileS;
            this.CreateMenuItem.Text = bridgeLang.CreateS;
            this.CanvasMenuItem.Text = bridgeLang.CanvasS;
            this.RectangleMenuItem.Text = bridgeLang.RectCanvasS;
            this.CircleMenuItem.Text = bridgeLang.CircCanvasS;
            this.LanguageMenuItem.Text = bridgeLang.LanguageS;
            this.EnglishMenuItem.Text = bridgeLang.EnglishLangS;
            this.RussianMenuItem.Text = bridgeLang.RussianLangS;
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
            SetLanguage("ru");
        }

        private void EnglishMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("en");
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
