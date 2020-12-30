using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab11_ICRPPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Singleton inst;
        private void button1_Click(object sender, EventArgs e)
        {
            inst = Singleton.GetInstance((int)numericUpDown1.Value);
            MessageBox.Show("HashCode: " + inst.GetHashCode().ToString() + ", Number = " + Singleton.number);
           
        }
    }

    public class Singleton
    {
        private static Singleton instance;
        public static int number { get; private set; }
        private Singleton() { }
        
        public static Singleton GetInstance(int num)
        {
            if(instance == null)
            {
                instance = new Singleton();
                number = num;
            }
            return instance;
        }
    }
}
