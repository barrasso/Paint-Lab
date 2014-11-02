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
    public class Lines : Mark
    {
        // first point
        public Point firstPoint;
        // second point
        public Point secondPoint;
        // pen
        public Pen linePen;
        // pen color
        public Brush linePenColor;
        //pen width
        public float linePenWidth;

        public Lines(Point first, Point second, Brush penColor, float penWidth)
        {
            firstPoint = first;
            secondPoint = second;
            linePenColor = penColor;
            linePenWidth = penWidth;

            // create new pen
            linePen = new Pen(linePenColor, penWidth);
        }

        public override void drawShape(Graphics g)
        {
            g.DrawLine(linePen, firstPoint, secondPoint);
        }
    }
}
