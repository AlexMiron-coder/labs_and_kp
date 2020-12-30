using System;
using System.Net.Http;

namespace lab_6._2_OOP
{
    class B
    {
        private int N = 0;
        private int dSIZE = 0;
        private D[] dArray = null;
        public B(int N) { this.N = N; dArray = new D[N]; }
        public void f() { Console.WriteLine("Hashcode: {0}", this.GetHashCode()); }
        public void setD(D d)
        {
            if(dSIZE < N)
            {
                this.dArray[dSIZE] = d;
                dSIZE++;
            }
        }
        public D getD(int i)
        {
            if ((i < dSIZE) && (i >= 0)) 
            {
                return dArray[i];
            }
            return null;
        }

    }
    class C
    {
        
        private int N = 0;
        public C(int N) { this.N = N; kArray = new K[N]; fArray = new F[N]; eArray = new E[N]; }
        public void f() { Console.WriteLine("Hashcode: {0}", this.GetHashCode()); }

        // K[]
        private int kSIZE = 0;
        private K[] kArray = null;
        public void setK(K k)
        {
            if (kSIZE < N) 
            {
                this.kArray[kSIZE] = k;
                kSIZE++;
            }
        }
        public K getK(int i)
        {
            if ((i < kSIZE) && (i >= 0)) 
            {
                return kArray[i];
            }
            return null;
        }

        // F[]
        private int fSIZE = 0;
        private F[] fArray = null;
        public void setF(F f)
        {
            if (fSIZE < N) 
            {
                this.fArray[fSIZE] = f;
                fSIZE++;
            }
        }
        public F getF(int i)
        {
            if ((i < fSIZE) && (i >= 0)) 
            {
                return fArray[i];
            }
            return null;
        }

        // E[]
        private int eSIZE = 0;
        private E[] eArray = null;
        public void setE(E e)
        {
            if (eSIZE < N) 
            {
                this.eArray[eSIZE] = e;
                eSIZE++;
            }
        }
        public E getE(int i)
        {
            if ((i < eSIZE) && (i >= 0)) 
            {
                return eArray[i];
            }
            return null;
        }
    }
    class D
    {
        public D() { }
        public D(B b)
        {
            b.setD(this);
        }
        public void f() { Console.WriteLine("Hashcode: {0}", this.GetHashCode()); }
        public B b;
    }
    class E
    {
        public E() { }
        public E(C c)
        {
            c.setE(this);
        }
        public void f() { Console.WriteLine("Hashode: {0}", this.GetHashCode()); }
        public C c { get; set; }
    }
    class F
    {
        public F() { }
        public F(C c)
        {
            c.setF(this);
        }
        public void f() { Console.WriteLine("Hashcode: {0}", this.GetHashCode()); }
        public C c { get; set; }
    }
    class K
    {
        public K() { }
        public K(C c)
        {
            c.setK(this);
        }
        public void f() { Console.WriteLine("Hashcode: {0}", this.GetHashCode()); }
        public C c { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            C c = new C(3);

            K k0 = new K();
            K k1 = new K();
            K k2 = new K();
            
            // k0
            c.setK(k0);
            k0.c = c;

            //k1
            c.setK(k1);
            k1.c = c;
            
            //k2
            c.setK(k2);
            k2.c = c;

            E e0 = new E();
            E e1 = new E();
            E e2 = new E();

            // e0
            c.setE(e0);
            e0.c = c;

            // e1
            c.setE(e1);
            e1.c = c;

            // e2
            c.setE(e2);
            e2.c = c;

            F f0 = new F();
            F f1 = new F();
            F f2 = new F();

            // f1
            c.setF(f0);
            f0.c = c;

            // f1
            c.setF(f1);
            f1.c = c;

            // f2
            c.setF(f2);
            f2.c = c;

            // set
            f1.c.f();
            e1.c.getF(0).f();
            k1.c.getE(0).c.getF(2).f();
            f2.f();
          
        }
    }
}
