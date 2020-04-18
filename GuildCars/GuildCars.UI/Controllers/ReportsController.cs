using GuildCars.Data.Factories;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize]
    [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
    public class ReportsController : Controller
    {
        readonly ApplicationDbContext context = new ApplicationDbContext();
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Inventory()
        {
            InventoryReportsViewModels model = new InventoryReportsViewModels();
            
            var repo = VehiclesRepositoryFactory.GetDataRepository();
            model.newInventory = repo.GetInventoryReports(1);
            model.usedInventory = repo.GetInventoryReports(2);



            return View(model);
        }

        [HttpGet]
        public ActionResult Sales()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            return View(userManager.Users);
            
        }
    }
}