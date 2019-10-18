using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UI.PivotGrid;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using DXWebApplication3.Models;
using DXWebApplication3.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DXWebApplication3 {
    public class CustomWebDocumentViewerReportResolver : IWebDocumentViewerReportResolver {
        NWindEntities db = new NWindEntities();

        public XtraReport CreatePivotGridReport() {
            XtraReport1 report = new XtraReport1();
            XRPivotGrid pivotGrid = report.xrPivotGrid1;
            pivotGrid.DataSource = db.ProductReports.ToList();
            var session = HttpContext.Current.Session;

            byte[] collapsedState = (byte[])session["CollapsedState"];
            byte[] layout = (byte[])session["Layout"];

            if (collapsedState != null && layout != null)
                using (MemoryStream collapsedStateMS = new MemoryStream(collapsedState))
                using (MemoryStream layoutMS = new MemoryStream(layout)) {

                    PivotGridData data = ((IPivotGridDataContainer)pivotGrid).Data;
                    new DevExpress.Utils.Serializing.XmlXtraSerializer().DeserializeObject(pivotGrid, layoutMS, "PivotGrid");
                    data.LoadCollapsedStateFromStream(collapsedStateMS);
                }
            return report;
        }

        public XtraReport Resolve(string reportEntry) {
            switch (reportEntry) {
                case "PivotGrid":
                    return CreatePivotGridReport();
            }
            return new XtraReport();
        }
    }
}