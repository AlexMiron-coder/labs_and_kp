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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TPolinom pol = new TPolinom(richTextBox1.Lines, richTextBox1.Lines.Length, richTextBox1.Lines[0].Split(' ').Select(double.Parse).ToArray().Length, textBox1.Text.Split(' ').Select(double.Parse).ToArray());
            textBox2.Text = pol.PolinomPrint();
            textBox3.Text = pol.result.ToString();
        }
    }
    class TPolinom
    {
        //List<List<int>> polinom;
        double[,] polinom;
        int M;
        int N;
        double x;
        double y;
        public double result;
        public TPolinom(string[] str, int n, int m, double[] dot) // [m*n]
        {
            polinom = new double[n, m];
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    polinom[i, j] = Convert.ToDouble(str[i].Split(' ').Select(double.Parse).ToArray()[j]);
                }
            }
            M = m;
            N = n;
            x = dot[0];
            y = dot[1];
            double[,] temp = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    temp[i, j] = polinom[i, j];
                }
            }
            result = Gorner(temp, x, y);
        }
        public string print()
        {
            string str = "";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    str += polinom[i, j].ToString() + " ";
                }
            }
            return str;
        }
        public double Gorner(double[,] p, double x, double y)
        {
            double result = 0;
            for (int i = 0; i < M - 1; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    for (int z = 0; z < N; z++)
                    {
                        p[z, j] *= x;
                    }
                }
            }
            double[] tmp = new double[N];
            for (int i = 0; i < N; i++) 
            {
                for (int j = 0; j < M; j++) 
                {
                    tmp[i] += p[i, j];
                }
            }
            for (int i = 0; i < tmp.Length - 1; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    tmp[j] *= y;
                }
            }
            for (int i = 0; i < tmp.Length; i++)
            {
                result += tmp[i];
            }
            return result;
        }
        public string PolinomPrint() 
        {
            string res = "P(x,y) = ";
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
                                if (j == M - 2 && M - 1 - j != 1)
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "x" + UTF(M - 1 - j);
                                    else res += "- " + Math.Abs(polinom[i, j]).ToString() + "x" + UTF(M - 1 - j);
                                }
                                else
                                {
                                    if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "x " ;
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
                            else if(Math.Abs(polinom[i,j]) == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + " ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + " "; ////////
                            }
                            else
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "y" + UTF(N - 1 - i) + " ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "y" + UTF(N - 1 - i) + " ";
                            }
                        }
                        else if(i == 0)
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
                    /*else if (j == M - 2 && i > 0) //////
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
                                if (polinom[i, j] > 0) res += "y" + UTF(M - 1 - j) + " ";
                                else res += "- y" + UTF(M - 1 - j) + " ";
                            }
                        }
                        else
                        {
                            if (i == N - 2)
                            {
                                if (polinom[i, j] > 0) res += polinom[i, j].ToString() + "y ";
                                else res += polinom[i, j].ToString() + "y ";
                            }
                            else
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "y" + UTF(M - 1 - j) + " ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "y" + UTF(M - 1 - j) + " ";
                            }
                        }
                    }
                    else if (i == N - 2)
                    {
                        if (j == M - 1)
                        {
                            if (polinom[i, j] == 0) continue;
                            else if (Math.Abs(polinom[i, j]) == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ y "; ///
                                else res += "- y ";
                            }
                            else // мб не так
                            {
                                res += polinom[i, j] > 0 ? "+ " + polinom[i, j].ToString() + "y " : ("- " + Math.Abs(polinom[i, j]).ToString() + "y ");
                            }
                        }
                        else if (i == N - 2 && j == M - 2)
                        {
                            if (polinom[i, j] == 0) continue;
                            if (Math.Abs(polinom[i, j]) == 1)
                            {
                                if (polinom[i, j] > 0) res += "+ xy ";
                                else res += "- xy ";
                            }
                            else
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "xy ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "xy ";
                            }
                        }
                        else
                        {
                            if (polinom[i, j] == 0) continue;
                            else if (Math.Abs(polinom[i, j]) == 1) 
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "xy" + UTF(N - 1 - i) + " ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "xy" + UTF(N - 1 - i) + " ";
                            }
                            else
                            {
                                if (polinom[i, j] > 0) res += "+ " + polinom[i, j].ToString() + "xy" + UTF(N - 1 - i) + " ";
                                else res += "- " + Math.Abs(polinom[i, j]).ToString() + "xy" + UTF(N - 1 - i) + " ";
                            }
                        }
                    } 
                    else if(j == M - 2)
                    {
                        if (i == N - 1)
                        {
                            if (polinom[i, j] == 0) continue;
                            else if (Math.Abs(polinom[i, j]) == 1) 
                            {
                                if (polinom[i, j] > 0) res += "+ x "; //
                                else res += "- x ";
                            }
                            else
                            {
                                res += polinom[i, j] > 0 ? "+ " + polinom[i, j].ToString() + "x " : ("- " + Math.Abs(polinom[i, j]).ToString() + "x ");
                            }
                        }
                        else 
                        {
                            if (polinom[i, j] == 0) continue;
                            else if (Math.Abs(polinom[i, j]) == 1) 
                            {
                                if (polinom[i, j] > 0) res += "- x" + UTF(M - 1 - j) + "y ";
                                else res += "+ x" + UTF(M - 1 - j) + "y ";
                            }
                            else
                            {
                                if (polinom[i, j] > 0) res += "+ x" + UTF(M - 1 - j) + "y" + UTF(N - 1 - i) + " ";
                                else res += "- x" + UTF(M - 1 - j) + "y" + UTF(N - 1 - i) + " ";
                            }
                        }
                    }*/
                    else
                    {
                        if (polinom[i, j] == 0) continue;
                        if (Math.Abs(polinom[i, j]) == 1)
                        {
                            if (M - 1 - j == 0 && N - 1 - i == 0)
                            {
                                if (polinom[i,j] > 0) res += "+ " + polinom[i, j] + " ";
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
