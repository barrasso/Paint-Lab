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

        // current pen color
        public Pen currentPenColor;

        // current text color
        public Brush currentTextColor;

        // current fill color 
        public Brush currentFillColor;

        // current pen width
        public int currentPenWidth;

        // flag to check fill check box
        public bool isFillChecked;

        // flag to check outline check box
        public bool isOutlineChecked;

        // flag to check mouse clicks
        public bool hasBeenClicked;

        // First mouse click point
        public Point firstPoint;

        // second mouse click point
        public Point secondPoint;


        // default constructor
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

            // draw the graphics objects
            foreach(Mark obj in graphicsList)
            {
                // if object is a line
                if(obj.GetType() == typeof(Lines))
                    obj.drawShape(g);

                // check if obj is myrect
                else if(obj.GetType() == typeof(MyRect))
                {
                    obj.drawShape(g);
                }

                // check if obj is myellipse
                else if(obj.GetType() == typeof(MyEllipse))
                {
                    obj.drawShape(g);
                }

                // check if obj is mytext
                else if(obj.GetType() == typeof(MyText))
                {
                    obj.drawShape(g);
                }
            }
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
            this.paintPanel.Refresh();
        }

        // handle pen color list box index changes
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
                    // set current pen color based on selected
                    switch(currentIndex)
                    {
                        case "Black":
                            currentPenColor = new Pen(Color.Black);
                            currentTextColor = Brushes.Black;
                            break;
                        case "Red":
                            currentPenColor = new Pen(Color.Red);
                            currentTextColor = Brushes.Red;
                            break;
                        case "Blue":
                            currentPenColor = new Pen(Color.Blue);
                            currentTextColor = Brushes.Blue;
                            break;
                        case "Green":
                            currentPenColor = new Pen(Color.Green);
                            currentTextColor = Brushes.Green;
                            break;
                        default:
                            break;
                    }
                }
            }
            this.paintPanel.Refresh();
        }

        // handle fill color list box index changes
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
                    // set current fill color based on index
                    switch (currentIndex)
                    {
                        case "White":
                            currentFillColor = Brushes.White;
                            break;
                        case "Black":
                            currentFillColor = Brushes.Black;
                            break;
                        case "Red":
                            currentFillColor = Brushes.Red;
                            break;
                        case "Blue":
                            currentFillColor = Brushes.Blue;
                            break;
                        case "Green":
                            currentFillColor = Brushes.Green;
                            break;
                        default:
                            break;
                    }
                }
            }
            this.paintPanel.Refresh();
        }

        // handle pen width list box index changes
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
                    // set pen width based on selected index
                    switch(currentIndex)
                    {
                        case "1":
                            currentPenWidth = 1;
                            break;
                        case "2":
                            currentPenWidth = 2;
                            break;
                        case "3":
                            currentPenWidth = 3;
                            break;
                        case "4":
                            currentPenWidth = 4;
                            break;
                        case "5":
                            currentPenWidth = 5;
                            break;
                        case "6":
                            currentPenWidth = 6;
                            break;
                        case "7":
                            currentPenWidth = 7;
                            break;
                        case "8":
                            currentPenWidth = 8;
                            break;
                        case "9":
                            currentPenWidth = 9;
                            break;
                        case "10":
                            currentPenWidth = 10;
                            break;
                        default:
                            break;
                    }
                }
            }
            this.paintPanel.Refresh();
        }

        // handle fill check box changes
        private void fillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fillCheckBox.Checked) isFillChecked = true;
            else isFillChecked = false;

            this.paintPanel.Refresh();
        }

        // handle outline check box changes
        private void outlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (outlineCheckBox.Checked) isOutlineChecked = true;
            else isOutlineChecked = false;

            this.paintPanel.Refresh();
        }

        // handle clicks in the paint panel
        private void paintPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (!hasBeenClicked)
            {
                // set first point
                firstPoint = new Point(e.X, e.Y);
                hasBeenClicked = true;
            }
            else
            {
                // set second point
                secondPoint = new Point(e.X, e.Y);
                
                // determine which object to draw
                switch (currentDrawControl)
                {
                    case "Line":
                        Lines newLine = new Lines(firstPoint, secondPoint, currentPenColor);
                        graphicsList.Add(newLine);
                        break;
                    case "Rectangle":
                        // IF BOTH CHECKBOXES ARE CHECKED
                        if(isOutlineChecked && isFillChecked)
                        {
                            // if user clicks bottom right corner then upper left
                            if (secondPoint.X < firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                MyRect newRect = new MyRect(secondPoint, firstPoint, currentPenColor, currentFillColor);
                                graphicsList.Add(newRect);
                                break;
                            }
                            // if user clicks upper right corner then lower left
                            else if (firstPoint.X > secondPoint.X && firstPoint.Y < secondPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.X;
                                firstPoint.X = secondPoint.X;
                                secondPoint.X = temp;

                                MyRect newRect = new MyRect(firstPoint, secondPoint, currentPenColor, currentFillColor);
                                graphicsList.Add(newRect);
                                break;
                            }
                            // if user clicks lower left then upper right
                            else if (secondPoint.X > firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.Y;
                                firstPoint.Y = secondPoint.Y;
                                secondPoint.Y = temp;

                                MyRect newRect = new MyRect(firstPoint, secondPoint, currentPenColor, currentFillColor);
                                graphicsList.Add(newRect);
                                break;
                            }
                            
                            else
                            {
                                MyRect newRect = new MyRect(firstPoint, secondPoint, currentPenColor, currentFillColor);
                                graphicsList.Add(newRect);
                                break;
                            }
                        }
                        // IF ONLY FILL IS CHECKED
                        else if(!isOutlineChecked && isFillChecked)
                        {
                            // if user clicks bottom right corner then upper left
                            if (secondPoint.X < firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                MyRect newRect = new MyRect(secondPoint, firstPoint, currentFillColor);
                                graphicsList.Add(newRect);
                                break;
                            }
                            // if user clicks upper right corner then lower left
                            else if (firstPoint.X > secondPoint.X && firstPoint.Y < secondPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.X;
                                firstPoint.X = secondPoint.X;
                                secondPoint.X = temp;

                                MyRect newRect = new MyRect(firstPoint, secondPoint, currentFillColor);
                                graphicsList.Add(newRect);
                                break;
                            }
                            // if user clicks lower left then upper right
                            else if (secondPoint.X > firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.Y;
                                firstPoint.Y = secondPoint.Y;
                                secondPoint.Y = temp;

                                MyRect newRect = new MyRect(firstPoint, secondPoint, currentFillColor);
                                graphicsList.Add(newRect);
                                break;
                            }

                            else
                            {
                                MyRect newRect = new MyRect(firstPoint, secondPoint, currentFillColor);
                                graphicsList.Add(newRect);
                                break;
                            }
                        }
                        // IF ONLY OUTLINE IS CHECKED
                        else if (isOutlineChecked && !isFillChecked)
                        {
                            // if user clicks bottom right corner then upper left
                            if (secondPoint.X < firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                MyRect newRect = new MyRect(secondPoint, firstPoint, currentPenColor);
                                graphicsList.Add(newRect);
                                break;
                            }
                            // if user clicks upper right corner then lower left
                            else if (firstPoint.X > secondPoint.X && firstPoint.Y < secondPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.X;
                                firstPoint.X = secondPoint.X;
                                secondPoint.X = temp;

                                MyRect newRect = new MyRect(firstPoint, secondPoint, currentPenColor);
                                graphicsList.Add(newRect);
                                break;
                            }
                            // if user clicks lower left then upper right
                            else if (secondPoint.X > firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.Y;
                                firstPoint.Y = secondPoint.Y;
                                secondPoint.Y = temp;

                                MyRect newRect = new MyRect(firstPoint, secondPoint, currentPenColor);
                                graphicsList.Add(newRect);
                                break;
                            }

                            else
                            {
                                MyRect newRect = new MyRect(firstPoint, secondPoint, currentPenColor);
                                graphicsList.Add(newRect);
                                break;
                            }
                        }
                        else
                            break;
                    case "Ellipse":
                        // IF BOTH CHECKBOXES ARE CHECKED
                        if (isOutlineChecked && isFillChecked)
                        {
                            // if user clicks bottom right corner then upper left
                            if (secondPoint.X < firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                MyEllipse newEllipse = new MyEllipse(secondPoint, firstPoint, currentPenColor, currentFillColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }
                            // if user clicks upper right corner then lower left
                            else if (firstPoint.X > secondPoint.X && firstPoint.Y < secondPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.X;
                                firstPoint.X = secondPoint.X;
                                secondPoint.X = temp;

                                MyEllipse newEllipse = new MyEllipse(firstPoint, secondPoint, currentPenColor, currentFillColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }
                            // if user clicks lower left then upper right
                            else if (secondPoint.X > firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.Y;
                                firstPoint.Y = secondPoint.Y;
                                secondPoint.Y = temp;

                                MyEllipse newEllipse = new MyEllipse(firstPoint, secondPoint, currentPenColor, currentFillColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }

                            else
                            {
                                MyEllipse newEllipse = new MyEllipse(firstPoint, secondPoint, currentPenColor, currentFillColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }
                        }
                        // IF ONLY FILL IS CHECKED
                        else if (!isOutlineChecked && isFillChecked)
                        {
                            // if user clicks bottom right corner then upper left
                            if (secondPoint.X < firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                MyEllipse newEllipse = new MyEllipse(secondPoint, firstPoint, currentFillColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }
                            // if user clicks upper right corner then lower left
                            else if (firstPoint.X > secondPoint.X && firstPoint.Y < secondPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.X;
                                firstPoint.X = secondPoint.X;
                                secondPoint.X = temp;

                                MyEllipse newEllipse = new MyEllipse(firstPoint, secondPoint, currentFillColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }
                            // if user clicks lower left then upper right
                            else if (secondPoint.X > firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.Y;
                                firstPoint.Y = secondPoint.Y;
                                secondPoint.Y = temp;

                                MyEllipse newEllipse = new MyEllipse(firstPoint, secondPoint, currentFillColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }

                            else
                            {
                                MyEllipse newEllipse = new MyEllipse(firstPoint, secondPoint, currentFillColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }
                        }
                        // IF ONLY OUTLINE IS CHECKED
                        else if (isOutlineChecked && !isFillChecked)
                        {
                            // if user clicks bottom right corner then upper left
                            if (secondPoint.X < firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                MyEllipse newEllipse = new MyEllipse(secondPoint, firstPoint, currentPenColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }
                            // if user clicks upper right corner then lower left
                            else if (firstPoint.X > secondPoint.X && firstPoint.Y < secondPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.X;
                                firstPoint.X = secondPoint.X;
                                secondPoint.X = temp;

                                MyEllipse newEllipse = new MyEllipse(firstPoint, secondPoint, currentPenColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }
                            // if user clicks lower left then upper right
                            else if (secondPoint.X > firstPoint.X && secondPoint.Y < firstPoint.Y)
                            {
                                // invert the points
                                int temp;
                                temp = firstPoint.Y;
                                firstPoint.Y = secondPoint.Y;
                                secondPoint.Y = temp;

                                MyEllipse newEllipse = new MyEllipse(firstPoint, secondPoint, currentPenColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }

                            else
                            {
                                MyEllipse newEllipse = new MyEllipse(firstPoint, secondPoint, currentPenColor);
                                graphicsList.Add(newEllipse);
                                break;
                            }
                        }
                        else
                            break;
                    case "Text":
                        // if user clicks bottom right corner then upper left
                        if (secondPoint.X < firstPoint.X && secondPoint.Y < firstPoint.Y)
                        {
                            MyText newText = new MyText(secondPoint, firstPoint, currentTextColor, textBox1.Text);
                            graphicsList.Add(newText);
                            break;
                        }
                        // if user clicks upper right corner then lower left
                        else if (firstPoint.X > secondPoint.X && firstPoint.Y < secondPoint.Y)
                        {
                            // invert the points
                            int temp;
                            temp = firstPoint.X;
                            firstPoint.X = secondPoint.X;
                            secondPoint.X = temp;

                            MyText newText = new MyText(firstPoint, secondPoint, currentTextColor, textBox1.Text);
                            graphicsList.Add(newText);
                            break;
                        }
                        // if user clicks lower left then upper right
                        else if (secondPoint.X > firstPoint.X && secondPoint.Y < firstPoint.Y)
                        {
                            // invert the points
                            int temp;
                            temp = firstPoint.Y;
                            firstPoint.Y = secondPoint.Y;
                            secondPoint.Y = temp;

                            MyText newText = new MyText(firstPoint, secondPoint, currentTextColor, textBox1.Text);
                            graphicsList.Add(newText);
                            break;
                        }

                        else
                        {
                            MyText newText = new MyText(firstPoint, secondPoint, currentTextColor, textBox1.Text);
                            graphicsList.Add(newText);
                            break;
                        }
                    default:
                        break;
                }

                hasBeenClicked = false;
            }

            // must invalidate
            this.paintPanel.Refresh();
        }

        // clear clicked
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear graphics list
            if (graphicsList.Count != 0) graphicsList.Clear();
            
            // refresh paint panel
            this.paintPanel.Refresh();
        }

        // exit clicked
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exit application
            this.Close();
        }
        

    }
}
