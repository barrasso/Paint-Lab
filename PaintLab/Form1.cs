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

        // Pen Color List Box 1 Strings
        public List<string> penColorItems = new List<string>();

        // Fill Color List Box 2 Strings
        public List<string> fillColorItems = new List<string>();

        // Pen Width List Box 3 Strings
        public List<string> penWidthItems = new List<string>();

        // hold current draw control selected
        public string currentDrawControl;

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

            // Add items to ListBox3
            penWidthItems.Add("1");
            penWidthItems.Add("2");
            penWidthItems.Add("3");
            penWidthItems.Add("4");
            penWidthItems.Add("5");
            penWidthItems.Add("6");
            penWidthItems.Add("7");
            penWidthItems.Add("8");
            penWidthItems.Add("9");
            penWidthItems.Add("10");
            listBox3.DataSource = penWidthItems;
        }

        private void bottomPanel_Paint(object sender, PaintEventArgs e)
        {
            // get graphics object
            Graphics g = e.Graphics;
            
        }

        // check for radio button change in draw groupbox
        private void checkedChanged(object sender, EventArgs e)
        {
            // init current control string
            currentDrawControl = null;

            // loop through each control in the draw groupbox
            foreach (Control control in drawGroupBox.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    // check which button is checked
                    if (radio.Checked)
                    {
                        // set string to the currently checked control
                        currentDrawControl = radio.Text;
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // loop through list box1
            foreach (string penColor in penColorItems)
            {
                // set the currentindex to a string
                string currentIndex = listBox1.SelectedItem.ToString();
                // compare strings
                if(penColor == currentIndex)
                {
                    this.Text = currentIndex;
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // loop through list box2
            foreach (string fillColor in fillColorItems)
            {
                // set the current index to a string
                string currentIndex = listBox2.SelectedItem.ToString();
                // compare strings
                if(fillColor == currentIndex)
                {
                    this.Text = currentIndex;
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // loop through list box 3
            foreach (string penWidth in penWidthItems)
            {
                // set the current index to a string
                string currentIndex = listBox3.SelectedItem.ToString();
                // compare strings
                if(penWidth == currentIndex)
                {
                    this.Text = currentIndex;
                }
            }

        }

    }
}
