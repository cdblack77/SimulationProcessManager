using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationProcessManager
{
    public class Point2d
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point2d(float xPoint, float yPoint)
        {
            X = xPoint;
            Y = yPoint;
        }

        public Point2d()
        {
           
        }

    }
}
