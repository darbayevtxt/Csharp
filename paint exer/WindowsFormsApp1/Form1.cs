using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int direction;
        int toRight = 0;
        int toLeft = 600;
        Graphics g;
        int x = 0;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
        public int cnt = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            x = 0;
            int weather = cnt % 4;
            if (weather == 0)
            {
                direction = 0;
                g.FillRectangle(new SolidBrush(Color.AntiqueWhite), 0, 0, pictureBox1.Width, pictureBox1.Height / 3 - 1);
                g.FillRectangle(new SolidBrush(Color.Blue), 0, (pictureBox1.Height / 3) + 1, pictureBox1.Width, pictureBox1.Height / 3 - 1);
                g.FillRectangle(new SolidBrush(Color.AntiqueWhite), 0, pictureBox1.Height - pictureBox1.Height / 3, pictureBox1.Width, pictureBox1.Height / 3 - 1);
            }
            if (weather == 1)
            {
                direction = 0;
                g.FillRectangle(new SolidBrush(Color.Blue), 0, 0, pictureBox1.Width, pictureBox1.Height);
                g.FillRectangle(new SolidBrush(Color.Green), 0, 0, pictureBox1.Width, pictureBox1.Height / 9 - 1);
                g.FillRectangle(new SolidBrush(Color.Green), 0, pictureBox1.Height - pictureBox1.Height / 9, pictureBox1.Width, pictureBox1.Height / 3 - 1);
            }
            if (weather == 2)
            {
                direction = 1;
                g.FillRectangle(new SolidBrush(Color.Green), 0, 0, pictureBox1.Width, pictureBox1.Height / 3 - 1);
                g.FillRectangle(new SolidBrush(Color.Blue), 0, (pictureBox1.Height / 3) + 1, pictureBox1.Width, pictureBox1.Height / 3 - 1);
                g.FillRectangle(new SolidBrush(Color.Green), 0, pictureBox1.Height - pictureBox1.Height / 3, pictureBox1.Width, pictureBox1.Height / 3 - 1);
            }
            if (weather == 3)
            {
                direction = 1;
                g.FillRectangle(new SolidBrush(Color.Sienna), 0, 0, pictureBox1.Width, pictureBox1.Height / 3 - 1);
                g.FillRectangle(new SolidBrush(Color.Blue), 0, (pictureBox1.Height / 3) + 1, pictureBox1.Width, pictureBox1.Height / 3 - 1);
                g.FillRectangle(new SolidBrush(Color.Sienna), 0, pictureBox1.Height - pictureBox1.Height / 3, pictureBox1.Width, pictureBox1.Height / 3 - 1);
            }


            cnt++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            x += 20;
            if (direction == 0)
            {
                g.FillRectangle(new SolidBrush(Color.Black), toRight + x, 150, 50, 50);
            }
            if (direction == 1)
            {
                g.FillRectangle(new SolidBrush(Color.Black), toLeft - x, 150, 50, 50);
            }
        }
    }
}
