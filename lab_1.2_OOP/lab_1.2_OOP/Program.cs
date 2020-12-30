using System;


     //      A 
     //   /  |  \
     //  B   C   J
     // /   /|\
     //D---E F K

namespace lab_1._2_OOP
{

    class A
    {
        B objB = null;
        public B b
        {
            get { return objB; } //read
            
        }
        C objC = null;
        public C c
        {
            get { return objC; }
            
        }
        J objJ = null;
        public J j
        {
            get { return objJ; }
           
        }
        public A(B b, C c, J j)
        {
            objB = b;
            objC = c;
            objJ = j; 
        }
        public void methA()
        {
            Console.WriteLine("Method A, hash = {0}", this.GetHashCode());
        }

    }
    class B
    {
        D objD = null;
        public B(D d)
        {
            objD = d;
        }
        public D d { get { return objD; } }
        public void methB()
        {
            Console.WriteLine("Method B, hash = {0}", this.GetHashCode());
        }
    }
    class C
    {
        E objE = null;
        F objF = null;
        K objK = null;
        public C(E e, F f, K k)
        {
            objE = e;
            objF = f;
            objK = k;
        }
        public E e { get { return objE; } }
        public F f { get { return objF; } }
        public K k { get { return objK; } }
        public void methC()
        {
            Console.WriteLine("Method C, hash = {0}", this.GetHashCode());
        }
    }
    class J
    {
        public int vJ;
        public J(int val) { vJ = val; }
        public J() { }
        public void methJ()
        {
            Console.WriteLine("Method J, hash = {0}", this.GetHashCode());
        }
    }
    class D
    {
        public int vD;
        public D(int val) { vD = val; }
        public D() { }
        public void methD()
        {
            Console.WriteLine("Method D, hash = {0}", this.GetHashCode());
        }
    }
    class E
    {
        public int vE;
        public E(int val) { vE = val; }
        public E() { }
        public void methE()
        {
            Console.WriteLine("Method E, hash = {0}", this.GetHashCode());
        }
    }
    class F
    {
        public int vF;
        public F(int val) { vF = val; }
        public F() { }
        public void methF()
        {
            Console.WriteLine("Method F, hash = {0}", this.GetHashCode());
        }
    }
    class K
    {
        public int vK;
        public K(int val) { vK = val; }
        public K() { }
        public void methK()
        {
            Console.WriteLine("Method K, hash = {0}", this.GetHashCode());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            K objK = new K();
            D objD = new D();
            E objE = new E();
            F objF = new F();
            //----------------------------------------------
            J objJ = new J();
            //----------------------------------------------
            B objB = new B(objD);
            C objC = new C(objE, objF, objK);
            //----------------------------------------------
            A objA = new A(objB, objC, objJ);
            //----------------------------------------------
            objA.methA();

            B b = objA.b;
            C c = objA.c;
            J j = objA.j;

            objB.methB();
            b.methB();
            //----------------------------------------------
            D d = b.d;
            objD.methD();
            d.methD();
            //----------------------------------------------
            objA.c.e.methE();
            objE.methE();
            //----------------------------------------------
            objC.methC();
            objA.c.methC();
            //----------------------------------------------
            objF.methF();
            objA.c.f.methF();
            //----------------------------------------------
            objJ.methJ();
            objA.j.methJ();
        }
    }
}
