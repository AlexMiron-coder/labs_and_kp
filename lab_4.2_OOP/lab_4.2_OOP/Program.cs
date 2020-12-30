using System;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;

namespace lab_4._2_OOP
{
    interface A
    {
        void print();
        void check();
    }
    public abstract class B : A
    {
        public abstract void f_b();
        public void print() { }
        public void check() { }

    }
    public class C : A
    {
        //protected int c;
        public int c { set; get; }
        public C()
        {
            c = 13;
        }
        
        public virtual void f_C()
        {
            Console.WriteLine("f_C: {0}", c * c);
        }
        public void print() { Console.WriteLine("Interface return: {0}", c); }
        public void check() 
        { 
            if (c > 0) 
            {
                Console.WriteLine("c > 0, c = {0}", c);
            } 
            else 
            {
                Console.WriteLine("c <= 0");
            } 
        }
    }
    public class J : A
    {
        public int j { set; get; }
        public J(int j) { this.j = j; }
        public void f_J()
        {
            Console.WriteLine("f_J: {0}", j);
        }
        public void print() { Console.WriteLine("Interface return: {0}", j); }
        public void check() { 
            if (j > 0) 
            { 
                Console.WriteLine("j > 0, j = {0}", j); 
            }
            else 
            {
                Console.WriteLine("j <= 0");
            } 
        }
    }
    class D : B
    {
        public int d { set; get; }
        public override void f_b()
        {
            Console.WriteLine("class f_b: {0}", d);
        }

    }
    class E : C
    {
        public int e { set; get; }
        public E() { e = 10; }
        public E(int e) { this.e = e; }
        public override void f_C()
        {
            Console.WriteLine("f_C in E: {0}", e * e);
            base.f_C();
        }
    }
    class F : C
    {
        public int f { set; get; }
        public F() { f = 11; }
        public F(int f) { this.f = f; }
        public override void f_C()
        {
            Console.WriteLine("f_c in F: {0}", f * f);
            base.f_C();
        }
    }
    class K : C
    {
        public int k { set; get; }
        public K() { k = 12; }
        public K(int k) { this.k = k; }
        public override void f_C()
        {
            Console.WriteLine("f_C in K: {0}", k * k);
            base.f_C();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            F f = new F(11);
            K k = new K();

            C c = new C();
            c.c = -15;

            J j = new J(16);


            f.f_C();
            k.f_C();
            c.f_C();
            j.f_J();

            c.check();
            c.print();
            j.check();
        }
    }
}
