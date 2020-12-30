using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12_CRPPC
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                string str = textBox1.Text;
                if (treeView1.SelectedNode == null) treeView1.Nodes.Add(str);
                else
                    treeView1.SelectedNode.Nodes.Add(str);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                
                //treeView1.SelectedNode.Nodes.Clear();
                treeView1.SelectedNode.Remove();
            }
        }
    }
}
