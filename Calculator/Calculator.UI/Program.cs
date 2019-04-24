using Calculator.Library;
using System;

namespace Calculator.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an upper limit:\n");
            int limit = int.Parse(Console.ReadLine());
            Multiples calc = new Multiples();
            calc.ThreeMultiple(limit);
        }
    }
}
