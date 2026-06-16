using System;
using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        InsuranceManagementDBEntities db = new InsuranceManagementDBEntities();

        // ==========================
        // LOGIN
        // ==========================

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and Password are required";

                return View();
            }

            // Admin Login

            var admin =
                db.Admins.FirstOrDefault(
                    a => a.Email == email &&
                         a.Password == password);

            if (admin != null)
            {
                Session["AdminId"] = admin.AdminId;
                Session["UserName"] = admin.AdminName;
                Session["Role"] = "Admin";

                return RedirectToAction("Dashboard","Admin");
            }

            // User Login

            var user =
                db.Users.FirstOrDefault(
                    u => u.Email == email &&
                         u.Password == password);

            if (user != null)
            {
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.FullName;
                Session["Role"] = "User";

                return RedirectToAction("Dashboard","User");
            }

            ViewBag.Error = "Invalid Email or Password";

            return View();
        }

        // ==========================
        // REGISTER
        // ==========================

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                bool emailExists =
                    db.Users.Any(x =>
                        x.Email == user.Email);

                if (emailExists)
                {
                    ViewBag.Error = "Email already exists";

                    return View(user);
                }

                bool phoneExists =
                    db.Users.Any(x =>
                        x.PhoneNumber ==
                        user.PhoneNumber);

                if (phoneExists)
                {
                    ViewBag.Error = "Phone Number already exists";

                    return View(user);
                }

                user.Role = "User";
                user.Status = "Approved";
                user.CreatedDate = DateTime.Now;

                db.Users.Add(user);

                db.SaveChanges();

                TempData["Message"] = "Registration Successful";

                return RedirectToAction("Login");
            }

            return View(user);
        }

        // ==========================
        // FORGOT PASSWORD
        // ==========================

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string policyNumber,string newPassword)
        {
            var policy =
                db.Policies.FirstOrDefault(
                    p => p.PolicyNumber ==
                         policyNumber);

            if (policy == null)
            {
                ViewBag.Error ="Invalid Policy Number";

                return View();
            }

            var user =
                db.Users.Find(policy.UserId);

            if (user == null)
            {
                ViewBag.Error =
                    "User Not Found";

                return View();
            }

            user.Password =
                newPassword;

            db.SaveChanges();

            TempData["Message"] =
                "Password Changed Successfully";

            return RedirectToAction(
                "Login");
        }

        // ==========================
        // LOGOUT
        // ==========================

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction(
                "Login");
        }
    }
}