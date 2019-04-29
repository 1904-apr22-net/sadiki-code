using Assessment1.Library;
using System;

namespace Assessment1
{
    class Program
    {
        static void Main(string[] args)
        {
            PossiblePalindrome p = new PossiblePalindrome("nurses run");
            bool palindrome = p.PaliTest();
            Console.WriteLine(palindrome);
        }
    }
}
