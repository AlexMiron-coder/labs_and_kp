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
    public partial class Form1 : Form
    {
        Invoker invoker;
        Line line;
        Ellipse ellipse;
        Bezier bezier;
        public static string figure;
        public Form1()
        {
            InitializeComponent();

            if (radioButton1.Checked)
            {
                invoker = new Invoker();
                line = new Line();
                invoker.SetCommand(new LineCommand(line));
                invoker.Run();
            }
            if (radioButton2.Checked)
            {
                invoker = new Invoker();
                ellipse = new Ellipse();
                invoker.SetCommand(new EllipseCommand(ellipse));
                invoker.Run();
            }
            if (radioButton3.Checked)
            {
                invoker = new Invoker();
                bezier = new Bezier();
                invoker.SetCommand(new BezierCommand(bezier));
                invoker.Run();
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if(figure == "line")
            {
                pictureBox1.Load(@"C:\Users\Алексей\source\repos\lab14\lab14\images\lin1.png");
            }
            if(figure == "Bezier curve")
            {
                pictureBox1.Load(@"C:\Users\Алексей\source\repos\lab14\lab14\images\Bezier1.png");
            }
            if(figure == "ellipse")
            {
                pictureBox1.Load(@"C:\Users\Алексей\source\repos\lab14\lab14\images\ell1.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                invoker = new Invoker();
                line = new Line();
                invoker.SetCommand(new LineCommand(line));
                invoker.Run();
            }
            if (radioButton2.Checked)
            {
                invoker = new Invoker();
                ellipse = new Ellipse();
                invoker.SetCommand(new EllipseCommand(ellipse));
                invoker.Run();
            }
            if (radioButton3.Checked)
            {
                invoker = new Invoker();
                bezier = new Bezier();
                invoker.SetCommand(new BezierCommand(bezier));
                invoker.Run();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }

    public class Dots
    {
        Point p;
        public Dots(int x, int y)
        {
            this.p.X = x;
            this.p.Y = y;
        }
        public Point point { get; set; }
    }

    public abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }
    
    class Invoker // инициатор команды
    {
        Command com;
        public void SetCommand(Command com)
        {
            this.com = com;
           
        }
        public void Run()
        {
            com.Execute();
        }
        public void Stop()
        {
            com.Undo();
        }
    }

    class Line
    { 
        public void On()
        {
            Form1.figure = "line";
        }
        public void Off()
        {
            Form1.figure = "";
        }

    }
    class LineCommand : Command
    {
        Line line;
        public LineCommand(Line line)
        {
            this.line = line;
        }
        public override void Execute()
        {
            line.On();
        }
        public override void Undo()
        {
            line.Off();
        }
    }
    class Ellipse
    {
        public void On()
        {
            Form1.figure = "ellipse";
        }
        public void Off()
        {
            Form1.figure = "";
        }
    }
    class EllipseCommand : Command
    {
        Ellipse ellipse;
        public EllipseCommand(Ellipse ellipse)
        {
            this.ellipse = ellipse;
        }
        public override void Execute()
        {
            ellipse.On();
        }
        public override void Undo()
        {
            ellipse.Off();
        }
    }
    class Bezier
    {
        public void On()
        {
            Form1.figure = "Bezier curve";
        }
        public void Off()
        {
            Form1.figure = "";
        }
    }
    class BezierCommand : Command
    {
        Bezier bezier;
        public BezierCommand(Bezier bezier)
        {
            this.bezier = bezier;
        }
        public override void Execute()
        {
            bezier.On();
        }
        public override void Undo()
        {
            bezier.Off();   
        }
    }
}
