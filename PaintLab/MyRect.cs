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
    public class MyRect : Mark
    {
        // points
        public Point firstPoint;
        public Point secondPoint;

        // size
        public int length;
        public int width;
        public Size size;

        // rectangle
        public Rectangle rectangle;

        // pen color
        public Pen rectPenColor;

        // fill color
        public Brush rectFillColor;

        // outline constructor
        public MyRect(Point first, Point second, Pen penColor)
        {
            firstPoint = first;
            secondPoint = second;
            rectPenColor = penColor;
            rectFillColor = null;

            // calculate length and width
            length = secondPoint.X - firstPoint.X;
            width = secondPoint.Y - firstPoint.Y;
            size = new Size(width, length);

            // create rectangle
            rectangle = new Rectangle(firstPoint, size);
        }

        // fill constructor
        public MyRect(Point first, Point second, Brush fillColor)
        {
            firstPoint = first;
            secondPoint = second;
            rectFillColor = fillColor;
            rectPenColor = null;

            // calculate length and width
            length = secondPoint.X - firstPoint.X;
            width = secondPoint.Y - firstPoint.Y;
            size = new Size(width, length);

            // create rectangle
            rectangle = new Rectangle(firstPoint, size);
        }

        // both constructor
        public MyRect(Point first, Point second, Pen penColor, Brush fillColor)
        {
            firstPoint = first;
            secondPoint = second;
            rectPenColor = penColor;
            rectFillColor = fillColor;

            // calculate length and width
            length = secondPoint.X - firstPoint.X;
            width = secondPoint.Y - firstPoint.Y;
            size = new Size(width, length);

            // create rectangle
            rectangle = new Rectangle(firstPoint, size);
        }

        public override void drawShape(Graphics g)
        {
            if (rectFillColor == null)
                g.DrawRectangle(rectPenColor, rectangle);
            else if (rectPenColor == null)
                g.FillRectangle(rectFillColor, rectangle);
            else
            {
                g.FillRectangle(rectFillColor, rectangle);
                g.DrawRectangle(rectPenColor, rectangle);
            }
        }
    }
}
