

using System;

using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class PaymentController : Controller
    {
        InsuranceManagementDBEntities1 db =
        new InsuranceManagementDBEntities1();



    public ActionResult Index()
        {
            var payments = db.Payments.ToList();

            return View(payments);
        }

        // ================= CREATE =================

        public ActionResult Create()
        {
            ViewBag.PolicyId =
                new SelectList(
                    db.Policies,
                    "PolicyId",
                    "PolicyNumber");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(payment);
        }

        // ================= DETAILS =================

        public ActionResult Details(int id)
        {
            Payment payment =
                db.Payments.Find(id);

            if (payment == null)
            {
                return HttpNotFound();
            }

            return View(payment);
        }

        // ================= DELETE =================

        public ActionResult Delete(int id)
        {
            Payment payment =
                db.Payments.Find(id);

            if (payment == null)
            {
                return HttpNotFound();
            }

            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment =
                db.Payments.Find(id);

            if (payment != null)
            {
                db.Payments.Remove(payment);

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }


}
