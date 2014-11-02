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

        // pen
        public Pen rectPen;
        // pen color
        public Brush rectPenColor;
        //pen width
        public float rectPenWidth;

        // fill color
        public Brush rectFillColor;

        // pen width
        public int penWidth;

        // outline constructor
        public MyRect(Point first, Point second, Brush penColor, float penWidth)
        {
            firstPoint = first;
            secondPoint = second;
            rectPenColor = penColor;
            rectPenWidth = penWidth;
            rectFillColor = null;

            // create pen
            rectPen = new Pen(rectPenColor, rectPenWidth);

            // calculate length and width
            length = secondPoint.X - firstPoint.X;
            width = secondPoint.Y - firstPoint.Y;
            size = new Size(length, width);

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
            size = new Size(length, width);

            // create rectangle
            rectangle = new Rectangle(firstPoint, size);
        }

        // both constructor
        public MyRect(Point first, Point second, Brush penColor, Brush fillColor, float penWidth)
        {
            firstPoint = first;
            secondPoint = second;
            rectPenColor = penColor;
            rectFillColor = fillColor;
            rectPenWidth = penWidth;

            // create pen
            rectPen = new Pen(rectPenColor, rectPenWidth);

            // calculate length and width
            length = secondPoint.X - firstPoint.X;
            width = secondPoint.Y - firstPoint.Y;
            size = new Size(length, width);

            // create rectangle
            rectangle = new Rectangle(firstPoint, size);
        }

        public override void drawShape(Graphics g)
        {
            if (rectFillColor == null)
                g.DrawRectangle(rectPen, rectangle);
            else if (rectPenColor == null)
                g.FillRectangle(rectFillColor, rectangle);
            else
            {
                g.FillRectangle(rectFillColor, rectangle);
                g.DrawRectangle(rectPen, rectangle);
            }
        }
    }
}
