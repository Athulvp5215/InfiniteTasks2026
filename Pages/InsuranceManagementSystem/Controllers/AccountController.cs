using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        InsuranceManagementDBEntities2 db =
            new InsuranceManagementDBEntities2();



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(
            u => u.Email == email &&
            u.Password == password);


if (user == null)
            {
                ViewBag.Error = "Invalid Email or Password";
                return View();
            }

            if (user.Role != "Admin" &&
                user.Status != "Approved")
            {
                ViewBag.Error =
                    "Your account is waiting for admin approval.";

                return View();
            }

            Session["UserId"] = user.UserId;
            Session["UserName"] = user.FullName;
            Session["Role"] = user.Role;

            if (user.Role == "Admin")
            {
                return RedirectToAction(
                    "Dashboard",
                    "Admin");
            }

            return RedirectToAction(
                "Dashboard",
                "User");


}


        public ActionResult Register()
        {
            ViewBag.RoleList =
                new SelectList(
                    new[] { "User" });

            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "User";
                user.Status = "Pending";

                db.Users.Add(user);
                db.SaveChanges();

                TempData["Message"] =
                    "Registration successful. Wait for admin approval.";

                return RedirectToAction("Login");
            }

            return View(user);
        }



        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");
        }
    }
}