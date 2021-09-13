using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TEquation q = new TEquation(textBox1.Text, textBox2.Text);
            textBox3.Text = q.print(q.equation) + " = 0";
            textBox4.Text = Math.Round(q.FindMaxRoot(q.equation, q.UpLim), 2).ToString();
        }
    }
    public class TEquation
    {
        public double[] equation;
        public double UpLim;
        public TEquation(string str, string num)
        {
            this.equation = str.Split(' ').Select(double.Parse).ToArray();
            this.UpLim = Convert.ToDouble(num);
        }

        public double FindMaxRoot(double[] p, double up)
        {
            double root = -1e9;
            double maxRoot = root;
            double down = FindDownLim(p);
            double check = up + 1;
            double tmp = up;
            while (tmp > down)
            {
                tmp = tmp - 0.5;
                if (F(p, tmp) * F(p, check) <= 0)
                {
                    maxRoot = NewtonMethod(p, tmp, up);
                    if (maxRoot > root)
                    {
                        root = maxRoot;
                    }
                    up = tmp;
                    check = tmp;
                }
            }
            return root;
        }
        public double NewtonMethod(double[] p, double a, double b)
        {
            double[] diff = Derivative(p);
            double x = a;
            double x0 = b;
            double e = 0.0001;
            while (Math.Abs(x - x0) > e) 
            {
                x0 = x;
                if(F(diff, x0) != 0)
                {
                    x = x0 - F(p, x0) / F(diff, x0);
                    continue;
                }
                x = x0;
            }
            return x;
        }
        public double[] Derivative(double[] arr)
        {
            double[] tmp;
            if (arr.Length == 1)
            {
                tmp = new double[arr.Length];
                tmp[0] = 0;
                return tmp;
            }
            tmp = new double[arr.Length - 1];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                tmp[i] = arr[i] * (arr.Length - i - 1);
            }
            return tmp;
        }
        double F(double[] l, double x)
        {
            double value = 0;
            for (int i = 0; i < l.Length; i++)
            {
                value *= x;
                value += l[i];
            }
            return value;
        }
        public double FindDownLim(double[] list)
        {
            double[] l = new double[list.Length];
            for (int i = 0; i < list.Length; i++)
                l[i] = list[i];
            int check = 1;
            int count = 0;
            int k = 0;
            if (l.Length % 2 == 1)
                for (int i = 1; i < l.Length; i += 2)
                    l[i] *= -1;
            else
                for (int i = 0; i < l.Length; i += 2)
                    l[i] *= -1;
            if (l[0] < 0)
                for (int i = 0; i < l.Length; i++)
                    l[i] *= -1;
            double[] tmp = new double[l.Length];
            tmp[0] = l[0];
            while (k == 0)
            {
                for (int i = 1; i < l.Length; i++)
                {
                    tmp[i] = check * tmp[i - 1] + l[i];
                    if (tmp[i] < 0)
                    {
                        count = 0;
                        break;
                    }
                    else count++;
                }
                if (count == l.Length - 1) k += 1;
                else check++;
            }
            return check * (-1);
        }
        public string UTF(int num)
        {
            string str = "";
            int tmp;
            if (num == 0)
            {
                str += '\x2070';
                return str;
            }
            char[] Arr = new char[num.ToString().Length];
            int i = 0;
            while (num != 0)
            {
                tmp = num % 10;
                switch (tmp)
                {
                    case 0:
                        Arr[i] = '\x2070';
                        break;
                    case 1:
                        Arr[i] = '\x00B9';
                        break;
                    case 2:
                        Arr[i] = '\x00B2';
                        break;
                    case 3:
                        Arr[i] = '\x00B3';
                        break;
                    case 4:
                        Arr[i] = '\x2074';
                        break;
                    case 5:
                        Arr[i] = '\x2075';
                        break;
                    case 6:
                        Arr[i] = '\x2076';
                        break;
                    case 7:
                        Arr[i] = '\x2077';
                        break;
                    case 8:
                        Arr[i] = '\x2078';
                        break;
                    case 9:
                        Arr[i] = '\x2079';
                        break;
                }
                num = num / 10;
                i++;
            }
            for (int j = Arr.Length - 1; j >= 0; j--)
            {
                str += Arr[j];
            }
            return str;
        }
        public string print(double[] p)
        {
            int n = p.Length;
            string str = "";
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1 && i == 0)
                {
                    str += p[i];
                }
                else if (i == n - 2 && i == 0)
                {
                    if (p[i] == 0) continue;
                    else if (Math.Abs(p[i]) == 1)
                    {
                        if (p[i] == 1) str = str + "x";
                        else str = str + "-x";
                    }
                    else
                    {
                        str = str + p[i] + "x";
                    }
                }
                else if (i == n - 1)
                {
                    if (p[i] == 0) continue;
                    else
                    {
                        if (p[i] > 0) str = str + " + " + p[i];
                        else str = str + " - " + Math.Abs(p[i]);
                    }
                }
                else if (i == n - 2)
                {
                    if (p[i] == 0) continue;
                    else if (Math.Abs(p[i]) == 1)
                    {
                        if (p[i] == 1) str = str + " + x";
                        else str = str + " - x";
                    }
                    else
                    {
                        if (p[i] > 0) str = str + " + " + p[i] + "x";
                        else str = str + " - " + Math.Abs(p[i]) + "x";
                    }
                }
                else if (i == 0)
                {
                    if (p[i] == 0) continue;
                    else if (Math.Abs(p[i]) == 1) str = str + "x" + UTF(n - i - 1);
                    else str = str + p[i] + "x" + UTF(n - i - 1);
                }
                else
                {
                    if (p[i] == 0) continue;
                    else if (Math.Abs(p[i]) == 1)
                    {
                        if (p[i] == 1) str = str + " + x" + UTF(n - i - 1);
                        else str = str + " - x" + UTF(n - i - 1);
                    }
                    else
                    {
                        if (p[i] > 0) str = str + " + " + p[i] + "x" + UTF(n - i - 1);
                        else str = str + " - " + Math.Abs(p[i]) + "x" + UTF(n - i - 1);
                    }
                }
            }
            return str;
        }
    }
}
