using GuildCars.Data.Factories;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var vehicleDetails = VehiclesRepositoryFactory.GetDataRepository().GetVehicleByID(id);
            return View(vehicleDetails);
        }

    }
}