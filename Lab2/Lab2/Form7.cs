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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Polinom pol = new Polinom(richTextBox1.Lines, richTextBox1.Lines.Length, richTextBox1.Lines[0].Split(' ').Select(double.Parse).ToArray().Length, richTextBox2.Lines, richTextBox2.Lines.Length, richTextBox2.Lines[0].Split(' ').Select(double.Parse).ToArray().Length);
            textBox2.Text = Math.Round(pol.ans[0], 4).ToString();
            textBox3.Text = Math.Round(pol.ans[1], 4).ToString();
        }
    }
    class Polinom
    {
        public double[,] polinom1;
        public double[,] polinom2;
        public List<double> ans;
        int M1;
        int N1;
        public Polinom(string[] str1, int n1, int m1, string[] str2, int n2, int m2)
        {
            polinom1 = new double[n1, m1];
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < m1; j++)
                {
                    polinom1[i, j] = Convert.ToDouble(str1[i].Split(' ').Select(double.Parse).ToArray()[j]);
                }
            }
            M1 = m1;
            N1 = n1;
            polinom2 = new double[n2, m2];
            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < m2; j++)
                {
                    polinom2[i, j] = Convert.ToDouble(str2[i].Split(' ').Select(double.Parse).ToArray()[j]);
                }
            }
            M1 = m2;
            N1 = n2;
            List<List<double>> tmp1 = new List<List<double>>();
            for (int i = 0; i < n1; i++)
            {
                tmp1.Add(new List<double>());
                for (int j = 0; j < m1; j++)
                {
                    tmp1[i].Add(polinom1[i, j]);
                }
            }
            List<List<double>> tmp2 = new List<List<double>>();
            for (int i = 0; i < n2; i++)
            {
                tmp2.Add(new List<double>());
                for (int j = 0; j < m2; j++)
                {
                    tmp2[i].Add(polinom2[i, j]);
                }
            }
            ans = new List<double>();
            ans = Newton2(tmp1, tmp2, -1, 1);
        }
        public List<List<double>> Dx(List<List<double>> list)
        {
            List<List<double>> listX = new List<List<double>>();
            for (int i = 0; i < list.Count; i++)
            {
                listX.Add(new List<double>());
                for (int j = 0; j < list[list.Count - 1].Count - 1; j++)
                {
                    listX[i].Add(list[i][j] * (list[list.Count - 1].Count - 1 - j));
                }
            }
            if (listX[0].Count == 0)
            {
                listX[0].Add(0);
            }
            return listX;
        }
        public List<List<double>> Dy(List<List<double>> list)
        {
            List<List<double>> listY = new List<List<double>>();
            for (int i = 0; i < list.Count - 1; i++)
            {
                listY.Add(new List<double>());
                for (int j = 0; j < list[list.Count - 1].Count; j++)
                {
                    listY[i].Add(list[i][j] * (list.Count - 1 - i));
                }
            }
            if (listY.Count == 0)
            {
                listY.Add(new List<double>());
                listY[0].Add(0);
            }
            return listY;
        }
        public double Gorner(List<double> list, double dot)
        {
            double result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                result *= dot;
                result += list[i];
            }
            return result;
        }
        public double Gorner2(List<List<double>> matrix, double x, double y)
        {
            List<double> helper = new List<double>();
            for (int i = 0; i < matrix.Count; i++)
                helper.Add(Gorner(matrix[i], x));
            return Gorner(helper, y);
        }
        double Jacobian(List<List<double>> a, List<List<double>> b, double x, double y)
        {
            return Gorner2(Dx(a), x, y) * Gorner2(Dy(b), x, y) - Gorner2(Dy(a), x, y) * Gorner2(Dx(b), x, y);
        }
        public List<double> Newton2(List<List<double>> real, List<List<double>> complex, double x, double y)
        {
            double x1, y1;
            while ((Math.Abs(Gorner2(real, x, y)) >= 0.0001) || (Math.Abs(Gorner2(complex, x, y)) >= 0.0001))
            {
                if (Jacobian(real, complex, x, y) == 0)
                    break;
                x1 = x - ((Gorner2(real, x, y) * Gorner2(Dy(complex), x, y) - Gorner2(complex, x, y) * Gorner2(Dy(real), x, y)) / Jacobian(real, complex, x, y));
                y1 = y - ((Gorner2(Dx(real), x, y) * Gorner2(complex, x, y) - Gorner2(Dx(complex), x, y) * Gorner2(real, x, y)) / Jacobian(real, complex, x, y));
                x = x1;
                y = y1;
            }
            List<double> answer = new List<double>();
            answer.Add(x);
            answer.Add(y);
            return answer;
        }
    }
}
