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
    public class Lines
    {
        // first point
        public Point firstPoint;
        // second point
        public Point secondPoint;
        // pen color
        public Pen linePenColor;

        public Lines(Point first, Point second, Pen thePen)
        {
            firstPoint = first;
            secondPoint = second;
            linePenColor = thePen;
        }
    }
}
