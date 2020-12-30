using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace lab_5_OOP
{
    public interface A
    {
        void method();
        int function();
    }
    public class C : A
    {
        public int c;
        public C() { this.c = 10; }
        public C(int c)
        {
            this.c = c;
        }
        public void method_B()
        {
            Console.WriteLine("method of B class");
        }
        public void method()
        {
            Console.WriteLine("Method of interface A: {0}", c.GetHashCode());
        }
        public int function()
        {
            c = c + c;
            return c;
        }
    }
    interface B : A
    {
        void methB();
        int funcB();
    }
    public class D : C, B
    {
        public int d;
        public D() { this.d = 12; }
        public D(int d, int c) : base(c)
        {
            this.d = d;
        }
        public void methB()
        {
            this.d = this.function() + this.funcB();
            Console.WriteLine("Method B : A => {0}", d);
        }
        public int funcB()
        {
            return d * d * d;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A IA_a = null;
            IA_a = new C();
            Console.WriteLine("B IA_a.function = {0}", IA_a.function());

            B IB_b = null;
            IB_b = new D();
            Console.WriteLine("D IA_a.function = {0}", IB_b.funcB() + IB_b.function());

            IA_a = new D();
            IA_a = new D(14, 15);
            Console.WriteLine("D IA_a.function (new c) = {0}", IA_a.function());
            IA_a.method();
        }
    }
}
