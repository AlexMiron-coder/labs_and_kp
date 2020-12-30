using System;
using System.IO;
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
    public partial class Form1 : Form
    {
        Timer timer;
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Текстовый файл (*.txt)|*.txt|Любой файл (*.*)|*.*";

            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 }; // 1000 миллисекунд
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            TextChange text;
            if (toolStripComboBox1.Text == "Arial")
            {
                text = new TextChange(true, false, false, false);

                ArialHandler arial = new ArialHandler();
                CalibriHandler calibri = new CalibriHandler();
                TNRHandler tnr = new TNRHandler();
                SymbHandler symb = new SymbHandler();

                arial.Successor = calibri;
                calibri.Successor = tnr;
                tnr.Successor = symb;

                arial.HandlerRequest(text);


                richTextBox1.Font = text.f;
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, Convert.ToInt32(toolStripComboBox2.Text), richTextBox1.Font.Style);
            }
            if (toolStripComboBox1.Text == "Calibri")
            {
                text = new TextChange(false, true, false, false);

                ArialHandler arial = new ArialHandler();
                CalibriHandler calibri = new CalibriHandler();
                TNRHandler tnr = new TNRHandler();
                SymbHandler symb = new SymbHandler();

                arial.Successor = calibri;
                calibri.Successor = tnr;
                tnr.Successor = symb;

                arial.HandlerRequest(text);


                richTextBox1.Font = text.f;
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, Convert.ToInt32(toolStripComboBox2.Text), richTextBox1.Font.Style);
            }
            if (toolStripComboBox1.Text == "Times New Roman")
            {
                text = new TextChange(false, false, true, false);

                ArialHandler arial = new ArialHandler();
                CalibriHandler calibri = new CalibriHandler();
                TNRHandler tnr = new TNRHandler();
                SymbHandler symb = new SymbHandler();

                arial.Successor = calibri;
                calibri.Successor = tnr;
                tnr.Successor = symb;

                arial.HandlerRequest(text);


                richTextBox1.Font = text.f;
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, Convert.ToInt32(toolStripComboBox2.Text), richTextBox1.Font.Style);
            }
            if (toolStripComboBox1.Text == "Symbol")
            {
                text = new TextChange(false, false, false, true);

                ArialHandler arial = new ArialHandler();
                CalibriHandler calibri = new CalibriHandler();
                TNRHandler tnr = new TNRHandler();
                SymbHandler symb = new SymbHandler();

                arial.Successor = calibri;
                calibri.Successor = tnr;
                tnr.Successor = symb;

                arial.HandlerRequest(text);


                richTextBox1.Font = text.f;
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, Convert.ToInt32(toolStripComboBox2.Text), richTextBox1.Font.Style);
            }
        }
        private void toolStripComboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int size = Convert.ToInt32(toolStripComboBox2.Text);
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, size, richTextBox1.Font.Style);
            }
            catch
            {
                MessageBox.Show("Не число!");
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            richTextBox1.SelectionColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            richTextBox1.SelectionColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            richTextBox1.SelectionColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, trackBar1.Value, richTextBox1.Font.Style);
            label5.Text = trackBar1.Value.ToString();
        }

       
        

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                File.WriteAllText(filename,richTextBox1.Text);
                MessageBox.Show("Файл сохранен!");
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string fileText = File.ReadAllText(filename);
                richTextBox1.Text = fileText;
                MessageBox.Show("Файл открыт!");
            }
        }

        private void dragAndDropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }
    }


    class TextChange
    {
        public bool Arial { get; set; }
        public bool Calibri { get; set; }
        public bool TNR { get; set; }
        public bool Symb { get; set; }
        public Font f { get; set; }
        public TextChange(bool Arial, bool Calibri, bool TNR, bool Symb)
        {
            this.Arial = Arial;
            this.Calibri = Calibri;
            this.TNR = TNR;
            this.Symb = Symb;
            f = new Font("Times New Roman", 12, FontStyle.Regular); // default settings
        }

    }
    abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandlerRequest(TextChange text);
    }

    class ArialHandler : Handler
    {
        public override void HandlerRequest(TextChange text)
        {
            if (text.Arial == true)
                text.f = new Font("Arial", 12, FontStyle.Regular);

            else if (Successor != null)
                Successor.HandlerRequest(text);
        }
    }
    class CalibriHandler : Handler
    {
        public override void HandlerRequest(TextChange text)
        {
            if (text.Calibri == true)
                text.f = new Font("Calibri", 12, FontStyle.Regular);
            else if (Successor != null)
                Successor.HandlerRequest(text);
        }
    }
    class TNRHandler : Handler
    {
        public override void HandlerRequest(TextChange text)
        {
            if (text.TNR == true)
                text.f = new Font("Times New Roman", 12, FontStyle.Regular);
            else if (Successor != null)
                Successor.HandlerRequest(text);
        }
    }
    class SymbHandler : Handler
    {
        public override void HandlerRequest(TextChange text)
        {
            if (text.Symb == true)
                text.f = new Font("Symbol", 12, FontStyle.Regular);
            else if (Successor != null)
                Successor.HandlerRequest(text);
        }
    }
}
