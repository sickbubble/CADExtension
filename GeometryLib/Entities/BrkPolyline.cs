using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLib.Entities
{
    public class BrkPolyline : ICollection<BrkVertex>
    {

        #region Ctor
        public BrkPolyline()
        {
            _Vertexes = new BrkVertex[4]; // Initial capacity
            _Count = 0;
        }
        #endregion

        #region Private Fields

        private BrkVertex[] _Vertexes;
        private int _Count;

        #endregion

        #region ICollection Implementation

        public BrkVertex this[int index]
        {
            get { return _Vertexes[index]; }
            set { _Vertexes[index] = value; }
        }

        public void Add(BrkVertex item)
        {
            if (_Count == _Vertexes.Length)
            {
                Array.Resize(ref _Vertexes, _Vertexes.Length +1 ); // Resize array if needed
            }

            _Vertexes[_Count++] = item;
        }

        public void Clear()
        {
            Array.Clear(_Vertexes, 0, _Count);
            _Count = 0;
        }

        public bool Contains(BrkVertex item)
        {
            return Array.IndexOf(_Vertexes, item, 0, _Count) >= 0;
        }

        public void CopyTo(BrkVertex[] array, int arrayIndex)
        {
            Array.Copy(_Vertexes, 0, array, arrayIndex, _Count);
        }

        public bool Remove(BrkVertex item)
        {
            int index = Array.IndexOf(_Vertexes, item, 0, _Count);

            if (index >= 0)
            {
                Array.Copy(_Vertexes, index + 1, _Vertexes, index, _Count - index - 1);
                _Vertexes[--_Count] = default(BrkVertex); // Clear the last element
                return true;
            }

            return false;
        }

        #region Public Properties

        public int Count
        {
            get { return _Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion


        #endregion

        #region IEnumerable Implementation


        public IEnumerator<BrkVertex> GetEnumerator()
        {
            for (int i = 0; i < _Count; i++)
            {
                yield return _Vertexes[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Stack Implementation

        public BrkVertex Pop()
        {
            if (_Count == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            BrkVertex item = _Vertexes[--_Count];
            _Vertexes[_Count] = default(BrkVertex); // Clear the last element
            return item;
        }

        public void Push(BrkVertex item)
        {
            Add(item);
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= _Count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            Array.Copy(_Vertexes, index + 1, _Vertexes, index, _Count - index - 1);
            _Vertexes[--_Count] = default(BrkVertex); // Clear the last element
        }

        public void Insert(int index, BrkVertex item)
        {
            if (index < 0 || index > _Count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            if (_Count == _Vertexes.Length)
            {
                Array.Resize(ref _Vertexes, _Vertexes.Length +1); // Resize array if needed
            }

            Array.Copy(_Vertexes, index, _Vertexes, index + 1, _Count - index);
            _Vertexes[index] = item;
            _Count++;
        }

        public BrkVertex[] ToArray()
        {
            BrkVertex[] newArray = new BrkVertex[_Count];
            Array.Copy(_Vertexes, newArray, _Count);
            return newArray;
        }

        public List<BrkVertex> ToList()
        {
            return new List<BrkVertex>(_Vertexes);
        }

        #endregion

        #region Polyline Operations

        public void Reverse()
        {
            int i = 0;
            int j = _Count - 1;
            while (i < j)
            {
                BrkVertex temp = _Vertexes[i];
                _Vertexes[i] = _Vertexes[j];
                _Vertexes[j] = temp;
                i++;
                j--;
            }
        }

        public bool IsIntersection(BrkPolyline pl2, out int firstIntersectIndex, out int secondIntersectIndex)
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                for (int j = 0; j < pl2.Count - 1; j++)
                {
                    var p1 = this[i];
                    var p2 = this[i + 1];
                    var p3 = pl2[j];
                    var p4 = pl2[j + 1];

                    var intersectVtx = GeometryOps.SegmentsIntersect(p1, p2, p3, p4);

                    if (intersectVtx != null)
                    {
                        firstIntersectIndex = i;
                        secondIntersectIndex = j;
                        return true;
                    };
                }
            }
            firstIntersectIndex = -1;
            secondIntersectIndex = -1;
            return false;
        }

        /// <summary>
        /// returns intersection points and their index on polyline
        /// </summary>
        /// <param name="pl2"></param>
        /// <param name="firstIntersectIndex"></param>
        /// <param name="secondIntersectIndex"></param>
        /// <returns></returns>
        public List<Tuple<BrkVertex, int, int>> IntersectionPoints(BrkPolyline pl2)
        {
            var ret = new List<Tuple<BrkVertex, int, int>>();

            for (int i = 0; i < this.Count - 1; i++)
            {
                for (int j = 0; j < pl2.Count - 1; j++)
                {
                    var p1 = this[i];
                    var p2 = this[i + 1];
                    var p3 = pl2[j];
                    var p4 = pl2[j + 1];


                    var intersectVtx = GeometryOps.SegmentsIntersect(p1, p2, p3, p4);

                    if (intersectVtx != null)
                    {
                        ret.Add(new Tuple<BrkVertex, int, int>(new BrkVertex(intersectVtx.X, intersectVtx.Y), i+1, j+1));
                    }
                }
            }
            return ret;

        }




        #endregion

        #region Convert Methods

        public static BrkPolyline FromACPolyline(Polyline polyLine)
        {
            var ret = new BrkPolyline();
            for (int i = 0; i < polyLine.NumberOfVertices; i++)
            {
                var pt = polyLine.GetPoint2dAt(i);
                if (pt !=null)
                {
                ret.Add(new BrkVertex(pt.X, pt.Y));
                }

            }

            return ret;
        }

        #endregion



    }
}
