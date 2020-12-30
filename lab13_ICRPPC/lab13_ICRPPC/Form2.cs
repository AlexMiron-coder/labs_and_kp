using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab13_ICRPPC
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            Button button = (Button)e.Data.GetData(typeof(Button));
            button.Parent = (Panel)sender;
            //button1.Location = new Point(this.Location.X, this.Location.Y);
            button.Location = new Point(
                 e.X - this.Location.X - ((Panel)sender).Location.X - 10 - button.Size.Width / 2,
                 e.Y - this.Location.Y - ((Panel)sender).Location.Y - 30 - button.Size.Height / 2);
            panel1.BackColor = Color.Green;
            panel2.BackColor = Color.Red;
        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }


        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            Button button = (Button)e.Data.GetData(typeof(Button));
            button.Parent = (Panel)sender;
            //button1.Location = new Point(this.Location.X, this.Location.Y);
            button.Location = new Point(
                 e.X - this.Location.X - ((Panel)sender).Location.X - 10 - button.Size.Width / 2,
                 e.Y - this.Location.Y - ((Panel)sender).Location.Y - 30 - button.Size.Height / 2);
            panel2.BackColor = Color.Green;
            panel1.BackColor = Color.Red;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.DoDragDrop(button1, DragDropEffects.Copy | DragDropEffects.Move);
        }
    }
}
