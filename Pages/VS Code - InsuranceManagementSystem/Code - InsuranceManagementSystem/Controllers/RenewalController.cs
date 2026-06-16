using System;
using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class RenewalController : Controller
    {
        InsuranceManagementDBEntities db =
            new InsuranceManagementDBEntities();

        // ======================
        // MY RENEWALS
        // ======================

        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account");
            }

            int userId =
                Convert.ToInt32(
                    Session["UserId"]);

            var renewals =
                db.Renewals
                .Where(r =>
                    r.Policy.UserId == userId)
                .OrderByDescending(r =>
                    r.RenewalDate)
                .ToList();

            return View(renewals);
        }

        // ======================
        // DETAILS
        // ======================

        public ActionResult Details(int id)
        {
            Renewal renewal =
                db.Renewals.Find(id);

            if (renewal == null)
            {
                return HttpNotFound();
            }

            return View(renewal);
        }

        // ======================
        // DELETE
        // ======================

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Renewal renewal =
                db.Renewals.Find(id);

            if (renewal == null)
            {
                return HttpNotFound();
            }

            return View(renewal);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Renewal renewal =
                db.Renewals.Find(id);

            if (renewal != null)
            {
                db.Renewals.Remove(renewal);

                db.SaveChanges();
            }

            TempData["Message"] =
                "Renewal Deleted Successfully";

            return RedirectToAction(
                "Index");
        }
    }
}