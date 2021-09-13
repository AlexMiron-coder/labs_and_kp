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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Polinom p = new Polinom(textBox1.Text);
            textBox2.Text = "f(x) = " + p.print(p.polinom);
            textBox3.Text = "f'(x) = " + p.print(p.der);
            textBox4.Text = string.Join(" ", p.der);
        }
        class Polinom
        {
            public int[] polinom;
            public int[] der;
            public Polinom(string str)
            {
                polinom = str.Split(' ').Select(int.Parse).ToArray();
                der = Derivative(polinom);
            }
            public int[] Derivative(int[] arr)
            {
                int[] tmp;
                if (arr.Length == 1)
                {
                    tmp = new int[arr.Length];
                    tmp[0] = 0;
                    return tmp;
                }
                tmp = new int[arr.Length - 1];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    tmp[i] = arr[i] * (arr.Length - i - 1);
                }
                return tmp;
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
            public string print(int[] p)
            {
                int n = p.Length;
                string str = "";
                for (int i = 0; i < n; i++)
                {
                    if (i == n - 1 && i == 0)
                    {
                        str += p[i];
                    }
                    else if(i == n - 2 && i == 0)
                    {
                        if (p[i] == 0) continue;
                        else if(Math.Abs(p[i]) == 1)
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
}
