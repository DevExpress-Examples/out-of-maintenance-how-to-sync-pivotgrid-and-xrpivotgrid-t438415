using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DXWebApplication3.Models;

namespace DXWebApplication3.Controllers {
    public class HomeController : Controller {

        NWindEntities db = new NWindEntities();
        
        public ActionResult Index() {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult PivotGridPartial() {
            var model = db.ProductReports;
            return PartialView("_PivotGridPartial", model.ToList());
        }
    }
}