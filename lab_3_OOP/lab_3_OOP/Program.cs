using System;

namespace lab_3_OOP
{
    class F
    {
        protected int f = 0;
        public F() { }
        public F(int f) { this.f = f; }
        public F(F objf) { f = objf.f; }
        public virtual int F1()
        {
            return f;
        }
        public int get_f { get { return f; } }

    }
    class D : F
    {
        int d;
        public D() { this.d = 148369; }
        public D(int d) { this.f = d; }
        public D(D objd) { f = objd.f; }
        public override int F1()
        {
            return base.F1();
        }
        public int get_d { get { return f; } }
        public int get
        {
            get { return d; }
        }
    }
    class G : D
    {
        int g;
        public G(int g) { this.g = g; }
        public G(int g, int d) : base(d) { this.g = g; Console.WriteLine("hash: {0}", this.GetHashCode()); }
        public override int F1()
        {
            return base.F1();
        }
    }

    public class First
    {
        protected int a = 0;
        public virtual void F()
        {
            Console.WriteLine("{0}", a);
        }
    }
    public class Second : First
    {
        public sealed override void F()
        {
            base.F();
        }
    }
    public class Third : Second
    {
        public override void F() //Уже нельзя override, так как запечатан
        {
            base.F();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F f = new F();
            F f1 = new F(1);
            Console.WriteLine("first fucntion working: {0} {1}", f.F1(), f1.F1());

            f = new D(5);
            f1 = new G(2, 3);

            Console.WriteLine("after base-function working: {0}, {1}", f.F1(), f1.F1());

            D d = new D();
            f1 = new G(10, 14);

            Console.WriteLine("after second work: {0}, {1}", f1.F1(), d.get);



        }
    }
}
