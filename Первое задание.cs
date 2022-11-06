using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
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
                Console.WriteLine(ex.Message);
            }
            
        }
    }
     public class Calculator: ICalculator
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
}
