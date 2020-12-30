using System;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Threading;


namespace lab_9._1_OOP
{
    class Program
    {
        public delegate void Print();
        public delegate void F(int value);
        public delegate void G(int number, int side);
        public delegate double Test(int num, float fl);
        public static void PrintName()
        {
            Console.Write("Alex ");
        }
        public static void PrintSecondName()
        {
            Console.Write("Mironov ");
        }
        public static void PrintGroup()
        {
            Console.Write("M80-202Б-19 ");
        }
        public static void F_sqrt(int a)
        {
            Console.WriteLine("    sqrt of {0} = {1}", a,Math.Sqrt(a));
        }
        public static void F_square(int a)
        {
            Console.WriteLine("    square of {0} = {1}", a, a * a);
        }
        public static void F_cube(int a)
        {
            Console.WriteLine("    cube of {0} = {1}", a, a * a * a);
        }
        public static void Area(int number, int side)
        {
            double numerator = number * side * side;
            double angle = 180 / number;
            angle = (angle * Math.PI) / 180;
            double tg = Math.Tan(angle);
            double denominator = 4 * tg;
            double S = numerator / denominator;
            Console.WriteLine("    Area of regular {0}-gon = {1}", number, S);
        }
        public static void Sred(int a, int b)
        {
            string str = "   ";
            for (int i = 0; i < b; i++)
            {
                str += "  ";
                Console.WriteLine("{0} {1}", str, a);
            }
        }
        public static void PrintDelegateParametr(G tmp, int size, int side)
        {
            tmp(size, side);
        }

        static void Main(string[] args)
        {
            F sqrt = F_sqrt;
            F sqrt1 = new F(F_sqrt);
            F square = new F(F_square);
            
            sqrt.Invoke(16);
            Console.WriteLine(" ");
            sqrt(16);

            Console.WriteLine(" ");
            //----------------------------------------------------------

            square.Invoke(4);
            Console.WriteLine(" ");
            //----------------------------------------------------------

            if (sqrt.Equals(sqrt1)) Console.WriteLine("Equals!");
            else Console.WriteLine("Not equals!");

            Console.WriteLine(" ");
            //----------------------------------------------------------

            Console.WriteLine(sqrt.Method.ToString());
            Console.WriteLine(sqrt1.Method.Name.ToString());

            Console.WriteLine(" ");
            //----------------------------------------------------------

            G S = new G(Area);
            Console.WriteLine(S.Method.ToString());
            S.Invoke(5, 10);
            
            Console.WriteLine(" ");
            //----------------------------------------------------------

            sqrt1 = F_cube;
            if (sqrt.Equals(sqrt1)) Console.WriteLine("Equals!");
            else Console.WriteLine("Not equals!");

            Console.WriteLine(" ");
            //----------------------------------------------------------

            Print str = new Print(PrintName);
            Print ptr = new Print(PrintSecondName);
            Print tpr = new Print(PrintGroup);
            str();
            ptr();
            tpr();
            Console.WriteLine(" ");

            Console.WriteLine(" ");
            //----------------------------------------------------------

            G sred = Sred;
            sred(5, 6);

            Console.WriteLine(" ");
            //----------------------------------------------------------

            Print print = delegate ()
            {
                //Console.ReadKey();
                Console.WriteLine("New Delegate (second method)");
                Console.WriteLine("     C makes it easy to shoot yourself in the foot; \n     C++ makes it harder, but when you do, it \n     blows away your whole leg.\n                                  -Stroustrup");
                Console.WriteLine(" ");
                Console.WriteLine("    \"Си\" позволяет очень быстро себе выстрелить в ногу. \n     На \"Си++\" сделать это сложнее, но когда вам это\n     удается, ногу отрывает полностью.");
            };
            print();

            Console.WriteLine(" ");
            //----------------------------------------------------------

            Test pow = delegate (int a, float b)
            {

                return Math.Pow(a, b);
            };
            int integer = 2;
            float step = 12.56f;
            double result = pow(integer, step);
            Console.WriteLine("{0}^{1} = {2}", integer, step, result);

            Console.WriteLine(" ");
            //----------------------------------------------------------

            Console.WriteLine("--------------Multy Cast delegate------------");

            Print name = PrintName;
            name += PrintSecondName;
            name += PrintGroup;

            name();
            Console.WriteLine("");
            name -= PrintName;
            Console.Write("After -= PrintName => ");
            name();
            Console.WriteLine("\nArray of delegate:");
            Delegate[] tmp = name.GetInvocationList();
            for (int i = 0; i < tmp.Length; i++)
            {
                Console.WriteLine("   {0}", tmp[i].GetMethodInfo());
            }
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine(" ");
            //----------------------------------------------------------

            Func<int, int> new_square = delegate (int x) { return x * x; }; // отказ от предварительного описания сигнатуры через описание конкретного типа делегата 
            Func<int, int, string> new_pow = delegate (int x, int y) { return "x^y = " + (Math.Pow(x, y)); };

            Action<int, int> f = (x, y) => Console.WriteLine("x*y = {0}", x * y);
            f(4, 5);

            Console.WriteLine("  new square: {0}", new_square(12));
            Console.WriteLine("  new pow: {0}", new_pow(13, 5));

            Console.WriteLine(" ");
            //----------------------------------------------------------

            sqrt(new_square(12)); // в качестве параметра 1 cпособ
            PrintDelegateParametr(S, 5, 10);  // в качестве параметра 2 способ

        }
    }
}
