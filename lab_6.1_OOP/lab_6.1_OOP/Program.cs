using System;
using System.Security.Cryptography;

namespace lab_6._1_OOP
{
    class A
    {
        public A() { }
        public A(B b, C c, J j)
        {
            this.b = b;
            this.c = c;
            this.j = j;
        }
        public void Function()
        {
            Console.WriteLine("class A function hash: {0} ", this.GetHashCode());
        }
        public B ib;
        public C ic;
        public J ij;
        public B b { get { return ib; } set { ib = value; } }
        public C c { get { return ic; } set { ic = value; } }
        public J j { get { return ij; } set { ij = value; } }
    }
    class B
    {
        public B() { }
        public B(D d)
        {
            this.d = d;
        }
        public void Function()
        {
            Console.WriteLine("class B function hash: {0} ", this.GetHashCode());
        }
        A ia;
        public D id;
        public A a { get { return ia; } set { ia = value; } }
        public D d { get { return id; } set { id = value; } }
    }
    class C
    {
        public C() { }
        public C(E e, F f, K k)
        {
            this.e = e;
            this.f = f;
            this.k = k;
        }
        public C c { get; set; }
        public void Function()
        {
            Console.WriteLine("class C function hash: {0}", this.GetHashCode());
        }
        public E ie;
        public F fi;
        public K ik;
        public A ia;
        public E e { get { return ie; } set { ie = value; } }
        public F f { get { return fi; } set { fi = value; } }
        public K k { get { return ik; } set { ik = value; } }
        public A a { get { return ia; } set { ia = value; } }
    }
    class J
    {
        public J() { }
        public void Function()
        {
            Console.WriteLine("class J function hash: {0}", this.GetHashCode());
        }
        public A ia;
        public A a { get { return ia; } set { ia = value; } }
    }
    class D
    {
        public D() { }
        public void Function()
        {
            Console.WriteLine("class D function hash: {0}", this.GetHashCode());
        }
        public B ib;
        public B b { get { return ib; } set { ib = value; } }
    }
    class E
    {
        public E e { set; get; }
        public E() { }
        public E(E e) { this.e = e; }
        public C ic;
        public C c { get { return ic; } set { ic = value; } }
    }
    class F
    {
        public F() { }
        public void Functon()
        {
            Console.WriteLine("class F fucntion hash: {0}", this.GetHashCode());
        }
        public C ic;
        public C c { get { return ic; } set { ic = value; } }
    }
    class K
    {
        public K() { }
        public void Function()
        {
            Console.WriteLine("class K fuction hash: {0}", this.GetHashCode());
        }
        public C ic;
        public C c { get { return ic; } set { ic = value; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            E obje = new E();
            F objf = new F();
            K objk = new K();
            D objd = new D();

            B objb = new B(objd);
            C objc = new C(obje, objf, objk);
            J objj = new J();

            A obja = new A(objb, objc, objj);

            objb.a = obja;
            objf.c = objc;
            objc.a = obja;
            objj.a = obja;
            obje.c = objc;

            obja.Function();
            objb.a.Function();
            objf.c.a.Function();
            obje.c.f.c.a.Function();
            objj.a.Function();
        }
    }
}
