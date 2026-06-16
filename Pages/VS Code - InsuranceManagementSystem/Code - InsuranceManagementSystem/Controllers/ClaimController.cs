using System;
using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class ClaimController : Controller
    {
        InsuranceManagementDBEntities db =
            new InsuranceManagementDBEntities();

        // ======================
        // MY CLAIMS
        // ======================

        public ActionResult MyClaims()
        {
            int userId =
                Convert.ToInt32(
                    Session["UserId"]);

            var claims =
                db.Claims
                .Where(c =>
                    c.Policy.UserId == userId)
                .ToList();

            return View(claims);
        }

        // ======================
        // CREATE CLAIM
        // ======================

        [HttpGet]
        public ActionResult Create()
        {
            int userId =
                Convert.ToInt32(
                    Session["UserId"]);

            ViewBag.PolicyId =
                new SelectList(
                    db.Policies
                    .Where(p =>
                        p.UserId == userId &&
                        p.PolicyStatus == "Active"),
                    "PolicyId",
                    "PolicyNumber");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Claim claim)
        {
            if (ModelState.IsValid)
            {
                claim.ClaimDate =
                    DateTime.Now;

                claim.ClaimStatus =
                    "Pending";

                claim.ApprovedAmount =
                    0;

                claim.ApprovedBy =
                    null;

                db.Claims.Add(claim);

                db.SaveChanges();

                TempData["Message"] =
                    "Claim Submitted Successfully";

                return RedirectToAction(
                    "MyClaims");
            }

            int userId =
                Convert.ToInt32(
                    Session["UserId"]);

            ViewBag.PolicyId =
                new SelectList(
                    db.Policies
                    .Where(p =>
                        p.UserId == userId),
                    "PolicyId",
                    "PolicyNumber",
                    claim.PolicyId);

            return View(claim);
        }

        // ======================
        // CLAIM DETAILS
        // ======================

        public ActionResult Details(int id)
        {
            Claim claim =
                db.Claims.Find(id);

            if (claim == null)
            {
                return HttpNotFound();
            }

            return View(claim);
        }

        // ======================
        // EDIT CLAIM
        // ======================

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Claim claim =
                db.Claims.Find(id);

            if (claim == null)
            {
                return HttpNotFound();
            }

            if (claim.ClaimStatus != "Pending")
            {
                TempData["Message"] =
                    "Approved claims cannot be edited";

                return RedirectToAction(
                    "MyClaims");
            }

            return View(claim);
        }

        [HttpPost]
        public ActionResult Edit(Claim claim)
        {
            if (ModelState.IsValid)
            {
                Claim existingClaim =
                    db.Claims.Find(
                        claim.ClaimId);

                if (existingClaim != null)
                {
                    existingClaim.ClaimAmount =
                        claim.ClaimAmount;

                    existingClaim.ClaimReason =
                        claim.ClaimReason;

                    db.SaveChanges();
                }

                return RedirectToAction(
                    "MyClaims");
            }

            return View(claim);
        }

        // ======================
        // DELETE CLAIM
        // ======================

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Claim claim =
                db.Claims.Find(id);

            if (claim == null)
            {
                return HttpNotFound();
            }

            return View(claim);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Claim claim =
                db.Claims.Find(id);

            if (claim != null)
            {
                if (claim.ClaimStatus == "Pending")
                {
                    db.Claims.Remove(claim);

                    db.SaveChanges();
                }
            }

            return RedirectToAction(
                "MyClaims");
        }

        // ======================
        // ALL CLAIMS (ADMIN)
        // ======================

        public ActionResult Index()
        {
            return View(
                db.Claims.ToList());
        }
    }
}