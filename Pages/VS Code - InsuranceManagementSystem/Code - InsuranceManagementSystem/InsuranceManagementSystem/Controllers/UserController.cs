using System;
using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class UserController : Controller
    {
        InsuranceManagementDBEntities db = new InsuranceManagementDBEntities();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserId"] == null)
            {
                filterContext.Result =RedirectToAction("Login","Account");
            }

            base.OnActionExecuting(filterContext);
        }

        // ======================
        // DASHBOARD
        // ======================

        public ActionResult Dashboard()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            ViewBag.TotalPolicies =
                db.Policies.Count(
                    p => p.UserId == userId);

            ViewBag.TotalVehicles =
                db.Vehicles.Count(
                    v => v.UserId == userId);

            ViewBag.TotalClaims =
                db.Claims.Count(
                    c => c.Policy.UserId == userId);

            ViewBag.TotalPayments =
                db.Payments.Count(
                    p => p.Policy.UserId == userId);

            return View();
        }

        // ======================
        // USER PROFILE
        // ======================

        public ActionResult UserProfile()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            User user = db.Users.Find(userId);

            return View(user);
        }

        // ======================
        // EDIT PROFILE
        // ======================

        [HttpGet]
        public ActionResult EditProfile()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            User user = db.Users.Find(userId);

            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            User existingUser = db.Users.Find(user.UserId);

            if (existingUser != null)
            {
                existingUser.FullName = user.FullName;

                existingUser.Email = user.Email;

                existingUser.PhoneNumber = user.PhoneNumber;

                existingUser.Address = user.Address;

                db.SaveChanges();

                TempData["Message"] = "Profile Updated Successfully";
            }

            return RedirectToAction("UserProfile");
        }

        // ======================
        // CHANGE PASSWORD
        // ======================

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string email,string newPassword,string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match";
                return View();
            }

            User user = db.Users
                          .FirstOrDefault(
                              x => x.Email == email);

            if (user == null)
            {
                ViewBag.Error = "Email not found";
                return View();
            }

            user.Password = newPassword;

            db.SaveChanges();

            ViewBag.Success =
                "Password Changed Successfully";

            return View();
        }

        // ======================
        // MY POLICIES
        // ======================

        public ActionResult MyPolicies()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            var policies =
                db.Policies
                .Where(p =>
                    p.UserId == userId)
                .ToList();

            return View(policies);
        }

        // ======================
        // MY VEHICLES
        // ======================

        public ActionResult MyVehicles()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            var vehicles =
                db.Vehicles
                .Where(v =>
                    v.UserId == userId)
                .ToList();

            return View(vehicles);
        }

        // ======================
        // MY CLAIMS
        // ======================

        public ActionResult MyClaims()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            var claims =
                db.Claims
                .Where(c =>
                    c.Policy.UserId == userId)
                .ToList();

            return View(claims);
        }

        // ======================
        // MY PAYMENTS
        // ======================

        public ActionResult MyPayments()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            var payments =
                db.Payments
                .Where(p =>
                    p.Policy.UserId == userId)
                .OrderByDescending(
                    p => p.PaymentDate)
                .ToList();

            return View(payments);
        }

        // ======================
        // LOGOUT
        // ======================

        public ActionResult Logout()
        {
            Session.Clear();

            Session.Abandon();

            return RedirectToAction("Login","Account");
        }
    }
}