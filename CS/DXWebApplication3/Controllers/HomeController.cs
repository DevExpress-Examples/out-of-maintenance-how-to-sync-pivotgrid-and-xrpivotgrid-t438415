using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DXWebApplication3.Models;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraReports.UI.PivotGrid;
using System.IO;

namespace DXWebApplication3.Controllers {
    public class HomeController : Controller {

        NwindContextDataContext db = new DXWebApplication3.Models.NwindContextDataContext();
        
        public ActionResult Index() {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult PivotGridPartial() {
            var model = db.ProductReports;
            return PartialView("_PivotGridPartial", model);
        }

        public ActionResult DocumentViewerPartial() {
            XtraReport report = CreateReport();
            return PartialView("_DocumentViewerPartial", report);
        }

        public ActionResult DocumentViewerPartialExport() {
            XtraReport report = CreateReport();
            return DocumentViewerExtension.ExportTo(report, Request);
        }

        public XtraReport CreateReport() {
            XtraReport1 report = new XtraReport1();
            XRPivotGrid pivotGrid = report.xrPivotGrid1;
            pivotGrid.DataSource = db.ProductReports;

            byte[] collapsedState = (byte[])Session["CollapsedState"];
            byte[] layout = (byte[])Session["Layout"];

            if (collapsedState != null && layout != null)
                using (MemoryStream collapsedStateMS = new MemoryStream(collapsedState))
                using (MemoryStream layoutMS = new MemoryStream(layout)) {
                 
                    PivotGridData data = ((IPivotGridDataContainer)pivotGrid).Data;
                    new DevExpress.Utils.Serializing.XmlXtraSerializer().DeserializeObject(pivotGrid, layoutMS, "PivotGrid");
                    data.LoadCollapsedStateFromStream(collapsedStateMS);
                }
            return report;
        }
    }
}