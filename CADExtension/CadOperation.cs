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
                var polyToUpdate = new List<BrkPolyline>();

                for (int i = 0; i < customPolyLines.Count; i++)
                {
                    if (!customPolyLines.ContainsKey(i)) customPolyLines.Add(i, BrkPolyline.FromACPolyline(polyLines[i]));
                    for (int j = 1; j < customPolyLines.Count; j++)
                    {
                        if (!customPolyLines.ContainsKey(j)) customPolyLines.Add(j, BrkPolyline.FromACPolyline(polyLines[j]));

                        var intersectionPoints = customPolyLines[i].IntersectionPoints(customPolyLines[j]);

                        if (intersectionPoints == null || intersectionPoints.Count == 0) continue;


                        foreach (var vtx in intersectionPoints)
                        {
                            var firtPolyIndex = vtx.Item2;
                            var secondPolyIndex = vtx.Item3;
                            var pt = vtx.Item1;

                            customPolyLines[i].Insert(firtPolyIndex, new BrkVertex(pt.X, pt.Y));
                            polyToUpdate.Add(customPolyLines[i]);

                            customPolyLines[j].Insert(secondPolyIndex, new BrkVertex(pt.X, pt.Y));
                            polyToUpdate.Add(customPolyLines[j]);


                            polyLines[i].AddVertexAt(firtPolyIndex, new Point2d(pt.X, pt.Y), 0, 0, 0);
                            polyLines[i].DowngradeOpen();

                            polyLines[j].AddVertexAt(secondPolyIndex, new Point2d(pt.X, pt.Y), 0, 0, 0);
                            polyLines[j].DowngradeOpen();

                        }

                    }
                }

                foreach (var poly in polyToUpdate)
                {
                    var newPoly = new Polyline(poly.Count);

                    for (int i = 0; i < poly.Count; i++)
                    {
                        var curVertex = poly[i];
                        newPoly.AddVertexAt(0, new Point2d(curVertex.X, curVertex.Y), 0, 0, 0);
                    }
                    btr.AppendEntity(newPoly);
                }

                // Update Screen
                Application.DocumentManager.MdiActiveDocument.Editor.Regen();
                Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();

                // Commit the transaction
                tr.Commit();
            }
        }




    }
}
