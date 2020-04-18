using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuildCars.UI.Models;
using GuildCars.Models.Tables;
using GuildCars.Data.Factories;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel();
            homeIndexViewModel.Specials = SpecialsRepositoryFactory.GetDataRepository().GetAllSpecials();
            homeIndexViewModel.FeaturedVehicles = VehiclesRepositoryFactory.GetDataRepository().GetAllFeaturedVehicles();

            return View(homeIndexViewModel);
        }

        public ActionResult Specials()
        {

            var Specials = SpecialsRepositoryFactory.GetDataRepository().GetAllSpecials();
            
            return View(Specials);
        }

        [HttpGet]
        public ActionResult Contact(string id)
        {
            var model = new ContactViewModel();
            model.Inquiries = new GeneralInquiries();
            if (!string.IsNullOrEmpty(id))
            {
                model.Inquiries.GeneralInquiryMessage = id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    SalesRepositoryFactory.GetDataRepository().LogGeneralInquiry(model.Inquiries);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return View(model);
            }
            
        }
    }
}