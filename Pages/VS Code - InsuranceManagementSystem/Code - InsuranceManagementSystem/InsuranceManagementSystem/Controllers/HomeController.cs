using InsuranceManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            InsuranceManagementDBEntities db = new InsuranceManagementDBEntities();

            var plans = db.InsurancePlans.ToList();

            return View(plans);
        }
    }
}