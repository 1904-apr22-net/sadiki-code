using Shapes.Library;
using Shapes.Library.Interfaces;
using System;

namespace Shapes.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle cir = new Circle();

           // cir.setradius(-4);
            cir.SetRadius(4);

            CircleAdv newcir = new CircleAdv();
                
            newcir.Radius = 4;
            Console.WriteLine(newcir.Radius);

            ShapeWork();
        }

        static void ShapeWork()
        {
            Rectangle r = new Rectangle();

            r.Length = 4;
            r.Width = 3;

            Console.WriteLine(r.GetPerimeter());
            Console.WriteLine(r.Area);
        }

        static void PrintShapeDetails(IShape shape)
        {
            Console.WriteLine("Area is " + shape.Area);
        }

        //Try to use props instead of fields + getters + setters
    }
}
