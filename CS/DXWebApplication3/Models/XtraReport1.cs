using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DXWebApplication3.Models {
    /// <summary>
    /// Summary description for XtraReport3.
    /// </summary>
    public class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        public XRPivotGrid xrPivotGrid1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCategoryName;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldProductName;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldProductSales;
        private TopMarginBand topMarginBand1;
        private BottomMarginBand bottomMarginBand1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public XtraReport1() {
            /// <summary>
            /// Required for Windows.Forms Class Composition Designer support
            /// </summary>
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.fieldCategoryName = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldProductName = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldProductSales = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.Detail.HeightF = 245F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldCategoryName,
            this.fieldProductName,
            this.fieldProductSales});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(7.999992F, 7.999992F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsChartDataSource.UpdateDelay = 300;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(733F, 117F);
            // 
            // fieldCategoryName
            // 
            this.fieldCategoryName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldCategoryName.AreaIndex = 0;
            this.fieldCategoryName.FieldName = "CategoryName";
            this.fieldCategoryName.Name = "fieldCategoryName";
            // 
            // fieldProductName
            // 
            this.fieldProductName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldProductName.AreaIndex = 1;
            this.fieldProductName.FieldName = "ProductName";
            this.fieldProductName.Name = "fieldProductName";
            // 
            // fieldProductSales
            // 
            this.fieldProductSales.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldProductSales.AreaIndex = 0;
            this.fieldProductSales.FieldName = "ProductSales";
            this.fieldProductSales.Name = "fieldProductSales";
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.FieldName = "CategoryName";
            this.pivotGridField3.Name = "pivotGridField3";
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 48F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 48F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // XtraReport1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Margins = new System.Drawing.Printing.Margins(50, 49, 48, 48);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
    }
}

