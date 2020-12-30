using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12_ICRPPC
{
    public partial class Form1 : Form // Client
    {
        Timer timer;
        ToolStrip toolStripStatusLabel2;
        ToolStrip toolStripStatusLabel3;
        public Form1()
        {
            InitializeComponent();
            Timer timer = new Timer() { Interval = 1000 }; // 1000 миллисекунд
            timer.Tick += timer1_Tick;
            timer.Start();
            statusStrip1.Items.Add(toolStripStatusLabel2);
            statusStrip1.Items.Add(toolStripStatusLabel3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel3.Text = DateTime.Now.ToLongTimeString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, trackBar1.Value, richTextBox1.Font.Style);
            label5.Text = trackBar1.Value.ToString();
        }

        private void Bar1_Scroll(object sender, ScrollEventArgs e)
        {
            richTextBox1.SelectionColor = Color.FromArgb(Bar1.Value, Bar2.Value, Bar3.Value);
        }

        private void Bar2_Scroll(object sender, ScrollEventArgs e)
        {
            richTextBox1.SelectionColor = Color.FromArgb(Bar1.Value, Bar2.Value, Bar3.Value);
        }

        private void Bar3_Scroll(object sender, ScrollEventArgs e)
        {
            richTextBox1.SelectionColor = Color.FromArgb(Bar1.Value, Bar2.Value, Bar3.Value);
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            TextChange text;
            if(toolStripComboBox1.Text == "Arial")
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
