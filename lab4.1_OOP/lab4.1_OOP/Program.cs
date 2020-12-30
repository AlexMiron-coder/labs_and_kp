using System;


namespace lab4._1_OOP
{
    //--------------------------------------------------
    // Расширение
    public class A
    {
        public int a { set; get; }
        public virtual int f()
        {
            Console.WriteLine("superclass A f(): ");
            return a;
        }
    }
    public class B : A
    {
        public B(int b) { this.b = b; }

        //Расиширение по полю
        public int b { set; get; }
        public void f_b()
        {
            Console.WriteLine("Расширение по полю");
            Console.WriteLine("class B f_b(): {0}", b);
        }
        //

        public override int f()
        {
            Console.WriteLine("class B : A f()");
            return base.f() + 1;
        }
    }
    public class J : A
    {
        public int j { set; get; }
        public override int f()
        {
            return base.f() + 2;
        }
        //Расширение по функции
        public int f1()
        {
            Console.WriteLine("Расширение по функции");
            Console.WriteLine("class J f1 => class A f(): ");
            return base.f() + 3;
        }
        //
    }

    //--------------------------------------------------
    // Спецификация
    public interface E
    {
        void method();
        int Func();
    }
    class C : E
    {
        public int c1 { set; get; }
        public int c2 { set; get; }
        public void method() { Console.WriteLine("Спецификация"); this.c1 = c1 * c2; }
        public int Func() { Console.WriteLine("Спецификация"); return c1 + c2; }
    }
    //---------------------------------------------------
    // Специализация
    public class F
    {
        protected int f;
        public F()
        {
            f = 100;
        }
        public virtual int m_f()
        {
            Console.WriteLine("class F m_f(): {0}", this.f + 1);
            return this.f;
        }
    }
    public class K : F
    {
        public int k { set; get; }
        public override int m_f()
        {
            Console.WriteLine("class K : F m_f()");
            return base.m_f() + 1;
        }
    }
    //--------------------------------------------------
    // Конструирование
    public interface Y
    {
        void print();
    }
    public interface X
    {
        int check();
    }
    public class H : A, X, Y
    {
        public void print()
        {
            Console.WriteLine("Спецификация");
        }
        
        public int check()
        {
            return 0;
        }
        public override int f()
        {
            Console.WriteLine("Специализация");
            return base.f() + 1000;
        }
        public int f2()
        {
            Console.WriteLine("Расширение по функции");
            return base.f() + 10;
        }
        protected int h = 1;
        public void m_h()
        {
            Console.WriteLine("Расширение по полю: {0}", h);
        }
    }
    public abstract class L
    {
        public abstract void F2();
        private int l;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Расширение: ");
            A a = new A();
            a.a = 10;
            Console.WriteLine(a.a);
            B b = new B(11);
            b.f_b();
            J j = new J();
            int jj = j.f1();
            Console.WriteLine(jj);

            Console.WriteLine("//---------------------------------------------");

            Console.WriteLine("Спецификация: ");
            C c = new C();
            c.c1 = 10;
            c.c2 = 4;
            c.method();
            Console.WriteLine("{0}", c.c1);
            int cc = c.Func();
            Console.WriteLine(cc);

            Console.WriteLine("//---------------------------------------------");

            Console.WriteLine("Специализация: ");
            F f = new F();
            f.m_f();

            Console.WriteLine("//---------------------------------------------");
            Console.WriteLine("//---------------------------------------------");

            Console.WriteLine("Конструирование");

            H h = new H();
            h.print();
            Console.WriteLine(h.check());
            Console.WriteLine(h.f());
            Console.WriteLine(h.f2());
            h.m_h();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            E I_A = null;
            I_A = new C();
            I_A.method();
        }
    }
}
