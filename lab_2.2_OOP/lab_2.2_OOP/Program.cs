using System;

namespace lab_2._2_OOP
{
    class A
    {
        public B b;
        private C c;
        private J j;
        public A()
        {
            b = new B();
            c = new C();
            j = new J();
        }
        public void m_a()
        {
            Console.WriteLine("Method A ");
        }
        public class B
        {
            private D d;
            public B()
            {
                d = new D();
            }
            public void m_b()
            {
                Console.WriteLine("Method B, a->b ");
            }
            public class D
            {
                private int d;
                public D()
                {
                    d = 3;
                }
                public void m_d()
                {
                    Console.WriteLine("Method D, a->b->d = {0}", d);
                }
            }
        }
        public class C
        {
            private E e;
            private F f;
            private K k;
            public C()
            {
                e = new E();
                f = new F();
                k = new K();
            }
            public void m_c()
            {
                Console.WriteLine("Method C, a->c ");
            }
            public class E
            {
                private int e;
                public E()
                {
                    e = 3;
                }
                public void m_e()
                {
                    Console.WriteLine("Method E, a->c->e = {0}", e);
                }
            }
            public class F
            {
                private int f;
                public F()
                {
                    f = 3;
                }
                public void m_f()
                {
                    Console.WriteLine("Method F, a->c->f = {0}", f);
                }
            }
            public class K
            {
                private int k;
                public K()
                {
                    k = 3;
                }
                public void m_k()
                {
                    Console.WriteLine("Method K, a->c->k = {0}", k);
                }
            }
        }
        public class J
        {
            private int j;
            public J()
            {
                j = 3;
            }
            public void m_j()
            {
                Console.WriteLine("Method J, a->j = {0}", j);
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            A.B b = new A.B();
            A.J j = new A.J();
            A.B.D d = new A.B.D();
            A.C.E e = new A.C.E();
            A.C.F f = new A.C.F();
            A.C.K k = new A.C.K();
            A.C c = new A.C();
            A.B bb = new A.B();

            a.m_a();
            Console.WriteLine("-----------------------------------------------");
            b.m_b();
            d.m_d();
            Console.WriteLine("-----------------------------------------------");
            c.m_c();
            e.m_e();
            f.m_f();
            k.m_k();
            Console.WriteLine("-----------------------------------------------");
            j.m_j();
            
        }
    }
}
