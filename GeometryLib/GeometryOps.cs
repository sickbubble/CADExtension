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
        /// <summary>
        /// formulation is taken from wikipedia
        /// https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection#Given_two_points_on_each_line
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <returns></returns>
        public static BrkVertex SegmentsIntersect(BrkVertex p1, BrkVertex p2, BrkVertex p3, BrkVertex p4)
        {
            BrkVertex ret = null;


            var xNum = (p1.X * p2.Y - p1.Y * p2.X) * (p3.X - p4.X) - (p1.X - p2.X) * (p3.X * p4.Y - p3.Y * p4.X);
            var yNum = (p1.X * p2.Y - p1.Y * p2.X) * (p3.Y - p4.Y) - (p1.Y - p2.Y) * (p3.X * p4.Y - p3.Y * p4.X);
            var denom = (p1.X - p2.X) * (p3.Y - p4.Y) - (p1.Y - p2.Y) * (p3.X - p4.X);

            if (denom != 0)
            {
                ret = new BrkVertex(xNum / denom, yNum/ denom);
                bool isOnBothSegment = IsPointOnSegment(p1, p2, ret) && IsPointOnSegment(p3, p4, ret);
                if (!isOnBothSegment) ret = null;
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
