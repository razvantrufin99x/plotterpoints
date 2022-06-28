using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plotterpoints
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Graphics g;
        public Pen p = new Pen(Color.Black, 2);
        public Brush b = new SolidBrush(Color.Black);
        public Color bkcolor;
        public Font f;

        public int sizex = 800;
        public int sizey = 800;

        public int my = 400;
        public int mx = 400;

        public void drawGraphic()
        { 
            g.DrawLine(p, mx, 0 , mx, sizey);
            g.DrawLine(p, 0, my, sizey, my);
        }
        public void drawPoint(int a, int b)
        {
            int aa = 0;
            int bb = 0;

            //a este x 
            //b este y
            //a creste inspre dreapta si descreste spre stanga
             //insa a pozitiv este la dreapta lui mx iar a negativ este la stanga lui mx
            //b creste in jos si descreste in sus
             //insa b pozitiv este in sus iar b negativ este in jos
             // operatii de genul aa = mx-a unde a este negativ devine aa=mx- (-a) unde -- este + decis atentie la eroarea asta

            if (a > 0 && b > 0) { aa = mx + a; bb = my - b; } // cadran I
            else if (a > 0 && b < 0) { aa = mx + a; bb = my - b; } // cadran IV
            else if (a < 0 && b > 0) { aa = mx + a; bb = my - b; } // cadran II
            else if (a < 0 && b < 0) { aa = mx +  a; bb = my - b; } //cadran III
            else if (a == 0 && b > 0 ) { aa = mx; bb = my - b; } // cadran 0,I,II
            else if (a == 0 && b < 0) { aa = mx; bb = my - b; } //cadran 0,III,IV
            else if (a > 0 && b == 0) { bb = my; aa = mx + a; } //cadran 0,II,III 
            else if (a < 0 && b == 0) { bb = my; aa = mx + a; } //cadran 0,I, IV
            else if (a == 0 && b == 0) { bb = my; aa = mx ; } //0,0


            g.DrawEllipse(p, aa-2, bb-2, 4, 4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = sizex;
            this.Height = sizey;

            f = this.Font;
            bkcolor = this.BackColor;

            g = CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.drawPoint(10,10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawGraphic();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.drawPoint(0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.drawPoint(10, -10);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.drawPoint(-10, 10);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.drawPoint(0, 10);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.drawPoint(-10, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.drawPoint(0, -10);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.drawPoint(10, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.drawPoint(-10, -10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.g.Clear(this.bkcolor);
        }
    }
}
