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
    public partial class Form1 : Form
    {
        // array list to hold graphic objects for painting
        public ArrayList graphicsList = new ArrayList();

        // Pen Color List Box Strings
        public List<string> penColorItems = new List<string>();

        // Fill Color List Box Strings
        public List<string> fillColorItems = new List<string>();

        public Form1()
        {
            InitializeComponent();

            // Add items to ListBox1
            penColorItems.Add("Black");
            penColorItems.Add("Red");
            penColorItems.Add("Blue");
            penColorItems.Add("Green");
            listBox1.DataSource = penColorItems;

            // Add items to ListBox2
            fillColorItems.Add("White");
            fillColorItems.Add("Black");
            fillColorItems.Add("Red");
            fillColorItems.Add("Blue");
            fillColorItems.Add("Green");
            listBox2.DataSource = fillColorItems;
        }

        private void bottomPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
