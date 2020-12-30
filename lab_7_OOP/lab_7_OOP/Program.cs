using System;

namespace lab_7_OOP
{
    class A<T>
    {
        private T t;
        public A(T t)
        {
            this.t = t;
        }
        public void print()
        {
            if(t is int)
            {
                Console.WriteLine("It,s a integer, 2 = {0}", t);
            }
            if((t is double))
            {
                Console.WriteLine("It's a double, t = {0}", t);
            }
            if ((t is float))
            {
                Console.WriteLine("It's a float, t = {0}", t);
            }
            if (t is string)
            {
                Console.WriteLine("It's a string, t : " +t);
            }
        }
        public static void swap(ref T t1, ref T t2)
        {
            T t3 = t1;
            t1 = t2;
            t2 = t3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A<int> i1 = new A<int>(12);
            A<int> i2 = new A<int>(14);
            
            A<double> d1 = new A<double>(15.654);
            A<double> d2 = new A<double>(16.52325);
            
            A<float> f1 = new A<float>(1.2f);
            A<float> f2 = new A<float>(2.4f);

            A<string> s1 = new A<string>("Hi, ");
            A<string> s2 = new A<string>("my name is Alex!");

            i1.print();
            d1.print();
            f1.print();
            s1.print();

            int x = 1;
            int y = 2;

            Console.WriteLine("x = {0} y = {1}", x, y);
            A<int>.swap(ref x, ref y);
            Console.WriteLine("x = {0} y = {1}",x, y);
        }
    }
}
