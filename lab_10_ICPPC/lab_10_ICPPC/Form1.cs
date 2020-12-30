using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_10_ICPPC
{
    public partial class Form1 : Form // View
    {
        Controller controller;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
        }

        //Controller controller = new Controller();

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if (radioTriangle.Checked)
                {
                    label_out.BackColor = Color.White;
                    controller = new Controller(Convert.ToDouble(textBox1.Text));
                    label_out.Text = controller.Triangle().ToString();
                }
                else if (radioSquare.Checked)
                {
                    label_out.BackColor = Color.White;
                    controller = new Controller(Convert.ToDouble(textBox1.Text));
                    label_out.Text = controller.Square().ToString();
                }
                else if (radioCircle.Checked)
                {
                    label_out.BackColor = Color.White;
                    controller = new Controller(Convert.ToDouble(textBox1.Text));
                    label_out.Text = controller.Circle().ToString();
                }
                else if(radioN.Checked && textBox2.Text != "")
                {
                    label_out.BackColor = Color.White;
                    controller = new Controller(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                    label_out.Text = controller.N_angle().ToString();
                }
                else
                {
                    label_out.BackColor = Color.Red;
                    label_out.Text = "ERROR";
                }
            }
            else
            {
                label_out.BackColor = Color.Red;
                label_out.Text = "ERROR";
            }
        } 
    }

    public class Controller
    {
        public double side { get; set; }
        public double size { get; set; }
        public Controller(double side)
        {
            this.side = side;
        }
        public Controller(double side, double size)
        {
            this.side = side;
            this.size = size;
        }
        public Controller()
        {
            this.size = 0;
            this.side = 0;
        }
        public double Triangle()
        {
            return Model.AreaOfTriangle(side);
        }
        public double Square()
        {
            return Model.AreaOfSquare(side);
        }
        public double Circle()
        {
            return Model.AreaOfCircle(side);
        }
        public double N_angle()
        {
            return Model.AreaOfNangle(size, side);
        }
    }

    public class Model
    {
        public static double AreaOfTriangle(double a)
        {
            double p = 3 * a / 2;
            double S = Math.Sqrt(p * Math.Pow(p - a, 3));
            return S;
        }

        public static double AreaOfSquare(double a)
        {
            return a * a;
        }

        public static double AreaOfCircle(double r)
        {
            return Math.PI * r * r;
        }

        public static double AreaOfNangle(double n, double a)
        {
            double S;
            S = n * a * a / (4 * Math.Tan(2 * Math.PI / (2 * n)));
            return S;
        }
    }

}
