using System;
using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class PaymentController : Controller
    {
        InsuranceManagementDBEntities db =
            new InsuranceManagementDBEntities();

        // ==========================
        // PAYMENT LIST
        // ==========================

        public ActionResult Index()
        {
            return View(
                db.Payments.ToList());
        }

        // ==========================
        // CREATE PAYMENT - GET
        // ==========================

        [HttpGet]
        public ActionResult Create(
            int? policyId,
            bool? isRenewal)
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

            ViewBag.PolicyId =
                new SelectList(
                    db.Policies
                    .Where(p => p.UserId == userId)
                    .ToList(),
                    "PolicyId",
                    "PolicyNumber",
                    policyId);

            ViewBag.IsRenewal =
                isRenewal;

            if (policyId != null)
            {
                Policy policy =
                    db.Policies.Find(policyId);

                if (policy != null)
                {
                    ViewBag.Amount =
                        policy.PremiumAmount;
                }
            }

            return View();
        }

        // ==========================
        // CREATE PAYMENT - POST
        // ==========================

        [HttpPost]
        public ActionResult Create(
            Payment payment,
            bool? isRenewal)
        {
            if (ModelState.IsValid)
            {
                payment.PaymentDate =
                    DateTime.Now;

                payment.PaymentStatus =
                    "Success";

                db.Payments.Add(payment);

                Policy policy =
                    db.Policies.Find(
                        payment.PolicyId);

                if (policy != null)
                {
                    policy.PolicyStatus =
                        "Active";
                }

                db.SaveChanges();

                // ==========================
                // RENEWAL PAYMENT
                // ==========================

                if (isRenewal == true)
                {
                    Renewal renewal =
                        new Renewal();

                    renewal.PolicyId =
                        payment.PolicyId;

                    renewal.RenewalDate =
                        DateTime.Now;

                    renewal.NewEndDate =
                        policy.EndDate.HasValue
                        ? policy.EndDate.Value.AddYears(1)
                        : DateTime.Now.AddYears(1);

                    renewal.RenewalAmount =
                        policy.PremiumAmount;

                    db.Renewals.Add(
                        renewal);

                    policy.EndDate =
                        renewal.NewEndDate;

                    policy.PolicyStatus =
                        "Active";

                    db.SaveChanges();

                    TempData["Message"] =
                        "Policy Renewed Successfully";

                    return RedirectToAction(
                        "Index",
                        "Renewal");
                }

                TempData["Message"] =
                    "Payment Successful";

                return RedirectToAction(
                    "Receipt",
                    new
                    {
                        id = payment.PaymentId
                    });
            }

            int userId =
                Convert.ToInt32(
                    Session["UserId"]);

            ViewBag.PolicyId =
                new SelectList(
                    db.Policies
                    .Where(p => p.UserId == userId)
                    .ToList(),
                    "PolicyId",
                    "PolicyNumber",
                    payment.PolicyId);

            return View(payment);
        }

        // ==========================
        // RECEIPT
        // ==========================

        public ActionResult Receipt(int id)
        {
            Payment payment =
                db.Payments.Find(id);

            if (payment == null)
            {
                return HttpNotFound();
            }

            return View(payment);
        }

        // ==========================
        // DETAILS
        // ==========================

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

        // ==========================
        // PAYMENT HISTORY
        // ==========================

        public ActionResult PaymentHistory()
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

            var payments =
                db.Payments
                .Where(p =>
                    p.Policy.UserId == userId)
                .OrderByDescending(p =>
                    p.PaymentDate)
                .ToList();

            return View(payments);
        }

        // ==========================
        // DELETE - GET
        // ==========================

        [HttpGet]
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

        // ==========================
        // DELETE - POST
        // ==========================

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment =
                db.Payments.Find(id);

            if (payment != null)
            {
                db.Payments.Remove(payment);

                db.SaveChanges();
            }

            TempData["Message"] =
                "Payment Deleted Successfully";

            return RedirectToAction(
                "Index");
        }
    }
}