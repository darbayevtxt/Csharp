using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string a = "";
                for (int i = textBox1.Text.Length - 1; i >= 0; i--)
                {
                    a += textBox1.Text[i];
                }
                textBox2.Text = a;
                textBox1.Text = "";
            }
            if (radioButton2.Checked == true)
            {
                bool isTr = true;
                for (int i = 0; i < textBox1.Text.Length / 2; i++)
                {
                    if (textBox1.Text[i] != textBox1.Text[textBox1.Text.Length - i - 1])
                    {
                        isTr = false;
                        break;
                    }
                }
                if (isTr)
                {
                    textBox2.Text = "Palindrome";
                }
                else
                {
                    textBox2.Text = "Not Palindrome";
                }
                textBox1.Text = "";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
