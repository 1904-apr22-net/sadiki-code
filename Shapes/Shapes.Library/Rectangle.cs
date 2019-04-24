using Shapes.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    public class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public double GetPerimeter() => 2 * Length + 2 * Width;
        public double Area => Length * Width;

        public int Sides => 4;
   
    }
}
