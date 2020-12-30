using System;
//using Funct;

namespace Funct
{
    class Functions
    {
        public int F1(int i)
        {
            if (i % 2 == 0)
            {
                return i / 2;
            }
            return i;
        }

        public static void F2(int i)
        {
            if (i % 2  == 0)
            {
                Console.WriteLine("Yes {0}", i);
            }
            else
            {
                Console.WriteLine("No {0}", i);
            }
        }
    }

    class Text
    {
        string str;
        public Text(string ptr)
        {
            this.str = ptr; 
        }
        public Text()
        {
            str = "Hi!";
        }
        public void PrintString()
        {
            Console.WriteLine("After working: {0}", str);
        }
        public string ReturnString()
        {
            return str;
        }
    }
    
}

namespace lab_1._1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 4; 
            Funct.Functions.F2(b);
            Funct.Functions result = new Funct.Functions();
            Console.WriteLine(result.F1(a));
            //-----------------------------
            Funct.Text str1 = new Funct.Text();
            Funct.Text str2 = new Funct.Text("Hello!");
            Funct.Text str3 = new Funct.Text("Good morning!");
            //-----------------------------
            str1.PrintString();
            str2.PrintString();
            string str = str3.ReturnString();
            Console.WriteLine("After working: {0}",str);
            Console.ReadKey();
        }
    }
}
