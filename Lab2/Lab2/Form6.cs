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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pol pol = new Pol(richTextBox1.Lines, richTextBox1.Lines.Length, richTextBox1.Lines[0].Split(' ').Select(double.Parse).ToArray().Length);
            textBox2.Text = pol.dx == "" ? "0" : "𝜕p/𝜕x = " + pol.dx;
            textBox3.Text = pol.dy == "" ? "0" : "𝜕p/𝜕y = " + pol.dy;
        }
    }
    class Pol
    {
        double[,] polinom;
        public double[,] dpdx;
        public double[,] dpdy;
        public string dx;
        public string dy;
        int N;
        int M;
        public Pol(string[] str, int n, int m)
        {
            polinom = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    polinom[i, j] = Convert.ToDouble(str[i].Split(' ').Select(double.Parse).ToArray()[j]);
                }
            }
            M = m;
            N = n;
            FindDXY();
        }
        public void FindDXY()
        {
            /*for (int i = 0; i < M; i++)
            {
                dpdx.Add(new List<double>());
                for (int j = 0; j < N - 1; j++)
                {
                    dpdx[i].Add(polinom[i, j] * (N - 1 - j));
                }
            }
            if (dpdx[0].Count == 0)
            {
                dpdx[0].Add(0);
            }
            N = N - 1;*/
            dpdy = new double[N - 1, M];
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    dpdy[i, j] = polinom[i, j] * (N - 1 - i);
                    //MessageBox.Show(dpdy[i,j].ToString());
                }
            }
            N = N - 1;
            dy = PolinomPrint(dpdy);
            N = N + 1;
            dpdx = new double[N, M - 1];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M - 1; j++)
                {
                    dpdx[i, j] = polinom[i, j] * (M - 1 - j);
                }
            }
            M = M - 1;
            dx = PolinomPrint(dpdx);
            M = M + 1;
        }

        public string PolinomPrint(double[,] polinom)
        {
            string res = "";
            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    if (i == 0 && j == 0)
                    {
                        if (polinom[i, j] == 0) continue;
                        if (Math.Abs(polinom[i, j]) == 1)
                        {
                            if (M - 1 - j == 0 && N - 1 - i == 0)
                            {
                                res += polinom[i, j] + "  ";
                            }
                            else if (M - 1 - j == 0 && N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += "y ";
                                else res += "-y ";
                            }
                            else if (M - 1 - j == 1 && N - 1 - i == 0)
                            {
                                if (polinom[i, j] > 0) res += "x ";
                                else res += "-x ";
                            }
                            else if (M - 1 - i == 0 && N - 1 - j != 1)
                            {
                                if (polinom[i, j] > 0) res += "xy" + UTF(N - 1 - i) + " ";
                                else res += "-xy" + UTF(N - 1 - i) + " ";
                            }
                            else if (N - 1 - j == 0 && M - 1 - i != 1)
                            {
                                if (polinom[i, j] > 0) res += "x" + UTF(M - 1 - j) + "y ";
                                else res += "-x" + UTF(M - 1 - j) + "y ";
                            }
                            else if (M - 1 - j == 1 && N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += "xy ";
                                else res += "-xy ";
                            }
                            else if (M - 1 - j == 1)
                            {
                                if (polinom[i, j] > 0) res += "xy" + UTF(N - 1 - i) + " ";
                                else res += "-xy" + UTF(N - 1 - i) + " ";
                            }
                            else if (N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += "x" + UTF(M - 1 - j) + "y ";
                                else res += "-x" + UTF(M - 1 - j) + "y ";
                            }
                            else
                            {
                                if (polinom[i, j] > 0) res += "x" + UTF(M - 1 - j) + "y" + UTF(N - 1 - i) + " ";
                                else res += "-x" + UTF(M - 1 - j) + "y" + UTF(N - 1 - i) + " ";
                            }
                        }
                        else
                        {
                            if (M - 1 - j == 0 && N - 1 - i == 0)
                            {
                                res += polinom[i, j] + "  ";
                            }
                            else if (M - 1 - i == 0 && N - 1 - j == 1)
                            {
                                if (polinom[i, j] > 0) res += polinom[i, j].ToString() + "y ";
                                else res += polinom[i, j].ToString() + "y ";
                            }
                            else if (M - 1 - j == 1 && N - 1 - i == 0)
                            {
                                if (polinom[i, j] > 0) res += polinom[i, j].ToString() + "x ";
                                else res += polinom[i, j].ToString() + "x ";
                            }
                            else if (M - 1 - j == 0 && N - 1 - i != 1)
                            {
                                if (polinom[i, j] > 0) res += polinom[i, j].ToString() + "xy" + UTF(N - 1 - i) + " ";
                                else res += polinom[i, j].ToString() + "xy" + UTF(N - 1 - i) + " ";
                            }
                            else if (N - 1 - i == 0 && M - 1 - j != 1 && N - 1 == 0) //////
                            {
                                if (polinom[i, j] > 0) res += polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + " ";
                                else res += polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + " ";
                            }
                            else if (N - 1 - i == 0 && M - 1 - j != 1)
                            {
                                if (polinom[i, j] > 0) res += polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + "y ";
                                else res += polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + "y ";
                            }
                            else if (M - 1 - j == 1 && N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += polinom[i, j].ToString() + "xy ";
                                else res += polinom[i, j].ToString() + "xy ";
                            }
                            else if (M - 1 - j == 1)
                            {
                                if (polinom[i, j] > 0) res += polinom[i, j].ToString() + "xy" + UTF(N - 1 - i) + " ";
                                else res += polinom[i, j].ToString() + "xy" + UTF(N - 1 - i) + " ";
                            }
                            else if (N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + "y ";
                                else res += polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + "y ";
                            }
                            else
                            {
                                if (polinom[i, j] > 0) res += polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + "y" + UTF(N - 1 - i) + " ";
                                else res += polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + "y" + UTF(N - 1 - i) + " ";
                            }
                        }
                    }
                    else if (i == N - 1 && j == M - 1)
                    {
                        if (polinom[i, j] == 0) continue;
                        else if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + " ";
                        else res += "- " + Math.Abs(polinom[i, j]).ToString() + " ";
                    }
                    else if (i == N - 1)
                    {
                        if (j > 0)
                        {
                            if (polinom[i, j] == 0) continue;
                            else if (Math.Abs(polinom[i, j]) == 1)
                            {
                                if (j == M - 2)
                                {
                                    if (polinom[i, j] > 0) res += "+ x ";
                                    else res += "- x ";
                                }
                                else
                                {
                                    if (polinom[i, j] > 0) res += "x" + UTF(M - 1 - j) + " ";
                                    else res += "- x" + UTF(M - 1 - j) + " ";
                                }
                            }
                            else
                            {
                                if (i == 0 && M - 1 - j != 1)
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "x" + UTF(M - 1 - j);
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "x" + UTF(M - 1 - j);
                                }
                                else if (j == M - 2 && M - 1 - j != 1)
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "x" + UTF(M - 1 - j);
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "x" + UTF(M - 1 - j);
                                }
                                else
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "x ";
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "x ";
                                }
                            }
                        }
                        else if (j == 0)
                        {
                            if (M - 1 - j != 1)
                            {
                                if (polinom[i, j] == 0) continue;
                                else if (Math.Abs(polinom[i, j]) == 1)
                                {
                                    if (polinom[i, j] > 0) res += "+ x" + UTF(M - 1 - j);
                                    else res += "- x" + UTF(M - 1 - j);
                                }
                                else
                                {
                                    if (polinom[i, j] > 0) res += "+" + polinom[i, j].ToString() + "x" + UTF(M - 1 - j);
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "x" + UTF(M - 1 - j);
                                }
                            }
                            else
                            {
                                if (polinom[i, j] == 0) continue;
                                else if (Math.Abs(polinom[i, j]) == 1)
                                {
                                    if (polinom[i, j] > 0) res += "+ x ";
                                    else res += "- x ";
                                }
                                else
                                {
                                    if (polinom[i, j] > 0) res += "+" + polinom[i, j].ToString() + "x ";
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "x ";
                                }
                            }
                        }
                    }
                    else if (j == M - 1)  //////////////////////
                    {
                        if (i > 1)
                        {
                            if (polinom[i, j] == 0) continue;
                            else if (Math.Abs(polinom[i, j]) == 1)
                            {
                                if (i == N - 2)
                                {
                                    if (polinom[i, j] > 0) res += "+ y ";
                                    else res += "- y ";
                                }
                                else
                                {
                                    if (polinom[i, j] > 0) res += "y" + UTF(N - 1 - i) + " ";
                                    else res += "- y" + UTF(N - 1 - i) + " ";
                                }
                            }
                            else
                            {
                                if (i == N - 2)
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "y ";
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "y ";
                                }
                                else
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "y" + UTF(N - 1 - i) + " ";
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "y" + UTF(N - 1 - i) + " ";
                                }
                            }
                        }
                        else if (i == 1) ///
                        {
                            if (polinom[i, j] == 0) continue;
                            else if (Math.Abs(polinom[i, j]) == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + " ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + " "; ////////
                            }
                            else
                            {
                                if (i == N - 2 && N != 1)
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "y ";
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "y ";
                                }
                                else
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "y" + UTF(N - 1 - i) + " ";
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "y" + UTF(N - 1 - i) + " ";
                                }
                            }
                        }
                        else if (i == 0)
                        {
                            if (N - 1 - i != 1)
                            {
                                if (polinom[i, j] == 0) continue;
                                else if (Math.Abs(polinom[i, j]) == 1)
                                {
                                    if (polinom[i, j] > 0) res += "+ y" + UTF(N - 1 - i);
                                    else res += "- y" + UTF(N - 1 - i);
                                }
                                else
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "y" + UTF(N - 1 - i) + " ";
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "y" + UTF(N - 1 - i) + " ";
                                }
                            }
                            else
                            {
                                if (polinom[i, j] == 0) continue;
                                else if (Math.Abs(polinom[i, j]) == 1)
                                {
                                    if (polinom[i, j] > 0) res += "+ y ";
                                    else res += "- y ";
                                }
                                else
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "y ";
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "y ";
                                }
                            }
                        }
                    }
                    else
                    {
                        if (polinom[i, j] == 0) continue;
                        if (Math.Abs(polinom[i, j]) == 1)
                        {
                            if (M - 1 - j == 0 && N - 1 - i == 0)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j] + " ";
                                else res += "- " + polinom[i, j] + " ";
                            }
                            else if (M - 1 - j == 0 && N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ y ";
                                else res += "- y ";
                            }
                            else if (M - 1 - j == 1 && N - 1 - i == 0)
                            {
                                if (polinom[i, j] > 0) res += "+ x ";
                                else res += "- x ";
                            }
                            else if (M - 1 - j == 0 && N - 1 - i != 1)
                            {
                                if (polinom[i, j] > 0) res += "+ xy" + UTF(N - 1 - i) + " ";
                                else res += "- xy" + UTF(N - 1 - i) + " ";
                            }
                            else if (N - 1 - i == 0 && M - 1 - j != 1)
                            {
                                if (polinom[i, j] > 0) res += "x" + UTF(M - 1 - j) + "y ";
                                else res += "- x" + UTF(M - 1 - j) + "y ";
                            }
                            else if (M - 1 - j == 1 && N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ xy ";
                                else res += "- xy ";
                            }
                            else if (M - 1 - j == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ xy" + UTF(N - 1 - i) + " ";
                                else res += "- xy" + UTF(N - 1 - i) + " ";
                            }
                            else if (N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ x" + UTF(M - 1 - j) + "y ";
                                else res += "- x" + UTF(M - 1 - j) + "+ y ";
                            }
                            else
                            {
                                if (polinom[i, j] > 0) res += "+ x" + UTF(M - 1 - j) + "y" + UTF(N - 1 - i) + " ";
                                else res += "- x" + UTF(M - 1 - j) + "y" + UTF(N - 1 - i) + " ";
                            }
                        }
                        else
                        {
                            if (M - 1 - j == 0 && N - 1 - i == 0)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j] + "  ";
                                else res += "- " + polinom[i, j] + "  ";
                            }
                            else if (M - 1 - j == 0 && N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "y ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "y ";
                            }
                            else if (M - 1 - j == 1 && N - 1 - i == 0)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "x ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "x ";
                            }
                            else if (M - 1 - j == 0 && N - 1 - i != 1)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "xy" + UTF(N - 1 - i) + " ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "xy" + UTF(N - 1 - i) + " ";
                            }
                            else if (N - 1 - i == 0 && M - 1 - j != 1)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + "y ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "x" + UTF(M - 1 - j) + "y ";
                            }
                            else if (M - 1 - j == 1 && N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "xy ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "xy ";
                            }
                            else if (M - 1 - j == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "xy" + UTF(N - 1 - i) + " ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "xy" + UTF(N - 1 - i) + " ";
                            }
                            else if (N - 1 - i == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + "y ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "x" + UTF(M - 1 - j) + "y ";
                            }
                            else
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "x" + UTF(M - 1 - j) + "y" + UTF(N - 1 - i) + " ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "x" + UTF(M - 1 - j) + "y" + UTF(N - 1 - i) + " ";
                            }
                        }
                    }
                }
            }
            return res;
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
    }
}
