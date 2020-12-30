using System;
using System.Runtime.InteropServices;

/*
 * 1 .Изучите категорию конкретизация. Какие разновидности этой категории есть. Вершины графа, соединенные горизонтальной связью, 
 * определите на графе в виде категории использование, для этого поставьте соответствующие стрелки. Для каждого вида категории составьте свой граф.
 * 2. Реализуйте категорию конкретизация функции в одельном проекте. Функция позволяет перемещаться по графу A-B-C, 
 * представленному категорией агрегация по ссылке и наследованием. Реализуемая функция должна двигаться по любому отрезку иерархии и реализуется в цикле.
 * 3. Реализуйте категорию конкретизация класса в одельном проекте.
 * 4. Сравните полученные варианты. Напишите какими свойствами обладает категория конкретизация? В каком случае ее целесообразно использовать?
 * 5. Оформите работу. Проектам должны соответствовать графы. Напишите ответы на вопросы. Сохраните результаты лабораторной.
 */


namespace lab_8._1_OOP
{
    class A<T>
    {
        public A(T a, B<T> b) { this.a = a; this.b = b; }
        public T a { get; set; }
        private B<T> b;
        public B<T> a_b { get { return b; } set { b = value; } }
        public void mA()
        {
            Console.WriteLine("Class A<T> a hashcode: {0}", this.GetHashCode());
        }
        public void print()
        {
            Console.WriteLine("Class A<T> a: {0} {1}", a.GetType(), a.ToString());
        }
    }
    class B<T>
    {
        public B(T b, C<T> c) { this.b = b;this.c = c; }
        public T b { get; set; }
        public  C<T> b_c { get { return c; } set { c = value; } }
        private C<T> c;
        public void mB()
        {
            Console.WriteLine("Class B<T> b hashcode: {0}", this.GetHashCode());
        }
        public void print()
        {
            Console.WriteLine("Class B<T> b: {0}", b.ToString());
        }
    }
    
    class C<T>
    {
        public T c { get; set; }
        public C(T c) { this.c = c; }
        public void mC()
        {
            Console.WriteLine("Class C<T> c hashode: {0}", this.GetHashCode());
        }
        public void print()
        {
            Console.WriteLine("Class C<T> c: " + c);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            C<int> ci = new C<int>(12);
            B<int> bi = new B<int>(13, ci);
            A<int> ai = new A<int>(14, bi);

            string ptr = "hello";
            C<string> cstr = new C<string>("world!");
            B<string> bstr = new B<string>(",", cstr);
            A<string> astr = new A<string>(ptr, bstr);

            ai.mA();
            ai.print();
            bi.mB();
            bi.print();
            ci.mC();
            ci.print();

            cstr.mC();
            cstr.print();
            astr.mA();
            astr.print();

            ai.a_b.b_c.print();
        }
    }
}
