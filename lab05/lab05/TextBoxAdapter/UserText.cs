using System;
using System.Windows.Forms;
using System.Drawing;

namespace lab05.TextBoxAdapter
{
    /// <summary>
    /// Adapter
    /// </summary>
    public abstract class UserText
    {
        public TextBox text;
        public abstract void MouseD(object sender, MouseEventArgs e);
        public abstract void MouseM(object sender, MouseEventArgs e);
        public abstract void TextChange(object sender, EventArgs e);
    }

    public class Adapter : UserText
    {
        private Adaptee adaptee = new Adaptee();
        public override void MouseD(object sender, MouseEventArgs e)
        {
            adaptee.SpecificMouseDown(e);
        }

        public override void MouseM(object sender, MouseEventArgs e)
        {
            text = adaptee.SpecificMouseMove(e, text);
        }

        public override void TextChange(object sender, EventArgs e)
        {
            text = adaptee.SpecificTextChange(e, (TextBox)sender);
        }

    }

    public class Adaptee
    {
        int x = 0;
        int y = 0;
        public void SpecificMouseDown(MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        public TextBox SpecificMouseMove(MouseEventArgs e, TextBox text)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point pos = new Point();
                pos = new Point(Cursor.Position.X - 110, Cursor.Position.Y - 190);
                text.Location = pos;
                return text;
            }
            else return text;
        }

        public TextBox SpecificTextChange(EventArgs e, TextBox text)
        {
            int textWidth = TextRenderer.MeasureText(text.Text, text.Font).Width;
            int textHeight = TextRenderer.MeasureText(text.Text, text.Font).Height;

            text.Width = textWidth;
            if (textWidth != 0)
            {
                int lines = textWidth / text.Width;
                if (textWidth % text.Width != 0)
                    lines++;

                text.Height = textHeight * lines + 7;
            }
            return text;
        }

        public void Enter(KeyEventArgs e, TabPage tp)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tp.Focus();
            }
        }
    }
}
