using System;

namespace lab_2._1_OOP
{
    class A
    {
        B b = null;
        C c = null;
        J j = null;
        //public A(B b, C c, J j)
        //{
        //    this.b = b;
        //    this.c = c;
        //    this.j = j;
        //}
        public A()
        {
            b = new B();
            c = new C();
            j = new J();
        }
        public B objb { get { return b; } }
        public C objc { get { return c; } }
        public J objj { get { return j; } }
        public void m_a()
        {
            Console.WriteLine("Method A, object hash = {0}", this.GetHashCode());
        }
    }
    class B
    {
        D d = null;
        public B(D d)
        {
            this.d = d;
        }
        public B()
        {
            d = new D();
        }
        public D objd { get { return d; } }
        public void m_b()
        {
            Console.WriteLine("Method B, object hash = {0}", this.GetHashCode());
        }
    }
    class C
    {
        E e = null;
        F f = null;
        K k = null;
        public C(E e, F f, K k)
        {
            this.e = e;
            this.f = f;
            this.k = k;
        }
        public C()
        {
            e = new E();
            f = new F();
            k = new K();
        }
        public E obje { get { return e; } }
        public F objf { get { return f; } }
        public K objk { get { return k; } }
        public void m_c()
        {
            Console.WriteLine("Method C, object hash = {0}", this.GetHashCode());
        }
    }
    class J
    {
        int j = 0;
        public int ij { get { return j; } }
        public J() { }
        public J(int j)
        {
            this.j = j;
        }
        public void m_j()
        {
            Console.WriteLine("Method J, object hash = {0}", this.GetHashCode());
        }
    }
    class D
    {
        int d = 0;
        public int id { get { return d; } }
        public D() { }
        public D(int d)
        {
            this.d = d;
        }
        public void m_d()
        {
            Console.WriteLine("Method D, object hash = {0}", this.GetHashCode());
        }
    }
    class E
    {
        int e = 0;
        public int ie { get { return e; } }
        public E() { }
        public E(int e)
        {
            this.e = e;
        }
        public void m_e()
        {
            Console.WriteLine("Method E, object hash = {0}", this.GetHashCode());

        }
    }
    class F
    {
        int f = 0;
        public int fi { get { return f; } }
        public F() { }
        public F(int f)
        {
            this.f = f;
        }
        public void m_f()
        {
            Console.WriteLine("Method F, object hash = {0}", this.GetHashCode());
        }
    }
    class K
    {
        int k = 0;
        public int ik { get { return k; } }
        public K() { }
        public K(int k)
        {
            this.k = k;
        }
        public void m_k()
        {
            Console.WriteLine("Method K, object hash = {0}", this.GetHashCode());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            D objd = new D(1);
            objd.m_d();
            E obje = new E(2);
            obje.m_e();
            F objf = new F(3);
            objf.m_f();
            K objk = new K(4);
            objk.m_k();
            J objj = new J(5);
            objj.m_j();
            Console.WriteLine("//------------------------");
            //-------------------------------------------------
            B objb = new B(objd);
            objb.m_b();
            objb.objd.m_d();
            Console.WriteLine("//------------------------");
            //-------------------------------------------------
            C objc = new C(obje, objf, objk);
            objc.m_c();
            objc.obje.m_e();
            objc.objf.m_f();
            objc.objk.m_k();
            Console.WriteLine("//------------------------");
            //-------------------------------------------------
            //A obja = new A(objb, objc, objj);
            A obja = new A();
            B objbb = obja.objb;
            obja = null;

            obja.m_a();
            obja.objb.m_b();
            obja.objb.objd.m_d();

            K objkk = new K(14);
            C objcc = new C(obje, objf, objkk);
            objkk = null;
            objcc.m_c();

        }
    }
}
