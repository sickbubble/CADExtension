using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingLib
{
    public class ColumnDrawInputArgs
    {
        public ColumnDrawInputArgs()
        {

        }

        private double _SectionWidth;
        private double _SectionHeight;
        private double _ColumnElevation;
        private double _ConcreteCover;

        private double _LinkDiameter;
        private double _LinkSpacing;
        private double _LinkDenseSpacing;
        private double _LongBarDiameter;

        public double SectionWidth { get => _SectionWidth; set => _SectionWidth = value; }
        public double SectionHeight { get => _SectionHeight; set => _SectionHeight = value; }
        public double ColumnElevation { get => _ColumnElevation; set => _ColumnElevation = value; }
        public double ConcreteCover { get => _ConcreteCover; set => _ConcreteCover = value; }
        public double LinkDiameter { get => _LinkDiameter; set => _LinkDiameter = value; }
        public double LinkSpacing { get => _LinkSpacing; set => _LinkSpacing = value; }
        public double LinkDenseSpacing { get => _LinkDenseSpacing; set => _LinkDenseSpacing = value; }
        public double LongBarDiameter { get => _LongBarDiameter; set => _LongBarDiameter = value; }
    }
}
