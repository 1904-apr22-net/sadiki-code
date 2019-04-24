using System;

//dotnet new classlib -name. Animals.Library
namespace Animals.Library
{  // (mv Animals.Library/Class1.cs Animals.Library/Dog.cs)
    public class Dog
    {
        public string Breed { get; set; }
        public string Name { get; set; }
        public void Bark()
        {
            Console.WriteLine("Bark");
        }
    }
}
