using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;
using System.Data.Entity;

namespace InsuranceManagementSystem.Controllers
{
    public class InsurancePlanController : Controller
    {
        InsuranceManagementDBEntities db =
            new InsuranceManagementDBEntities();

        // ======================
        // LIST ALL PLANS
        // ======================

        public ActionResult Index()
        {
            return View(
                db.InsurancePlans.ToList());
        }

        // ======================
        // PLAN DETAILS
        // ======================

        public ActionResult Details(int id)
        {
            InsurancePlan plan =
                db.InsurancePlans.Find(id);

            if (plan == null)
            {
                return HttpNotFound();
            }

            return View(plan);
        }

        // ======================
        // CREATE PLAN
        // ======================

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(
            InsurancePlan plan)
        {
            if (ModelState.IsValid)
            {
                bool exists =
                    db.InsurancePlans.Any(
                        p => p.PlanName ==
                             plan.PlanName);

                if (exists)
                {
                    ViewBag.Error =
                        "Plan already exists";

                    return View(plan);
                }

                db.InsurancePlans.Add(plan);

                db.SaveChanges();

                TempData["Message"] =
                    "Insurance Plan Added Successfully";

                return RedirectToAction(
                    "Index");
            }

            return View(plan);
        }

        // ======================
        // EDIT PLAN
        // ======================

        [HttpGet]
        public ActionResult Edit(int id)
        {
            InsurancePlan plan =
                db.InsurancePlans.Find(id);

            if (plan == null)
            {
                return HttpNotFound();
            }

            return View(plan);
        }

        [HttpPost]
        public ActionResult Edit(
            InsurancePlan plan)
        {
            if (ModelState.IsValid)
            {
                InsurancePlan existingPlan =
                    db.InsurancePlans.Find(
                        plan.PlanId);

                if (existingPlan != null)
                {
                    existingPlan.PlanName =
                        plan.PlanName;

                    existingPlan.BasePremium =
                        plan.BasePremium;

                    existingPlan.Description =
                        plan.Description;

                    db.SaveChanges();

                    TempData["Message"] =
                        "Insurance Plan Updated Successfully";
                }

                return RedirectToAction(
                    "Index");
            }

            return View(plan);
        }

        // ======================
        // DELETE PLAN
        // ======================

        [HttpGet]
        public ActionResult Delete(int id)
        {
            InsurancePlan plan =
                db.InsurancePlans.Find(id);

            if (plan == null)
            {
                return HttpNotFound();
            }

            return View(plan);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            InsurancePlan plan =
                db.InsurancePlans.Find(id);

            if (plan != null)
            {
                bool policyExists =
                    db.Policies.Any(
                        p => p.PlanId == id);

                if (policyExists)
                {
                    TempData["Error"] =
                        "Plan cannot be deleted because policies are using it.";

                    return RedirectToAction(
                        "Index");
                }

                db.InsurancePlans.Remove(plan);

                db.SaveChanges();

                TempData["Message"] =
                    "Insurance Plan Deleted Successfully";
            }

            return RedirectToAction(
                "Index");
        }
    }
}