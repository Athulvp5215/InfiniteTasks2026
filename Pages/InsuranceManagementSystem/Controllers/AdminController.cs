using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        InsuranceManagementDBEntities2 db =
        new InsuranceManagementDBEntities2();

        // Admin Home Page
        // Opens Pending Users directly
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        // ================= PENDING USERS =================

        public ActionResult PendingUsers()
        {
            var users = db.Users
                          .Where(u => u.Status == "Pending")
                          .ToList();

            return View(users);
        }

        public ActionResult ApproveUser(int id)
        {
            User user = db.Users.Find(id);

            if (user != null)
            {
                user.Status = "Approved";
                db.SaveChanges();
            }

            return RedirectToAction("PendingUsers");
        }

        public ActionResult RejectUser(int id)
        {
            User user = db.Users.Find(id);

            if (user != null)
            {
                user.Status = "Rejected";
                db.SaveChanges();
            }

            return RedirectToAction("PendingUsers");
        }

        // ================= PENDING CLAIMS =================

        public ActionResult PendingClaims()
        {
            var claims = db.Claims
                           .Where(c => c.ClaimStatus == "Pending")
                           .ToList();

            return View(claims);
        }

        public ActionResult ApproveClaim(int id)
        {
            Claim claim = db.Claims.Find(id);

            if (claim != null)
            {
                claim.ClaimStatus = "Approved";
                db.SaveChanges();
            }

            return RedirectToAction("PendingClaims");
        }

        public ActionResult RejectClaim(int id)
        {
            Claim claim = db.Claims.Find(id);

            if (claim != null)
            {
                claim.ClaimStatus = "Rejected";
                db.SaveChanges();
            }

            return RedirectToAction("PendingClaims");
        }

        public ActionResult Policies()
        {
            return View(db.Policies.ToList());
        }

        public ActionResult Payments()
        {
            return View(db.Payments.ToList());
        }
    }


}
