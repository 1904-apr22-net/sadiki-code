using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Library.Interfaces
{
    public interface IShape
    {
        double GetPerimeter();

        double Area { get; }

        int Sides { get;  }
    }
}
