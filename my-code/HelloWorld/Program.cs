using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaration statement.
        int counter;

        // Assignment statement.
        counter = 1;

        // Error! This is an expression, not an expression statement.
        // counter + 1; 

        // Declaration statements with initializers are functionally
        // equivalent to  declaration statement followed by assignment statement:         
        string[] characters = { "Vieleheim", "Template", "Del Faraday", "Leberchet", "Imeo-Xan-Zafar" };

        foreach (string character in characters)
        {

            // Expression statement (method invocation). A single-line
            // statement can span multiple text lines because line breaks
            // are treated as white space, which is ignored by the compiler.
            System.Console.WriteLine("Character #{0} is {1}.",
                                    counter, character);

            // Expression statement (postfix increment).
            counter++;
        }
        }
    }
}
