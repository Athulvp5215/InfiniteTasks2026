using System;
using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class PolicyController : Controller
    {
        InsuranceManagementDBEntities db =
            new InsuranceManagementDBEntities();

        public ActionResult Index()
        {
            return View(db.Policies.ToList());
        }

        public ActionResult MyPolicies()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId =
                Convert.ToInt32(Session["UserId"]);

            var policies =
                db.Policies
                .Where(p => p.UserId == userId)
                .ToList();

            return View(policies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId =
                Convert.ToInt32(Session["UserId"]);

            ViewBag.PlanId =
                new SelectList(
                    db.InsurancePlans.ToList(),
                    "PlanId",
                    "PlanName");

            ViewBag.VehicleId =
                new SelectList(
                    db.Vehicles
                    .Where(v => v.UserId == userId)
                    .ToList(),
                    "VehicleId",
                    "VehicleNumber");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Policy policy)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int userId =
                Convert.ToInt32(Session["UserId"]);

            var plan =
                db.InsurancePlans.Find(
                    policy.PlanId);

            if (plan == null)
            {
                ViewBag.Error =
                    "Insurance Plan Not Found";

                ViewBag.PlanId =
                    new SelectList(
                        db.InsurancePlans,
                        "PlanId",
                        "PlanName");

                ViewBag.VehicleId =
                    new SelectList(
                        db.Vehicles.Where(v =>
                            v.UserId == userId),
                        "VehicleId",
                        "VehicleNumber");

                return View(policy);
            }

            policy.UserId =
                userId;

            policy.PolicyNumber =
                "POL" +
                DateTime.Now.ToString("yyyyMMddHHmmss");

            policy.StartDate =
                DateTime.Now;

            policy.EndDate =
                DateTime.Now.AddYears(1);

            policy.PremiumAmount =
                plan.BasePremium;

            policy.PolicyStatus =
                "Pending Payment";

            db.Policies.Add(policy);

            db.SaveChanges();

            TempData["Message"] =
                "Policy Created Successfully";

            return RedirectToAction(
                "Create",
                "Payment",
                new
                {
                    policyId = policy.PolicyId
                });
        }

        public ActionResult Details(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            if (policy == null)
            {
                return HttpNotFound();
            }

            return View(policy);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            if (policy == null)
            {
                return HttpNotFound();
            }

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
            Policy existingPolicy =
                db.Policies.Find(
                    policy.PolicyId);

            if (existingPolicy != null)
            {
                existingPolicy.PlanId =
                    policy.PlanId;

                existingPolicy.PolicyType =
                    policy.PolicyType;

                db.SaveChanges();
            }

            return RedirectToAction(
                "MyPolicies");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            if (policy == null)
            {
                return HttpNotFound();
            }

            return View(policy);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            if (policy != null)
            {
                bool paymentExists =
                    db.Payments.Any(
                        p => p.PolicyId == id);

                if (paymentExists)
                {
                    TempData["Error"] =
                        "Cannot delete paid policy";

                    return RedirectToAction(
                        "MyPolicies");
                }

                db.Policies.Remove(policy);

                db.SaveChanges();
            }

            return RedirectToAction(
                "MyPolicies");
        }

        public ActionResult Renew(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            if (policy == null)
            {
                return HttpNotFound();
            }

            Renewal renewal =
                new Renewal();

            renewal.PolicyId =
                policy.PolicyId;

            renewal.RenewalDate =
                DateTime.Now;

            renewal.NewEndDate =
                policy.EndDate.Value.AddYears(1);

            renewal.RenewalAmount =
                policy.PremiumAmount;

            db.Renewals.Add(renewal);

            policy.EndDate =
                renewal.NewEndDate;

            policy.PolicyStatus =
                "Active";

            db.SaveChanges();

            TempData["Message"] =
                "Policy Renewed Successfully";

            return RedirectToAction(
                "MyPolicies");
        }
    }
}