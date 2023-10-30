using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
using GeometryLib.Factories;
using GeometryLib.Entities;
using System.Collections.Generic;
using InputUI;
using System.Windows.Forms;
using System.Linq;

namespace CADExtension
{
    public class CadOperation
    {
        [CommandMethod("DrawColumn")]
        public void DrawColumnCommand()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            var drawingFactory = new ColumnDrawingFactory();

            PromptPointResult result = ed.GetPoint("\nEnter base point for column: ");

            if (result.Status == PromptStatus.OK)
            {
                Transaction tr = db.TransactionManager.StartTransaction();
                using (tr)
                {
                    BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead, false);
                    BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite, false);

                    // Get User Input From GUI;
                    frmDrawColumnInput frm = new frmDrawColumnInput();
                    frm.ShowDialog();

                    var inputArgs = frm.InputArgs;
                    // Draw column using the provided parameters
                    drawingFactory.DrawColumn(btr, result.Value, inputArgs);

                    // Update Screen
                    Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();

                    tr.Commit();
                }
            }
        }


        [CommandMethod("AddIntersectionPointToPolyline")]
        public void AddIntersectionPointToPolyline()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            // Start a transaction
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                // Open the BlockTable for read
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);

                // Open the BlockTableRecord for read
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                var polyLines = new List<Polyline>();
                // Iterate through all entities in model space
                foreach (ObjectId entId in btr)
                {
                    Entity ent = (Entity)tr.GetObject(entId, OpenMode.ForWrite);

                    if (ent is Polyline) polyLines.Add((Polyline)ent);
                }

                var customPolyLines = new Dictionary<int, BrkPolyline>();


                for (int i = 0; i < polyLines.Count; i++) customPolyLines.Add(i, BrkPolyline.FromACPolyline(polyLines[i]));
                

                var polyToUpdate = new Dictionary<int,BrkPolyline>();

                var updateIndex = new Dictionary<int, int>();


                for (int i = 0; i < customPolyLines.Count; i++)
                {
                    for (int j = 1; j < customPolyLines.Count; j++)
                    {
                        if (i == j) continue;

                        var intersectionPoints = customPolyLines[i].IntersectionPoints(customPolyLines[j]);

                        if (intersectionPoints == null || intersectionPoints.Count == 0) continue;

                        intersectionPoints.OrderBy(x => -x.Item1.X);


                        foreach (var vtx in intersectionPoints)
                        {
                            var firtPolyIndex = vtx.Item2;
                            var secondPolyIndex = vtx.Item3;
                            var pt = vtx.Item1;


                            //var index = CalculateInsertionIndex(customPolyLines[i], pt);
                            //if (!polyToUpdate.ContainsKey(i))
                            //{
                            //    customPolyLines[i].Insert(index, new BrkVertex(pt.X, pt.Y));
                            //    polyToUpdate.Add(i, customPolyLines[i]);
                            //}
                            //else
                            //{
                            //    polyToUpdate[i].Insert(index, new BrkVertex(pt.X, pt.Y));
                            //}

                            //index = CalculateInsertionIndex(customPolyLines[j], pt);
                            //if (!polyToUpdate.ContainsKey(j))
                            //{
                            //    customPolyLines[j].Insert(index, new BrkVertex(pt.X, pt.Y));
                            //    polyToUpdate.Add(j, customPolyLines[j]);
                            //}
                            //else
                            //{
                            //    polyToUpdate[j].Insert(index, new BrkVertex(pt.X, pt.Y));
                            //}

                            //customPolyLines[j].Insert(secondPolyIndex, new BrkVertex(pt.X, pt.Y));
                            //if (!polyToUpdate.ContainsKey(j)) polyToUpdate.Add(j, customPolyLines[j]);



                            var pt2d = new Point2d(pt.X, pt.Y);

                            var indexindex = CalculateInsertionIndex(polyLines[i], pt2d);
                            polyLines[i].AddVertexAt(indexindex, new Point2d(pt.X, pt.Y), 0, 0, 0);

                            indexindex = CalculateInsertionIndex(polyLines[j], pt2d);
                            polyLines[j].AddVertexAt(indexindex, new Point2d(pt.X, pt.Y), 0, 0, 0);
                        }

                    }
                }

                //foreach (var poly in polyToUpdate)
                //{
                //    var newPoly = new Polyline(poly.Value.Count);

                //    for (int i = 0; i < poly.Value.Count; i++)
                //    {
                //        var curVertex = poly.Value[i];
                //        newPoly.AddVertexAt(0, new Point2d(curVertex.X, curVertex.Y), 0, 0, 0);
                //    }
                //    btr.AppendEntity(newPoly);
                //}

                // Update Screen
                Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();

                // Commit the transaction
                tr.Commit();
            }
        }

        private int CalculateInsertionIndex(Polyline polyline, Point2d newVertex)
        {
            double minDistance = double.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < polyline.NumberOfVertices ; i++)
            {
                Point2d vertex1 = polyline.GetPoint2dAt(i);

                double distance = newVertex.GetDistanceTo(vertex1);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    minIndex = i + 1; // Add 1 because we want to insert after the nearest vertex
                }
                
            }
            return minIndex;
        }

        private int CalculateInsertionIndex(BrkPolyline polyline, BrkVertex newVertex)
        {
            double minDistance = double.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < polyline.Count; i++)
            {

                double distance = newVertex.GetDistanceTo(polyline[i]);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    minIndex = i + 1; // Add 1 because we want to insert after the nearest vertex
                }

            }
            return minIndex;
        }





    }
}
