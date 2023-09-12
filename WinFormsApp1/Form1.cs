using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Pen pen = new Pen(Color.SlateBlue);
        private double start = 0;
        private double end = 0;

        private Gra gra = null;


        private int currentFunction = 0;

        public Form1()
        {
            InitializeComponent();
            groupBox1.Controls.Add(button1);
            comboBox1.Items.Add("y = sin(x)");
            comboBox1.Items.Add("y = x^2");
            comboBox1.SelectedItem = comboBox1.Items[0];
            textBox1.Text = "-5";
            textBox2.Text = "5";
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("asjkdjlad");
            if (Double.TryParse(textBox1.Text, out start))
            {
                if (Double.TryParse(textBox2.Text, out end))
                {
                    gra = (new Gra((float)start, (float)end,
                        comboBox1.Text == "y = sin(x)" ? d => Math.Sin(d) : d => Math.Pow(d, 2)));
                    gra.Show();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}