using System;

namespace lab_7._1_OOP
{
    class Server
    {
        public Server() { }
        public int f() { return 0; }
    }
    class Utility
    {
        public static int f() { return 1; }
    }
    class Client
    {
        public Client() { }
        public void m(Server s) { Console.WriteLine("Class Server client f(): {0}", s.f()); }
        public void utility() { Console.WriteLine("Class Utility f(): {0}", Utility.f()); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server();
            Client cl = new Client();

            cl.m(s);
            cl.utility();
            Utility.f();
        }
    }
}
