using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab14
{
    public partial class Form2 : Form
    {
        public string ans;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Facade facade = new Facade(new SubSystem1(), new SubSystem2(), new SubSystem3());
            facade.num = Convert.ToInt32(textBox1.Text);
            facade.Operation1();
            label1.Text += facade.ans;
            facade.Operation2();
            label2.Text += facade.ans;
            facade.Operation3();
            label3.Text += facade.ans;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    public class Facade
    {
        public int num = 100;
        public string ans;
        SubSystem1 sb1;
        SubSystem2 sb2;
        SubSystem3 sb3;
        public Facade(SubSystem1 sb1, SubSystem2 sb2, SubSystem3 sb3)
        {
            this.sb1 = sb1;
            this.sb2 = sb2;
            this.sb3 = sb3;
        }
        public void Operation1()
        {
            ans = sb1.F1(num);
        }
        public void Operation2()
        {
            ans = sb2.F2(num);
        }
        public void Operation3()
        {
            ans = sb3.F3(num);
        }
        public void Operation4()
        {
            ans = "";
        }
    }
    public class SubSystem1
    {
        public string F1(int a)
        {
            return Convert.ToString(a, 2);
        }
    }
    public class SubSystem2
    {
        public string F2(int a)
        {
            return Convert.ToString(a, 8);
        }
    }
    public class SubSystem3
    {
        public string F3(int a)
        {
            return Convert.ToString(a, 16);
        }
    }
}
