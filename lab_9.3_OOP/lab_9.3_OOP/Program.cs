using System;

namespace lab_9._3_OOP
{
    public class Publisher
    {
        public delegate void BeforePrint();
        public event BeforePrint beforePrintEvent;
        private int num;
        public Publisher() { }
        public Publisher(int num) { this.num = num; }
        public void PrintSubcriber(int num)
        {
            if (beforePrintEvent != null) { beforePrintEvent(); }
            Console.WriteLine("Number: {0}", num);
        }
        public void changeSub(int num)
        {
            if (beforePrintEvent != null) { beforePrintEvent(); }
            Console.WriteLine("Number: {0}", num);
        }
        public void PrintMoney(int money)
        {
            if (beforePrintEvent != null) { beforePrintEvent(); }
            Console.WriteLine("Number: {0}", money);
        }
    }
    public class Subscriber_1
    {
        private Publisher publisher = null;
        private int value { set; get; }
        private int money { set; get; }
        public Subscriber_1(Publisher publisher, int value) 
        { 
            this.publisher = publisher; 
            this.value = value;
            this.money = value * 10;
            this.publisher.beforePrintEvent += Handler_beforePrintEvent1;
        }
        void Handler_beforePrintEvent1()
        {
            Console.WriteLine("Handler1 before print event: value = {0}, money = {1}", value, money);
        }
        public void PrintMoney() { publisher.PrintMoney(money); }
        public void changeSubs() { publisher.changeSub(value); }
    }
    public class Subscriber_2
    {
        private Publisher publisher = null;
        private int value { set; get; }
        private int money { set; get; }
        public Subscriber_2(Publisher publisher, int value)
        {
            this.publisher = publisher;
            this.value = value;
            this.money = value * 10;
            this.publisher.beforePrintEvent += Handler_beforePrintEvent2;
        }
        void Handler_beforePrintEvent2()
        {
            Console.WriteLine("Handler2 before print event: value = {0}, money = {1}", value, money);
        }
        public void PrintMoney() { publisher.PrintMoney(money); }
        public void changeSubs() { publisher.changeSub(value); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber_1 sub1_1 = new Subscriber_1(publisher, 1000);
            Subscriber_2 sub2_1 = new Subscriber_2(publisher, 10);

            sub1_1.PrintMoney();
            sub2_1.changeSubs();
        }
    }
}
