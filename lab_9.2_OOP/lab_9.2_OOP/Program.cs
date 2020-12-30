using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_9._2_OOP
{
    class Program
    {
        // Lx.Ly => x + y delegate + lambda
        delegate int Lambda(int x, int y);

        delegate void Ld();
        public static bool Check(int x) { return x % 2 != 0; }
        delegate bool OddPredicate(int x);
        static void Main(string[] args)
        {
            // 1. Lambda
            List<int> list = new List<int>() { 4, 2, 3, 4, 5, 6, 7, 2020 };
            int index = list.FindIndex(Check);
            Console.WriteLine(list[index]);

            int i = list.FindIndex(x => x % 2 != 0);
            Console.WriteLine(list[i]);

            // 2. delegate + lambda
            Lambda l1 = (x, y) => x + y;
            Lambda l2 = delegate (int x, int y)
            {
                return x + y;
            };

            Console.WriteLine("lambda1 = {0}", l1(3, 4));
            Console.WriteLine("lambda2 = {0}", l2(4, 5));
        }
    }
}
