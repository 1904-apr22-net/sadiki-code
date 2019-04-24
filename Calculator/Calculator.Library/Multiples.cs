using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Library
{
    public class Multiples
    {
        public void ThreeMultiple(int limit)
        {if (limit < 0)
            {
                Console.WriteLine("Limit must be nonnegative");
            }
            else
            {
                Console.WriteLine("\n");
                int counter = (limit - (limit % 3));
                while (0 < counter)
                {
                    Console.WriteLine(counter);
                    counter -= 3;
                }
            }
            
        }
    }
}
