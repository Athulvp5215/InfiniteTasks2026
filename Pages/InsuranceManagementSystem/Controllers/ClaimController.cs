using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class ClaimController : Controller
    {
        InsuranceManagementDBEntities1 db =
            new InsuranceManagementDBEntities1();

        // ================= HISTORY =================
        public ActionResult History()
        {
            var claims = db.Claims.ToList();
            return View(claims);
        }

        // ================= INDEX (optional) =================
        public ActionResult Index()
        {
            return RedirectToAction("History");
        }

        // ================= CREATE =================
        public ActionResult Create()
        {
            ViewBag.PolicyId =
                new SelectList(db.Policies, "PolicyId", "PolicyNumber");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Claim claim)
        {
            if (ModelState.IsValid)
            {
                claim.ClaimStatus = "Pending";

                db.Claims.Add(claim);
                db.SaveChanges();

                return RedirectToAction("History");
            }

            ViewBag.PolicyId =
                new SelectList(db.Policies,
                "PolicyId",
                "PolicyNumber",
                claim.PolicyId);

            return View(claim);
        }

        // ================= DETAILS =================
        public ActionResult Details(int id)
        {
            Claim claim = db.Claims.Find(id);

            if (claim == null)
            {
                return HttpNotFound();
            }

            return View(claim);
        }

        // ================= DELETE =================
        public ActionResult Delete(int id)
        {
            Claim claim = db.Claims.Find(id);

            if (claim == null)
            {
                return HttpNotFound();
            }

            return View(claim);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Claim claim = db.Claims.Find(id);

            if (claim == null)
            {
                return HttpNotFound();
            }

            db.Claims.Remove(claim);
            db.SaveChanges();

            return RedirectToAction("History");
        }

        // ================= APPROVE =================
        public ActionResult Approve(int id)
        {
            Claim claim = db.Claims.Find(id);

            if (claim == null)
            {
                return HttpNotFound();
            }

            claim.ClaimStatus = "Approved";
            db.SaveChanges();

            return RedirectToAction("History");
        }

        // ================= REJECT =================
        public ActionResult Reject(int id)
        {
            Claim claim = db.Claims.Find(id);

            if (claim == null)
            {
                return HttpNotFound();
            }

            claim.ClaimStatus = "Rejected";
            db.SaveChanges();

            return RedirectToAction("History");
        }
    }
}