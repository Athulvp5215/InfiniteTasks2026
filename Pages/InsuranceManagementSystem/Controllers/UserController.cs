using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class UserController : Controller
    {
        InsuranceManagementDBEntities1 db =
        new InsuranceManagementDBEntities1();


    public ActionResult Index()
        {
            var users = db.Users.ToList();

            return View(users);
        }

        public ActionResult Create()
        {
            ViewBag.RoleList =
                new SelectList(
                    new[] { "Admin", "User" });

            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Status = "Pending";

                db.Users.Add(user);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.RoleList =
                new SelectList(
                    new[] { "Admin", "User" });

            return View(user);
        }

        public ActionResult Edit(int id)
        {
            User user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.RoleList =
                new SelectList(
                    new[] { "Admin", "User" },
                    user.Role);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State =
                    System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.RoleList =
                new SelectList(
                    new[] { "Admin", "User" },
                    user.Role);

            return View(user);
        }

        public ActionResult Details(int id)
        {
            User user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);

            if (user != null)
            {
                db.Users.Remove(user);

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult PendingUsers()
        {
            var users = db.Users
                          .Where(u => u.Status == "Pending")
                          .ToList();

            return View(users);
        }

        public ActionResult Approve(int id)
        {
            User user = db.Users.Find(id);

            if (user != null)
            {
                user.Status = "Approved";

                db.SaveChanges();
            }

            return RedirectToAction("PendingUsers");
        }

        public ActionResult Reject(int id)
        {
            User user = db.Users.Find(id);

            if (user != null)
            {
                user.Status = "Rejected";

                db.SaveChanges();
            }

            return RedirectToAction("PendingUsers");
        }
    }


}
