using DrawingLib;
using GeometryLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputUI
{
    public partial class frmDrawColumnInput : Form
    {
        public frmDrawColumnInput()
        {
            InitializeComponent();
            InıtData();
            PrepareUI();
            SubscribeToEvents();
        }


        #region Private Fields
        private bool _Changed;
        private ColumnDrawInputArgs _InputArgs;
        #endregion

        #region Public Properties
        public ColumnDrawInputArgs InputArgs { get => _InputArgs; set => _InputArgs = value; }
        #endregion

        #region Private Methods
        private void InıtData()
        {
            _Changed = true;
            _InputArgs = new ColumnDrawInputArgs();
        }
        private void PrepareUI()
        {
            numSectionWidth.Value = 30;
            numSectionHeight.Value = 30;
            numColumnElevation.Value = 300;
            numConcCover.Value = (decimal)2.5;


            numBarDiameter.Value = 16;
            numLinkDiameter.Value = 8;
            numLinkSpacing.Value = 10;
            numLinkDenseSpacing.Value = 5;
        }
        private void SubscribeToEvents()
        {
            numSectionWidth.ValueChanged += ValueChanged;
            numSectionHeight.ValueChanged += ValueChanged;
            numLinkSpacing.ValueChanged += ValueChanged;
            numLinkDiameter.ValueChanged += ValueChanged;
            numConcCover.ValueChanged += ValueChanged;
            numBarDiameter.ValueChanged += ValueChanged;
            numColumnElevation.ValueChanged += ValueChanged;
            numLinkDenseSpacing.ValueChanged += ValueChanged;
            btnOK.Click += btnOK_Click;
        }
        private void ApplyChanges()
        {
            if (_Changed)
            {
                _InputArgs.SectionHeight = Convert.ToDouble(numSectionHeight.Value);
                _InputArgs.SectionWidth = Convert.ToDouble(numSectionWidth.Value);
                _InputArgs.ColumnElevation = Convert.ToDouble(numColumnElevation.Value);
                _InputArgs.ConcreteCover = Convert.ToDouble(numConcCover.Value);
                _InputArgs.LinkDenseSpacing = Convert.ToDouble(numLinkDenseSpacing.Value);
                _InputArgs.LinkSpacing = Convert.ToDouble(numLinkSpacing.Value);
                _InputArgs.LinkDiameter = 0.1 * Convert.ToDouble(numLinkDiameter.Value);
                _InputArgs.LongBarDiameter = 0.1 * Convert.ToDouble(numBarDiameter.Value);
            }

        }

        #endregion


        #region Events
        private void ValueChanged(object sender, EventArgs e)
        {
            _Changed = true;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        #endregion


    }
}
