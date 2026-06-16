using System;
using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        InsuranceManagementDBEntities db =
            new InsuranceManagementDBEntities();

        protected override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            if (Session["Role"] == null ||
                Session["Role"].ToString() != "Admin")
            {
                filterContext.Result =
                    RedirectToAction(
                        "Login",
                        "Account");
            }

            base.OnActionExecuting(filterContext);
        }

        // ======================
        // DASHBOARD
        // ======================

        public ActionResult Dashboard()
        {
            ViewBag.TotalUsers =
                db.Users.Count();

            ViewBag.TotalPolicies =
                db.Policies.Count();

            ViewBag.TotalClaims =
                db.Claims.Count();

            ViewBag.PendingClaims =
                db.Claims.Count(
                    x => x.ClaimStatus == "Pending");

            ViewBag.TotalPayments =
                db.Payments.Count();

            ViewBag.TotalVehicles =
                db.Vehicles.Count();

            ViewBag.TotalPlans =
                db.InsurancePlans.Count();

            return View();
        }

        public ActionResult Index()
        {
            return RedirectToAction(
                "Dashboard");
        }

        // ======================
        // USERS
        // ======================

        public ActionResult Users()
        {
            return View(
                db.Users.ToList());
        }

        public ActionResult DeleteUser(int id)
        {
            User user =
                db.Users.Find(id);

            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }

            return RedirectToAction(
                "Users");
        }

        // ======================
        // VEHICLES
        // ======================

        public ActionResult Vehicles()
        {
            return View(
                db.Vehicles.ToList());
        }

        public ActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle =
                db.Vehicles.Find(id);

            if (vehicle != null)
            {
                db.Vehicles.Remove(vehicle);

                db.SaveChanges();
            }

            return RedirectToAction(
                "Vehicles");
        }

        // ======================
        // POLICIES
        // ======================

        public ActionResult Policies()
        {
            return View(
                db.Policies.ToList());
        }

        public ActionResult PolicyDetails(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            return View(policy);
        }

        public ActionResult DeletePolicy(int id)
        {
            Policy policy =
                db.Policies.Find(id);

            if (policy != null)
            {
                db.Policies.Remove(policy);

                db.SaveChanges();
            }

            return RedirectToAction(
                "Policies");
        }

        // ======================
        // CLAIMS
        // ======================

        public ActionResult Claims()
        {
            return View(
                db.Claims.ToList());
        }

        public ActionResult PendingClaims()
        {
            return View(
                db.Claims
                .Where(x =>
                    x.ClaimStatus == "Pending")
                .ToList());
        }

        public ActionResult ApproveClaim(int id)
        {
            Claim claim =
                db.Claims.Find(id);

            if (claim != null)
            {
                claim.ClaimStatus =
                    "Approved";

                claim.ApprovedAmount =
                    claim.ClaimAmount;

                if (Session["AdminId"] != null)
                {
                    claim.ApprovedBy =
                        Convert.ToInt32(
                            Session["AdminId"]);
                }

                db.SaveChanges();
            }

            return RedirectToAction(
                "Claims");
        }

        public ActionResult RejectClaim(int id)
        {
            Claim claim =
                db.Claims.Find(id);

            if (claim != null)
            {
                claim.ClaimStatus =
                    "Rejected";

                claim.Remarks =
                    "Rejected By Admin";

                db.SaveChanges();
            }

            return RedirectToAction(
                "Claims");
        }

        // ======================
        // SET CLAIM AMOUNT
        // ======================

        [HttpGet]
        public ActionResult SetClaimAmount(int id)
        {
            Claim claim =
                db.Claims.Find(id);

            return View(claim);
        }

        [HttpPost]
        public ActionResult SetClaimAmount(
            int ClaimId,
            decimal ApprovedAmount)
        {
            Claim claim =
                db.Claims.Find(ClaimId);

            if (claim != null)
            {
                claim.ApprovedAmount =
                    ApprovedAmount;

                claim.ClaimStatus =
                    "Approved";

                if (Session["AdminId"] != null)
                {
                    claim.ApprovedBy =
                        Convert.ToInt32(
                            Session["AdminId"]);
                }

                db.SaveChanges();
            }

            return RedirectToAction(
                "Claims");
        }

        // ======================
        // PAYMENTS
        // ======================

        public ActionResult Payments()
        {
            return View(
                db.Payments.ToList());
        }

        // ======================
        // RENEWALS
        // ======================

        public ActionResult Renewals()
        {
            return View(
                db.Renewals.ToList());
        }

        // ======================
        // INSURANCE PLANS
        // ======================

        public ActionResult Plans()
        {
            return View(
                db.InsurancePlans.ToList());
        }

        // ======================
        // LOGOUT
        // ======================

        public ActionResult Logout()
        {
            Session.Clear();

            Session.Abandon();

            return RedirectToAction(
                "Login",
                "Account");
        }
    }
}