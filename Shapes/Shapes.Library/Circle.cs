using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{   //field. encapsulation safe.
    public class Circle
    {
        private double radius;

        public double GetRadius()
        {
            return radius;
        }
        public void SetRadius(double radius)
        {
            if (radius < 0)
            {
                Console.WriteLine("Err: Radius cannot be negative");
            }
            else
            {
                this.radius = radius;
            }
        }
    }
}
