using System;
using System.Linq;
using System.Web.Mvc;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Controllers
{
    public class VehicleController : Controller
    {
        InsuranceManagementDBEntities db =
            new InsuranceManagementDBEntities();

        protected override void OnActionExecuting(
            ActionExecutingContext filterContext)
        {
            if (Session["UserId"] == null &&
                Session["Role"] == null)
            {
                filterContext.Result =
                    RedirectToAction(
                        "Login",
                        "Account");
            }

            base.OnActionExecuting(filterContext);
        }

        // ======================
        // ALL VEHICLES
        // ======================

        public ActionResult Index()
        {
            return View(
                db.Vehicles.ToList());
        }

        // ======================
        // MY VEHICLES
        // ======================

        public ActionResult MyVehicles()
        {
            int userId =
                Convert.ToInt32(
                    Session["UserId"]);

            var vehicles =
                db.Vehicles
                .Where(v =>
                    v.UserId == userId)
                .ToList();

            return View(vehicles);
        }

        // ======================
        // DETAILS
        // ======================

        public ActionResult Details(int id)
        {
            Vehicle vehicle =
                db.Vehicles.Find(id);

            if (vehicle == null)
            {
                return HttpNotFound();
            }

            return View(vehicle);
        }

        // ======================
        // CREATE
        // ======================

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                bool vehicleExists =
                    db.Vehicles.Any(v =>
                        v.VehicleNumber ==
                        vehicle.VehicleNumber);

                if (vehicleExists)
                {
                    ViewBag.Error =
                        "Vehicle Number Already Exists";

                    return View(vehicle);
                }

                bool engineExists =
                    db.Vehicles.Any(v =>
                        v.EngineNumber ==
                        vehicle.EngineNumber);

                if (engineExists)
                {
                    ViewBag.Error =
                        "Engine Number Already Exists";

                    return View(vehicle);
                }

                bool chassisExists =
                    db.Vehicles.Any(v =>
                        v.ChassisNumber ==
                        vehicle.ChassisNumber);

                if (chassisExists)
                {
                    ViewBag.Error =
                        "Chassis Number Already Exists";

                    return View(vehicle);
                }

                vehicle.UserId =
                    Convert.ToInt32(
                        Session["UserId"]);

                db.Vehicles.Add(vehicle);

                db.SaveChanges();

                TempData["Message"] =
                    "Vehicle Added Successfully";

                return RedirectToAction(
                    "MyVehicles");
            }

            return View(vehicle);
        }

        // ======================
        // EDIT
        // ======================

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Vehicle vehicle =
                db.Vehicles.Find(id);

            if (vehicle == null)
            {
                return HttpNotFound();
            }

            return View(vehicle);
        }

        [HttpPost]
        public ActionResult Edit(Vehicle vehicle)
        {
            Vehicle existingVehicle =
                db.Vehicles.Find(
                    vehicle.VehicleId);

            if (existingVehicle == null)
            {
                return HttpNotFound();
            }

            existingVehicle.VehicleNumber =
                vehicle.VehicleNumber;

            existingVehicle.VehicleType =
                vehicle.VehicleType;

            existingVehicle.VehicleModel =
                vehicle.VehicleModel;

            existingVehicle.Manufacturer =
                vehicle.Manufacturer;

            existingVehicle.ManufactureYear =
                vehicle.ManufactureYear;

            existingVehicle.EngineNumber =
                vehicle.EngineNumber;

            existingVehicle.ChassisNumber =
                vehicle.ChassisNumber;

            db.SaveChanges();

            TempData["Message"] =
                "Vehicle Updated Successfully";

            return RedirectToAction(
                "MyVehicles");
        }
    }
}