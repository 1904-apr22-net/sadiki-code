using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library
{
    class NoisyCircle : CircleAdv
    {
        //override time

        //cannot freely override elements
        //must put 'virtual' as modifier on elements meant to be overridden

        public override double Radius { get; set; }

        public override double GetPerimeter()
        {
            Console.WriteLine("getting perimeter.");
            return base.GetPerimeter();
        }
    }
}
