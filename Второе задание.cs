using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Module_10
{
    internal class Program
    {
        static ILogger logger { get; set; }
        static ILogger err { get; set; }
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            Logger err = new Logger();
            var worker = new Worker(logger, err);

            try
            {
                worker.Work();
                Calculator calculator = new Calculator();
                Console.WriteLine("Введите число ");
                calculator.a = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите число ");
                calculator.b = int.Parse(Console.ReadLine());
                Calculator calculator2 = new Calculator();
                calculator2.Addition(calculator.a, calculator.b);
            }
            catch (Exception ex) 
            {
                err.Error("");
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class Calculator : ICalculator
    {
        public int a { get; set; }
        public int b { get; set; }
        public void Addition(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }
    public interface ICalculator
    {
        public void Addition(int a, int b);
    }
    public interface ILogger
    {
        void Error(string massage);
        void Event(string massage);
    }
    public class Logger : ILogger
    {
        public void Error(string massage)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(massage);
        }
        public void Event(string massage)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(massage);
        }
    }
    public class Worker : ILogger
    {
        Logger Err { get; }
        Logger Logger { get; }
        public Worker(Logger logger, Logger err)
        {
            Logger = logger;
            Err = err;
        }
        public void Error(string massage)
        {

        }
        public void Event(string massage)
        {

        }
        public void Work()
        {
            Logger.Event("Обработка данных");
        }
        public void Work1()
        {
            Logger.Error("");
        }
    }
}
