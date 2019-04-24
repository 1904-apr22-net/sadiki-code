using Shapes.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{// backing field
    public class CircleAdv : IShape
    {
        protected double _radius;
        public virtual double Radius
            //virtual: subclasses can override this
        {
            get
            {
                return _radius * 1.01;
            }
            set
            {
                if (value < 0)
                { Console.WriteLine("Err: Radius cannot be negative"); }
                else { _radius = value; };
            }
        }
        public virtual double GetPerimeter() => 2 * Math.PI * Radius;
        public virtual double Area => Radius * Math.PI * Radius;
        public virtual int Sides => 1;
    }
}

