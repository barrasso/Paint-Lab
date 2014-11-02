using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PaintLab
{
    class MyText : Mark
    {
        // points
        public Point firstPoint;
        public Point secondPoint;

        // size
        public int length;
        public int width;
        public Size size;

        // rectangle
        public RectangleF rectangle;

        // brush color
        public Brush textBrushColor;

        // text to draw
        public String textToDraw;

        // constructor
        public MyText(Point first, Point second, Brush textColor, String textInBox)
        {
            // set values
            firstPoint = first;
            secondPoint = second;
            textBrushColor = textColor;
            textToDraw = textInBox;

            // calculate length and width
            length = secondPoint.X - firstPoint.X;
            width = secondPoint.Y - firstPoint.Y;
            size = new Size(length, width);

            // create rectangle
            rectangle = new RectangleF(firstPoint, size);
        }

        public override void drawShape(Graphics g)
        {
            Font drawFont = new Font("Arial", 8);
            g.DrawString(textToDraw, drawFont, textBrushColor, rectangle);
        }
    }
}
