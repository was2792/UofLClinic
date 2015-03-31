using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vaccines_and_Travel_Clinic.DAL;
using Vaccines_and_Travel_Clinic.Models;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Research()
        {
            ViewBag.Message = "Your research page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your services page.";

            return View();
        }

        public ActionResult Immunization()
        {
            ViewBag.Message = "Your immunization page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your about page.";

            return View();
        }

        public ActionResult Surgeon()
        {
            ViewBag.Message = "Your civil surgeon page.";

            return View();
        }

        public ActionResult Partners()
        {
            ViewBag.Message = "Your partners page.";

            return View();
        }

        public ActionResult Repository()
        {
            ViewBag.Message = "Your repository page.";

            return View();
        }
        
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your dashboard page.";

            return View();
        }

        public ActionResult Sales()
        {
           using (ClinicContext db = new ClinicContext())
           {
               var sales = db.Sales
                   .Where(s => s.Date.Year == DateTime.Now.Year)
                   .Select(s => new
                   {
                       date = s.Date,
                       value = db.SaleLines.Where(sl => sl.SaleID == s.ID).Sum(sl => sl.Quantity * sl.Price)
                   })
                   .ToList();

               return Json(
                       sales.GroupBy(s => s.date.Month)
                            .Select(s => new
                            {
                                month = s.Key,
                                value = s.Sum(x => x.value)
                            })
                            .OrderBy(s => s.month)
                            .ToList(), 
                        JsonRequestBehavior.AllowGet
                    );
           }
        }

        public ActionResult Orders()
        {
            using (ClinicContext db = new ClinicContext())
            {
                var orders = db.Orders
                    .Where(o => o.Date.Year == DateTime.Now.Year)
                    .Select(o => new
                    {
                        date = o.Date,
                        value = db.OrderLines.Where(ol => ol.OrderID == o.ID).Sum(ol => ol.Quantity * ol.Price)
                    })
                    .ToList();

                return Json(
                        orders.GroupBy(o => o.date.Month)
                             .Select(o => new
                             {
                                 month = o.Key,
                                 value = o.Sum(x => x.value)
                             })
                             .OrderBy(o => o.month)
                             .ToList(),
                         JsonRequestBehavior.AllowGet
                     );
            }
        }

        public ActionResult Items()
        {
            using (ClinicContext db = new ClinicContext())
            {
                var items = db.Items
                    .Select(i => new
                    {
                        name = i.Name,
                        value = i.Count
                    })
                    .ToList();

                return Json(
                        items.GroupBy(i => i.name)
                             .Select(i => new
                             {
                                 name = i.Key,
                                 value = i.Sum(x => x.value)
                             })
                             .OrderBy(i => i.name)
                             .ToList(),
                         JsonRequestBehavior.AllowGet
                     );
            }
        }

        public ActionResult Appointments()
        {
            using (ClinicContext db = new ClinicContext())
            {
                var sales = db.Sales
                    .Where(s => s.Date.Year == DateTime.Now.Year)
                    .Select(s => new
                    {
                        date = s.Date,
                        value = db.SaleLines.Where(sl => sl.SaleID == s.ID).Sum(sl => sl.Quantity * sl.Price)
                    })
                    .ToList();

                return Json(
                        sales.GroupBy(s => s.date.Month)
                             .Select(s => new
                             {
                                 month = s.Key,
                                 value = s.Sum(x => x.value)
                             })
                             .ToList(),
                         JsonRequestBehavior.AllowGet
                     );
            }
        }
    }
}
