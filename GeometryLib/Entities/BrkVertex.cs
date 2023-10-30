using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.Entities
{
    public class BrkVertex
    {
        public BrkVertex()
        {

        }

        public BrkVertex(double x, double y)
        {
            _X = x;
            _Y = y;

        }

        private double _X;
        private double _Y;

        public double X { get => _X; set => _X = value; }
        public double Y { get => _Y; set => _Y = value; }

        public double GetDistanceTo(BrkVertex brkVertex)
        {
            double dx = brkVertex.X - this.X;
            double dy = brkVertex.Y - this.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
