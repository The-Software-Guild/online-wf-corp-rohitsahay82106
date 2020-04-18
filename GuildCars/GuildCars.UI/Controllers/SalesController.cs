using GuildCars.Data.Factories;
using GuildCars.UI.Models;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuildCars.Models.Tables;
using Microsoft.AspNet.Identity;
using System.Security.Permissions;

namespace GuildCars.UI.Controllers
{
    [Authorize]
    [PrincipalPermission(SecurityAction.Demand, Role = "Sales")]
    [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
    public class SalesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Purchase(int id)
        {
            PurchaseViewModel purchaseVM = new PurchaseViewModel();
            var supportingDataRepo = SupportingDataRepositoryFactory.GetDataRepository();
            
            purchaseVM.VehicleDetails = VehiclesRepositoryFactory.GetDataRepository().GetVehicleByID(id);

            purchaseVM.states = new SelectList(supportingDataRepo.GetAllStates(), "StateID", "StateID");
            purchaseVM.purchaseTypes = new SelectList(supportingDataRepo.GetAllPurchaseType(), "PurchaseTypeID", "PurchaseTypeDesc");

            purchaseVM.vehiclePurchaseData = new VehiclePurchaseData();
            purchaseVM.vehiclePurchaseData.VehicleID = id;

            return View(purchaseVM);
            
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel purchaseVM)
        {
            if(ModelState.IsValid)
            {
                try
                {

                    purchaseVM.vehiclePurchaseData.UserID = User.Identity.GetUserId();
                    SalesRepositoryFactory.GetDataRepository().PurchaseVehicle(purchaseVM.vehiclePurchaseData);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }
            else
            {
                var supportingDataRepo = SupportingDataRepositoryFactory.GetDataRepository();
                purchaseVM.states = new SelectList(supportingDataRepo.GetAllStates(), "StateID", "StateID");
                purchaseVM.purchaseTypes = new SelectList(supportingDataRepo.GetAllPurchaseType(), "PurchaseTypeID", "PurchaseTypeDesc");
                purchaseVM.VehicleDetails = VehiclesRepositoryFactory.GetDataRepository().GetVehicleByID(purchaseVM.vehiclePurchaseData.VehicleID);

                return View(purchaseVM);
            }
        }
    }
}