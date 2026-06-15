using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class UserController : Controller
    {
        InsuranceManagementDBEntities2 db =
        new InsuranceManagementDBEntities2();


    // ================= USER DASHBOARD =================

    public ActionResult Dashboard()
        {
            return View();
        }

        // ================= USER MANAGEMENT =================

        public ActionResult Index()
        {
            var users = db.Users.ToList();

            return View(users);
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
    }

}
