using System;
using System.Windows.Forms;
using System.Drawing;
using lab05.FigureProt;

namespace lab05
{
    public partial class DrawWindow : Form
    {
        private Factory.IAbstractFactory factoryCircle;
        private Factory.IAbstractFactory factoryRectangle;
        private bool ispressed = false;
        private Color currentColor = Color.Black;
        private int size = 5;
        public string drawType;
        public DrawWindow currentDw;
        Graphics g;
        Point prevPoint;
        Point currentPoint;

        IFigure clone = new CopyFigure();

        public DrawWindow()
        {
            InitializeComponent();
            g = DrawBox.CreateGraphics();
            clone.pBox = DrawBox;
        }

        private void DrawWindow_Load(object sender, EventArgs e)
        {
            factoryCircle = new Factory.ConcreteFactoryCircle();
            factoryRectangle = new Factory.ConcreteFactoryRectangle();
        }

        private void DrawLine(Factory.IAbstractFactory factory)
        {
            Brush.IBrush brush = factory.CreateBrush();
            brush.SetGraph(g);
            brush.SetColor(currentColor);
            brush.SetSize(size);
            brush.Draw(g, prevPoint, currentPoint);
        }

        private void DrawBox_MouseDown(object sender, MouseEventArgs e)
        {
            ispressed = true;
            var parent = this.MdiParent as MainWindow;
            currentColor = parent.CurrentColor();
            size = parent.CurrentSize();
            currentPoint = e.Location;
        }

        private void DrawBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (ispressed)
            {
                if (DrawBox.Image == null)
                {
                    Bitmap bmp = new Bitmap(DrawBox.Width, DrawBox.Height);
                    DrawBox.Image = bmp;
                }
                using (g = Graphics.FromImage(DrawBox.Image))
                {
                    switch (drawType)
                    {
                        case "Circle":
                            DrawLine(factoryCircle);
                            break;
                        case "Rectangle":
                            DrawLine(factoryRectangle);
                            break;
                    }
                }
                prevPoint = currentPoint;
                currentPoint = e.Location;
                DrawBox.Invalidate();
            }
        }

        private void DrawBox_MouseUp(object sender, MouseEventArgs e)
        {
            ispressed = false;
        }

        private void copyButton_Click_1(object sender, EventArgs e)
        {
            clone.Clone(clone);
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            clone.Paste(clone);
        }
    }
}
