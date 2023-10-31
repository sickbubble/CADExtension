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
        /// <summary>
        /// Draws simple column application plan
        /// </summary>
        [CommandMethod("DrawColumn")]
        public void DrawColumnCommand()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

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

                    if (frm.DialogResult == DialogResult.OK)
                    {

                        var inputArgs = frm.InputArgs;

                        // Draw column using the provided parameters
                        var drawingFactory = new ColumnDrawer(tr, btr);
                        drawingFactory.DrawColumn(btr, result.Value, inputArgs);

                        // Update Screen
                        Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
                    }

                    tr.Commit();
                }
            }
        }

        /// <summary>
        ///  Finds current polylines intersection points and adds new vertex
        /// </summary>
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
                // Convert to BrkPolyline
                for (int i = 0; i < polyLines.Count; i++) customPolyLines.Add(i, FromACPolyline(polyLines[i]));


                var polyToUpdate = new Dictionary<int, BrkPolyline>();

                var updateIndex = new Dictionary<int, int>();


                // Traverse polylines for intersections
                for (int i = 0; i < customPolyLines.Count; i++)
                {
                    for (int j = 1; j < customPolyLines.Count; j++)
                    {
                        if (i == j) continue;

                        var intersectionPoints = customPolyLines[i].IntersectionPoints(customPolyLines[j]);

                        if (intersectionPoints == null || intersectionPoints.Count == 0) continue;

                        foreach (var vtx in intersectionPoints)
                        {
                            var firtPolyIndex = vtx.Item2;
                            var secondPolyIndex = vtx.Item3;
                            var pt = vtx.Item1;


                            //var index = firtPolyIndex;
                            if (!polyToUpdate.ContainsKey(i)) polyToUpdate.Add(i, customPolyLines[i]);


                            var index = BrkPolyline.CalculateInsertionIndex(polyToUpdate[i], pt);
                            polyToUpdate[i].Insert(index, new BrkVertex(pt.X, pt.Y));


                            if (!polyToUpdate.ContainsKey(j)) polyToUpdate.Add(j, customPolyLines[j]);

                            index = BrkPolyline.CalculateInsertionIndex(polyToUpdate[j], pt);
                            polyToUpdate[j].Insert(index, new BrkVertex(pt.X, pt.Y));

                        }

                    }
                }

                // Remove old polylines
                foreach (var oldPoly in polyLines) oldPoly.Erase();

                // Create and add new Autocad Polylines
                foreach (var poly in polyToUpdate)
                {
                    var newPoly = new Polyline(poly.Value.Count);

                    for (int i = 0; i < poly.Value.Count; i++)
                    {
                        var curVertex = poly.Value[i];
                        newPoly.AddVertexAt(0, new Point2d(curVertex.X, curVertex.Y), 0, 0, 0);
                    }

                    btr.AppendEntity(newPoly);
                    tr.AddNewlyCreatedDBObject(newPoly, true);

                }

                // Update Screen
                Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();

                // Commit the transaction
                tr.Commit();
            }
        }

        public BrkPolyline FromACPolyline(Polyline polyLine)
        {
            var ret = new BrkPolyline();
            for (int i = 0; i < polyLine.NumberOfVertices; i++)
            {
                var pt = polyLine.GetPoint2dAt(i);
                if (pt != null)
                {
                    ret.Add(new BrkVertex(pt.X, pt.Y));
                }

            }

            return ret;
        }

    }
}
