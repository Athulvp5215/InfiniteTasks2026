using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class ClaimController : Controller
    {
        InsuranceManagementDBEntities2 db =
            new InsuranceManagementDBEntities2();

        public ActionResult Index()
        {
            var claims = db.Claims.ToList();

            return View(claims);
        }

        public ActionResult Create()
        {
            ViewBag.PolicyId =
                new SelectList(
                    db.Policies,
                    "PolicyId",
                    "PolicyNumber");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Claim claim)
        {
            if (ModelState.IsValid)
            {
                claim.ClaimStatus = "Pending";

                db.Claims.Add(claim);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(claim);
        }

        public ActionResult Details(int id)
        {
            Claim claim =
                db.Claims.Find(id);

            return View(claim);
        }

  public ActionResult Delete(int id)
        {
            Claim claim =
                db.Claims.Find(id);

            return View(claim);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Claim claim =
                db.Claims.Find(id);

            db.Claims.Remove(claim);

            db.SaveChanges();

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }
    }
}