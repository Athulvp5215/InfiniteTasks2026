using InsuranceManagementSystem.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace InsuranceManagementSystem.Controllers
{
    public class PolicyController : Controller
    {
        InsuranceManagementDBEntities1 db =
            new InsuranceManagementDBEntities1();

        // ================= INDEX =================

        public ActionResult Index()
        {
            var policies = db.Policies.ToList();

            return View(policies);
        }

        // ================= CREATE =================

        public ActionResult Create()
        {
            ViewBag.UserId =
                new SelectList(
                    db.Users,
                    "UserId",
                    "FullName");

            ViewBag.PlanId =
                new SelectList(
                    db.InsurancePlans,
                    "PlanId",
                    "PlanName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Policies.Add(policy);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(policy);
        }

        // ================= DETAILS =================

        public ActionResult Details(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            return View(policy);
        }

        // ================= EDIT =================

        public ActionResult Edit(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            ViewBag.UserId =
                new SelectList(
                    db.Users,
                    "UserId",
                    "FullName",
                    policy.UserId);

            ViewBag.PlanId =
                new SelectList(
                    db.InsurancePlans,
                    "PlanId",
                    "PlanName",
                    policy.PlanId);

            return View(policy);
        }

        [HttpPost]
        public ActionResult Edit(Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policy).State =
                    System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(policy);
        }
        // ================= BUY INSURANCE =================

        public ActionResult Buy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(
            string VehicleType,
            string Manufacturer,
            string Model,
            string DL,
            DateTime PurchaseDate,
            string RegistrationNumber,
            string EngineNumber,
            string ChassisNumber,
            string Plan,
            string Duration)
        {
            // Here you can write DB save logic

            return RedirectToAction("Index");
        }
        // ================= DELETE =================

        public ActionResult Delete(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            return View(policy);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            db.Policies.Remove(policy);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Renew(int id)
        {
            Policy policy = db.Policies.Find(id);

            policy.EndDate = policy.EndDate.Value.AddYears(1);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
