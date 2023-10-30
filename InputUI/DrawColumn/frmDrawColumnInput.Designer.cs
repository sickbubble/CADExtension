
namespace InputUI
{
    partial class frmDrawColumnInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSectionWidth = new System.Windows.Forms.Label();
            this.numSectionWidth = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.numSectionHeight = new System.Windows.Forms.NumericUpDown();
            this.lblSectionHeight = new System.Windows.Forms.Label();
            this.numColumnElevation = new System.Windows.Forms.NumericUpDown();
            this.lblColumnElevation = new System.Windows.Forms.Label();
            this.numConcCover = new System.Windows.Forms.NumericUpDown();
            this.lblConcCover = new System.Windows.Forms.Label();
            this.numLinkDenseSpacing = new System.Windows.Forms.NumericUpDown();
            this.lblLinkDenseSpacing = new System.Windows.Forms.Label();
            this.numLinkSpacing = new System.Windows.Forms.NumericUpDown();
            this.lblLinkSpacing = new System.Windows.Forms.Label();
            this.numLinkDiameter = new System.Windows.Forms.NumericUpDown();
            this.lblLinkDiameter = new System.Windows.Forms.Label();
            this.numBarDiameter = new System.Windows.Forms.NumericUpDown();
            this.lblBarDiameter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSectionWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSectionHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumnElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConcCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLinkDenseSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLinkSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLinkDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBarDiameter)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSectionWidth
            // 
            this.lblSectionWidth.AutoSize = true;
            this.lblSectionWidth.Location = new System.Drawing.Point(24, 42);
            this.lblSectionWidth.Name = "lblSectionWidth";
            this.lblSectionWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSectionWidth.Size = new System.Drawing.Size(72, 13);
            this.lblSectionWidth.TabIndex = 1;
            this.lblSectionWidth.Text = "Kesit Genişliği";
            // 
            // numSectionWidth
            // 
            this.numSectionWidth.Location = new System.Drawing.Point(105, 35);
            this.numSectionWidth.Margin = new System.Windows.Forms.Padding(6);
            this.numSectionWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSectionWidth.Name = "numSectionWidth";
            this.numSectionWidth.Size = new System.Drawing.Size(120, 20);
            this.numSectionWidth.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(414, 202);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // numSectionHeight
            // 
            this.numSectionHeight.Location = new System.Drawing.Point(105, 67);
            this.numSectionHeight.Margin = new System.Windows.Forms.Padding(6);
            this.numSectionHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSectionHeight.Name = "numSectionHeight";
            this.numSectionHeight.Size = new System.Drawing.Size(120, 20);
            this.numSectionHeight.TabIndex = 5;
            // 
            // lblSectionHeight
            // 
            this.lblSectionHeight.AutoSize = true;
            this.lblSectionHeight.Location = new System.Drawing.Point(12, 74);
            this.lblSectionHeight.Name = "lblSectionHeight";
            this.lblSectionHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSectionHeight.Size = new System.Drawing.Size(84, 13);
            this.lblSectionHeight.TabIndex = 4;
            this.lblSectionHeight.Text = "Kesit Yüksekliği:";
            // 
            // numColumnElevation
            // 
            this.numColumnElevation.Location = new System.Drawing.Point(105, 99);
            this.numColumnElevation.Margin = new System.Windows.Forms.Padding(6);
            this.numColumnElevation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numColumnElevation.Name = "numColumnElevation";
            this.numColumnElevation.Size = new System.Drawing.Size(120, 20);
            this.numColumnElevation.TabIndex = 7;
            // 
            // lblColumnElevation
            // 
            this.lblColumnElevation.AutoSize = true;
            this.lblColumnElevation.Location = new System.Drawing.Point(11, 106);
            this.lblColumnElevation.Name = "lblColumnElevation";
            this.lblColumnElevation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblColumnElevation.Size = new System.Drawing.Size(85, 13);
            this.lblColumnElevation.TabIndex = 6;
            this.lblColumnElevation.Text = "Kolon Yüksekliği";
            // 
            // numConcCover
            // 
            this.numConcCover.Location = new System.Drawing.Point(105, 131);
            this.numConcCover.Margin = new System.Windows.Forms.Padding(6);
            this.numConcCover.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numConcCover.Name = "numConcCover";
            this.numConcCover.Size = new System.Drawing.Size(120, 20);
            this.numConcCover.TabIndex = 9;
            // 
            // lblConcCover
            // 
            this.lblConcCover.AutoSize = true;
            this.lblConcCover.Location = new System.Drawing.Point(49, 138);
            this.lblConcCover.Name = "lblConcCover";
            this.lblConcCover.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblConcCover.Size = new System.Drawing.Size(47, 13);
            this.lblConcCover.TabIndex = 8;
            this.lblConcCover.Text = "Paspayı:";
            // 
            // numLinkDenseSpacing
            // 
            this.numLinkDenseSpacing.Location = new System.Drawing.Point(369, 131);
            this.numLinkDenseSpacing.Margin = new System.Windows.Forms.Padding(6);
            this.numLinkDenseSpacing.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLinkDenseSpacing.Name = "numLinkDenseSpacing";
            this.numLinkDenseSpacing.Size = new System.Drawing.Size(120, 20);
            this.numLinkDenseSpacing.TabIndex = 17;
            this.numLinkDenseSpacing.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // lblLinkDenseSpacing
            // 
            this.lblLinkDenseSpacing.AutoSize = true;
            this.lblLinkDenseSpacing.Location = new System.Drawing.Point(274, 138);
            this.lblLinkDenseSpacing.Name = "lblLinkDenseSpacing";
            this.lblLinkDenseSpacing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLinkDenseSpacing.Size = new System.Drawing.Size(86, 13);
            this.lblLinkDenseSpacing.TabIndex = 16;
            this.lblLinkDenseSpacing.Text = "Etriye Sık. Aralık:";
            // 
            // numLinkSpacing
            // 
            this.numLinkSpacing.Location = new System.Drawing.Point(369, 99);
            this.numLinkSpacing.Margin = new System.Windows.Forms.Padding(6);
            this.numLinkSpacing.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLinkSpacing.Name = "numLinkSpacing";
            this.numLinkSpacing.Size = new System.Drawing.Size(120, 20);
            this.numLinkSpacing.TabIndex = 15;
            // 
            // lblLinkSpacing
            // 
            this.lblLinkSpacing.AutoSize = true;
            this.lblLinkSpacing.Location = new System.Drawing.Point(295, 106);
            this.lblLinkSpacing.Name = "lblLinkSpacing";
            this.lblLinkSpacing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLinkSpacing.Size = new System.Drawing.Size(65, 13);
            this.lblLinkSpacing.TabIndex = 14;
            this.lblLinkSpacing.Text = "Etriye Aralık:";
            // 
            // numLinkDiameter
            // 
            this.numLinkDiameter.Location = new System.Drawing.Point(369, 67);
            this.numLinkDiameter.Margin = new System.Windows.Forms.Padding(6);
            this.numLinkDiameter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLinkDiameter.Name = "numLinkDiameter";
            this.numLinkDiameter.Size = new System.Drawing.Size(120, 20);
            this.numLinkDiameter.TabIndex = 13;
            // 
            // lblLinkDiameter
            // 
            this.lblLinkDiameter.AutoSize = true;
            this.lblLinkDiameter.Location = new System.Drawing.Point(269, 74);
            this.lblLinkDiameter.Name = "lblLinkDiameter";
            this.lblLinkDiameter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLinkDiameter.Size = new System.Drawing.Size(91, 13);
            this.lblLinkDiameter.TabIndex = 12;
            this.lblLinkDiameter.Text = "Etriye Donatı Çapı";
            // 
            // numBarDiameter
            // 
            this.numBarDiameter.Location = new System.Drawing.Point(369, 35);
            this.numBarDiameter.Margin = new System.Windows.Forms.Padding(6);
            this.numBarDiameter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBarDiameter.Name = "numBarDiameter";
            this.numBarDiameter.Size = new System.Drawing.Size(120, 20);
            this.numBarDiameter.TabIndex = 11;
            // 
            // lblBarDiameter
            // 
            this.lblBarDiameter.AutoSize = true;
            this.lblBarDiameter.Location = new System.Drawing.Point(259, 42);
            this.lblBarDiameter.Name = "lblBarDiameter";
            this.lblBarDiameter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBarDiameter.Size = new System.Drawing.Size(101, 13);
            this.lblBarDiameter.TabIndex = 10;
            this.lblBarDiameter.Text = "Boyuna Donatı Çapı";
            // 
            // frmDrawColumnInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 237);
            this.Controls.Add(this.numLinkDenseSpacing);
            this.Controls.Add(this.lblLinkDenseSpacing);
            this.Controls.Add(this.numLinkSpacing);
            this.Controls.Add(this.lblLinkSpacing);
            this.Controls.Add(this.numLinkDiameter);
            this.Controls.Add(this.lblLinkDiameter);
            this.Controls.Add(this.numBarDiameter);
            this.Controls.Add(this.lblBarDiameter);
            this.Controls.Add(this.numConcCover);
            this.Controls.Add(this.lblConcCover);
            this.Controls.Add(this.numColumnElevation);
            this.Controls.Add(this.lblColumnElevation);
            this.Controls.Add(this.numSectionHeight);
            this.Controls.Add(this.lblSectionHeight);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numSectionWidth);
            this.Controls.Add(this.lblSectionWidth);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(520, 276);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 276);
            this.Name = "frmDrawColumnInput";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Text = "Kolon Detayları";
            ((System.ComponentModel.ISupportInitialize)(this.numSectionWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSectionHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumnElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConcCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLinkDenseSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLinkSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLinkDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBarDiameter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSectionWidth;
        private System.Windows.Forms.NumericUpDown numSectionWidth;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown numSectionHeight;
        private System.Windows.Forms.Label lblSectionHeight;
        private System.Windows.Forms.NumericUpDown numColumnElevation;
        private System.Windows.Forms.Label lblColumnElevation;
        private System.Windows.Forms.NumericUpDown numConcCover;
        private System.Windows.Forms.Label lblConcCover;
        private System.Windows.Forms.NumericUpDown numLinkDenseSpacing;
        private System.Windows.Forms.Label lblLinkDenseSpacing;
        private System.Windows.Forms.NumericUpDown numLinkSpacing;
        private System.Windows.Forms.Label lblLinkSpacing;
        private System.Windows.Forms.NumericUpDown numLinkDiameter;
        private System.Windows.Forms.Label lblLinkDiameter;
        private System.Windows.Forms.NumericUpDown numBarDiameter;
        private System.Windows.Forms.Label lblBarDiameter;
    }
}

