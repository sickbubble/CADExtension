using GeometryLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib
{
    public static class GeometryOps
    {
        public static BrkVertex SegmentsIntersect(BrkVertex p1, BrkVertex p2, BrkVertex p3, BrkVertex p4)
        {
            BrkVertex ret = null;

            double A1 = p2.X - p1.X;
            double B1 = p4.X - p3.X;
            double C1 = p1.X - p3.X;

            double A2 = p2.Y - p1.Y;
            double B2 = p4.Y - p3.Y;
            double C2 = p1.Y - p3.Y;

            double det = A1 * C2 - A2 * C1;


            if (Math.Abs(det) > 0)
            {
                det = (B2 * B1 - C1 * C2) / det;
                var intX = p1.X + det * A1;
                var intY = p1.Y + det * A2;
                ret = new BrkVertex(intX, intY);
                //if (!(IsPointOnSegment(p1, p2, ret) && IsPointOnSegment(p3, p4, ret)))
                //    ret = null;
            }
            else // Lines are parallel
            {
                if ((A1 * -B2) == (-C1 * A2))
                {
                    ret = new BrkVertex(p3.X, p3.Y);
                }
                else
                {
                    ret = new BrkVertex(p4.X, p4.Y);
                }
            }


            return ret;
        }

        private static bool IsPointOnSegment(BrkVertex p1, BrkVertex p2, BrkVertex checkPoint)
        {
            return (checkPoint.X >= Math.Min(p1.X, p2.X) && checkPoint.X <= Math.Max(p1.X, p2.X) &&
                                 checkPoint.Y >= Math.Min(p1.Y, p2.Y) && checkPoint.Y <= Math.Max(p1.Y, p2.Y));

        }


        public static List<BrkVertex> IntersectionPoints(BrkPolyline pl1, BrkPolyline pl2)
        {
            List<BrkVertex> intersectionPoints = new List<BrkVertex>();

            for (int i = 0; i < pl1.Count - 1; i++)
            {
                for (int j = 0; j < pl2.Count - 1; j++)
                {
                    var p1 = pl1[i];
                    var p2 = pl1[i + 1];
                    var p3 = pl2[j];
                    var p4 = pl2[j + 1];

                    var intersectVtx = GeometryOps.SegmentsIntersect(p1, p2, p3, p4);

                    if (intersectVtx != null) intersectionPoints.Add(intersectVtx);
                }
            }

            return intersectionPoints;
        }

    }
}
