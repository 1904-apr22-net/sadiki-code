using Animals.Library;
using System;

namespace Animals.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();

            dog.Name = "Barkolemew";
            dog.Breed = "Shih Tzu";
            dog.Bark();        }
    }
}
