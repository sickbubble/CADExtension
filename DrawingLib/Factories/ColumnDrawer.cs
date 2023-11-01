using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLib.Factories
{
    public class ColumnDrawer
    {
        #region Ctor
        public ColumnDrawer()
        {

        }
        public ColumnDrawer(Transaction tr, BlockTableRecord btr)
        {
            _TR = tr;
            _BTR = btr;

        }
        #endregion

        #region Private Fields
        private Transaction _TR;
        private BlockTableRecord _BTR;
        #endregion

        #region Drawing Methods
        public void DrawColumn(BlockTableRecord btr, Point3d basePoint, ColumnDrawInputArgs inputArgs)
        {
            DrawColumnSectionView(btr, basePoint, inputArgs);

            DrawColumnElevationView(btr, new Point3d(basePoint.X + inputArgs.SectionWidth + 50, basePoint.Y, basePoint.Z), inputArgs);

            GetColumnDetailText(btr, basePoint, inputArgs);
        }
        private void GetColumnDetailText(BlockTableRecord btr, Point3d basePoint, ColumnDrawInputArgs inputArgs)
        {
            var size = 3;
            double margin = 3;

            var stPoint = new Point3d(basePoint.X, basePoint.Y - 10, 0);
            //Prepare First Line
            var firstLine = $"Pas Payı Bilgisi ({inputArgs.ConcreteCover} cm)";
            GetTextToPoint(btr, stPoint, firstLine, size);

            //Prepare Second Line
            var secondLine = $"Boyuna Donatı Bilgisi ({12}f{inputArgs.LongBarDiameter * 10})";
            GetTextToPoint(btr, new Point3d(stPoint.X, stPoint.Y - size - margin, stPoint.Z), secondLine, size);

            //Prepare Third Line
            var thirdLine = $"Etriye Donatı Bilgisi (Çap-Aralık-Sıklaştırma Aralığı) (f{inputArgs.LinkDiameter * 10}/{inputArgs.LinkSpacing}/{inputArgs.LinkDenseSpacing})";
            GetTextToPoint(btr, new Point3d(stPoint.X, stPoint.Y - 2 * size - 2 * margin, stPoint.Z), thirdLine, size);
        }
        private void DrawColumnSectionView(BlockTableRecord btr, Point3d basePoint, ColumnDrawInputArgs inputArgs)
        {
            // Get Column Outer Line
            DrawRectangle(btr, basePoint, inputArgs.SectionWidth, inputArgs.SectionHeight, Color.FromRgb(0, 255, 0));

            // Get Column Reinforcement Drawing
            var cCover = inputArgs.ConcreteCover;
            // Get link ınserion point
            var linkBase = new Point3d(basePoint.X + cCover, basePoint.Y + cCover, basePoint.X);
            GetSectionReinforcement(btr, inputArgs, linkBase, cCover);

        }
        private void GetSectionReinforcement(BlockTableRecord btr, ColumnDrawInputArgs inputArgs, Point3d linkBase, double concreteCover)
        {
            double linkWidth = inputArgs.SectionWidth - 2 * concreteCover;
            double linkHeigth = inputArgs.SectionHeight - 2 * concreteCover;

            var red = Color.FromRgb(255, 0, 0);
            // Get Link View
            DrawRectangle(btr, linkBase, linkWidth, linkHeigth, red);

            // Get Longitudinal Bar
            var barDiam = inputArgs.LongBarDiameter;
            // Left-Bottom

            var leftBot = DrawCircle(new Point3d(linkBase.X + barDiam / 2, linkBase.Y + barDiam / 2, linkBase.Z), barDiam, red);
            AppendEntity(leftBot);
            // Left-Top
            var leftTop = DrawCircle(new Point3d(linkBase.X + barDiam / 2, linkHeigth + linkBase.Y - barDiam / 2, linkBase.Z), barDiam, red);
            AppendEntity(leftTop);
            // Mid-Bot
            var midBot = DrawCircle(new Point3d(linkBase.X + linkWidth / 2, linkBase.Y + barDiam / 2, linkBase.Z), barDiam, red);
            AppendEntity(midBot);
            // Mid-Top
            var midTop = DrawCircle(new Point3d(linkBase.X + linkWidth / 2, linkHeigth + linkBase.Y - barDiam / 2, linkBase.Z), barDiam, red);
            AppendEntity(midTop);
            // Rigth-Bot
            var rigthBot = DrawCircle(new Point3d(linkBase.X + linkWidth - barDiam / 2, linkBase.Y + barDiam / 2, linkBase.Z), barDiam, red);
            AppendEntity(rigthBot);
            // Rigth-Top
            var rigthTop = DrawCircle(new Point3d(linkBase.X + linkWidth - barDiam / 2, linkHeigth + linkBase.Y - barDiam / 2, linkBase.Z), barDiam, red);
            AppendEntity(rigthTop);
        }
        private void DrawColumnElevationView(BlockTableRecord btr, Point3d basePoint, ColumnDrawInputArgs inputArgs)
        {
            DrawRectangle(btr, basePoint, inputArgs.SectionWidth, inputArgs.ColumnElevation, Color.FromRgb(0, 255, 0));

            var cCover = inputArgs.ConcreteCover;

            // Get Link Drawing
            var link = new Line(new Point3d(basePoint.X + cCover, basePoint.Y + inputArgs.ColumnElevation / 2, basePoint.Z),
                                new Point3d(basePoint.X + inputArgs.SectionWidth - cCover, basePoint.Y + inputArgs.ColumnElevation / 2, basePoint.Z));
            link.Color = Color.FromRgb(255, 0, 0);
            AppendEntity(link);

            // Get Longitudinal Bars
            var leftBar = new Line(new Point3d(basePoint.X + cCover, basePoint.Y, 0), new Point3d(basePoint.X + cCover, basePoint.Y + inputArgs.ColumnElevation, 0));
            leftBar.Color = Color.FromRgb(255, 0, 0);
            AppendEntity(leftBar);

            var rigthBar = new Line(new Point3d(inputArgs.SectionWidth + basePoint.X - cCover, basePoint.Y, 0), new Point3d(inputArgs.SectionWidth + basePoint.X - cCover, basePoint.Y + inputArgs.ColumnElevation, 0));
            rigthBar.Color = Color.FromRgb(255, 0, 0);
            AppendEntity(rigthBar);
        }
        #endregion

        #region Common Methods
        private void AppendEntity(Entity entity)
        {
            _BTR.AppendEntity(entity);
            _TR.AddNewlyCreatedDBObject(entity, true);

        }
        private void GetTextToPoint(BlockTableRecord btr, Point3d basePoint, string input, double size)
        {
            var text = new DBText();
            text.Position = new Point3d(basePoint.X, basePoint.Y - size, 0);
            text.Height = size;
            text.TextString = input;
            AppendEntity(text);
        }
        private void DrawRectangle(BlockTableRecord btr, Point3d basePoint, double width, double height, Color color)
        {
            var secondPt = new Point3d(basePoint.X + width, basePoint.Y, basePoint.Z);
            var thirdPt = new Point3d(secondPt.X, secondPt.Y + height, basePoint.Z);
            var lastPt = new Point3d(thirdPt.X - width, thirdPt.Y, basePoint.Z);

            var line1 = new Line(basePoint, secondPt);
            line1.Color = color;
            AppendEntity(line1);

            var line2 = new Line(secondPt, thirdPt);
            line2.Color = color;
            AppendEntity(line2);


            var line3 = new Line(thirdPt, lastPt);
            line3.Color = color;
            AppendEntity(line3);

            var line4 = new Line(lastPt, basePoint);
            line4.Color = color;
            AppendEntity(line4);

        }
        private Circle DrawCircle(Point3d center, double diameter, Color color)
        {
            //var vector =  center.GetVectorTo(Point3d.Origin).Negate();
            var circle = new Circle(center, new Vector3d(0, 0, 1), diameter / 2);
            circle.Color = color;
            return circle;
        }
        #endregion
    }
}
