using GuildCars.Data.Factories;
using GuildCars.Data.Repository_Prod;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize]
    [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
    public class AdminController : Controller
    {
        readonly ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Vehicles()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            AddVehicleViewModel addVehicleVM = new AddVehicleViewModel();
            var supportingDataRepo = SupportingDataRepositoryFactory.GetDataRepository();
            var vehiclesDataRepo = VehiclesRepositoryFactory.GetDataRepository();

            addVehicleVM.Make = new SelectList(vehiclesDataRepo.GetAllVehicleMake(), "VehicleMakeID", "VehicleMakeDesc");
            addVehicleVM.Type = new SelectList(supportingDataRepo.GetAllVehicleType(), "VehicleTypeID", "VehicleTypeDesc");
            addVehicleVM.BodyStyle = new SelectList(supportingDataRepo.GetAllVehicleBodyType(), "VehicleBodyTypeID", "VehicleBodyTypeDesc");
            addVehicleVM.Trans = new SelectList(supportingDataRepo.GetAllVehicleTransmissionType(), "VehicleTransmissionTypeID", "VehicleTransmissionTypeDesc");
            addVehicleVM.ExteriorColor = new SelectList(supportingDataRepo.GetAllVehicleExteriorColor(), "VehicleExteriorColorID", "VehicleExteriorColorDesc");
            addVehicleVM.InteriorColor = new SelectList(supportingDataRepo.GetAllVehicleInteriorColor(), "VehicleInteriorColorID", "VehicleInteriorColorDesc");

            addVehicleVM.vehicle = new Vehicles();


            return View(addVehicleVM);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleViewModel addVehicleVM)
        {
            if(ModelState.IsValid)
            {
                var vehiclesDataRepo = VehiclesRepositoryFactory.GetDataRepository();

                try
                {
                    if (addVehicleVM.ImageUpload != null && addVehicleVM.ImageUpload.ContentLength > 0)
                    {
                        addVehicleVM.vehicle.VehicleImageFileName = addVehicleVM.ImageUpload.FileName;
                        vehiclesDataRepo.AddNewVehicle(addVehicleVM.vehicle);

                        var savepath = Server.MapPath("~/Images");
                        string fileName = "inventory-" + addVehicleVM.vehicle.VehicleID;
                        string extension = Path.GetExtension(addVehicleVM.ImageUpload.FileName);
                        var filePath = Path.Combine(savepath, fileName + extension);
                        addVehicleVM.ImageUpload.SaveAs(filePath);

                        addVehicleVM.vehicle.VehicleImageFileName = Path.GetFileName(filePath);
                        vehiclesDataRepo.EditVehicle(addVehicleVM.vehicle);
                    }

                    return RedirectToAction("EditVehicle", new { id = addVehicleVM.vehicle.VehicleID });
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var supportingDataRepo = SupportingDataRepositoryFactory.GetDataRepository();
                var vehiclesDataRepo = VehiclesRepositoryFactory.GetDataRepository();

                addVehicleVM.Make = new SelectList(vehiclesDataRepo.GetAllVehicleMake(), "VehicleMakeID", "VehicleMakeDesc");
                addVehicleVM.Type = new SelectList(supportingDataRepo.GetAllVehicleType(), "VehicleTypeID", "VehicleTypeDesc");
                addVehicleVM.BodyStyle = new SelectList(supportingDataRepo.GetAllVehicleBodyType(), "VehicleBodyTypeID", "VehicleBodyTypeDesc");
                addVehicleVM.Trans = new SelectList(supportingDataRepo.GetAllVehicleTransmissionType(), "VehicleTransmissionTypeID", "VehicleTransmissionTypeDesc");
                addVehicleVM.ExteriorColor = new SelectList(supportingDataRepo.GetAllVehicleExteriorColor(), "VehicleExteriorColorID", "VehicleExteriorColorDesc");
                addVehicleVM.InteriorColor = new SelectList(supportingDataRepo.GetAllVehicleInteriorColor(), "VehicleInteriorColorID", "VehicleInteriorColorDesc");
                                                          
                return View(addVehicleVM);
            }

            
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            EditVehicleViewModel editVehicleVM = new EditVehicleViewModel();
            var supportingDataRepo = SupportingDataRepositoryFactory.GetDataRepository();
            var vehiclesDataRepo = VehiclesRepositoryFactory.GetDataRepository();

            editVehicleVM.Make = new SelectList(vehiclesDataRepo.GetAllVehicleMake(), "VehicleMakeID", "VehicleMakeDesc");
            editVehicleVM.Type = new SelectList(supportingDataRepo.GetAllVehicleType(), "VehicleTypeID", "VehicleTypeDesc");
            editVehicleVM.BodyStyle = new SelectList(supportingDataRepo.GetAllVehicleBodyType(), "VehicleBodyTypeID", "VehicleBodyTypeDesc");
            editVehicleVM.Trans = new SelectList(supportingDataRepo.GetAllVehicleTransmissionType(), "VehicleTransmissionTypeID", "VehicleTransmissionTypeDesc");
            editVehicleVM.ExteriorColor = new SelectList(supportingDataRepo.GetAllVehicleExteriorColor(), "VehicleExteriorColorID", "VehicleExteriorColorDesc");
            editVehicleVM.InteriorColor = new SelectList(supportingDataRepo.GetAllVehicleInteriorColor(), "VehicleInteriorColorID", "VehicleInteriorColorDesc");

            editVehicleVM.vehicle = vehiclesDataRepo.GetVehicleForEdit(id);
            editVehicleVM.VehicleMakeID = vehiclesDataRepo.GetVehicleMakeID(editVehicleVM.vehicle.VehicleMakeModelID);
            editVehicleVM.Model = new SelectList(vehiclesDataRepo.GetVehicleModels(editVehicleVM.VehicleMakeID), "VehicleMakeModelID", "VehicleModelDesc");

            return View(editVehicleVM);
        }

        [HttpPost]
        public ActionResult EditVehicle(EditVehicleViewModel editVehicleVM)
        {
            if (ModelState.IsValid)
            {
                var vehiclesDataRepo = VehiclesRepositoryFactory.GetDataRepository();

                try
                {
                    var oldVehicle = vehiclesDataRepo.GetVehicleForEdit(editVehicleVM.vehicle.VehicleID);
                    if (editVehicleVM.ImageUpload != null && editVehicleVM.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = "inventory-" + editVehicleVM.vehicle.VehicleID;
                        string extension = Path.GetExtension(editVehicleVM.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }    

                        editVehicleVM.ImageUpload.SaveAs(filePath);
                        editVehicleVM.vehicle.VehicleImageFileName = Path.GetFileName(filePath);
                    }
                    else
                    {
                        editVehicleVM.vehicle.VehicleImageFileName = oldVehicle.VehicleImageFileName;
                    }

                    vehiclesDataRepo.EditVehicle(editVehicleVM.vehicle);

                    return RedirectToAction("Vehicles");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var supportingDataRepo = SupportingDataRepositoryFactory.GetDataRepository();
                var vehiclesDataRepo = VehiclesRepositoryFactory.GetDataRepository();

                editVehicleVM.Make = new SelectList(vehiclesDataRepo.GetAllVehicleMake(), "VehicleMakeID", "VehicleMakeDesc");
                editVehicleVM.Type = new SelectList(supportingDataRepo.GetAllVehicleType(), "VehicleTypeID", "VehicleTypeDesc");
                editVehicleVM.BodyStyle = new SelectList(supportingDataRepo.GetAllVehicleBodyType(), "VehicleBodyTypeID", "VehicleBodyTypeDesc");
                editVehicleVM.Trans = new SelectList(supportingDataRepo.GetAllVehicleTransmissionType(), "VehicleTransmissionTypeID", "VehicleTransmissionTypeDesc");
                editVehicleVM.ExteriorColor = new SelectList(supportingDataRepo.GetAllVehicleExteriorColor(),"VehicleExteriorColorID", "VehicleExteriorColorDesc");
                editVehicleVM.InteriorColor = new SelectList(supportingDataRepo.GetAllVehicleInteriorColor(), "VehicleInteriorColorID", "VehicleInteriorColorDesc");

                editVehicleVM.Model = new SelectList(vehiclesDataRepo.GetVehicleModels(editVehicleVM.VehicleMakeID), "VehicleMakeModelID", "VehicleModelDesc");

                return View(editVehicleVM);
            }


        }

        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            var vehiclesDataRepo = VehiclesRepositoryFactory.GetDataRepository();
            try
            {
                var oldVehicle = vehiclesDataRepo.GetVehicleForEdit(id);
                vehiclesDataRepo.DeleteVehicle(id);

                var savepath = Server.MapPath("~/Images");
                var filePath = Path.Combine(savepath, oldVehicle.VehicleImageFileName);


                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Vehicles");
        }

        [HttpGet]
        public ActionResult Makes()
        {
            VehicleMakeViewModel model = new VehicleMakeViewModel();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            var AllMakes = VehiclesRepositoryFactory.GetDataRepository().GetAllVehicleMake();
            model.vehicleMakes = new List<MakeVM>();
                        
            foreach (var make in AllMakes)
            {
                var user = userManager.FindById(make.UserID);
                MakeVM row = new MakeVM();
                row.Make = make.VehicleMakeDesc;
                row.DateAdded = make.VehicleMakeAddedDate.Month + "/" + make.VehicleMakeAddedDate.Day + "/" + make.VehicleMakeAddedDate.Year;
                if (user != null)
                {
                    row.Email = user.Email;
                }
                
                model.vehicleMakes.Add(row);
            }


            model.newMake = new VehicleMake();

            return View(model);
        }

        [HttpPost]
        public ActionResult Makes(VehicleMakeViewModel vehicleMake)
        {
            vehicleMake.newMake.UserID = User.Identity.GetUserId();
            
            VehiclesRepositoryFactory.GetDataRepository().AddNewVehicleMake(vehicleMake.newMake);

            return RedirectToAction("Makes");
            
        }

        [HttpGet]
        public ActionResult Models()
        {
            VehicleModelViewModel model = new VehicleModelViewModel();
            var vehiclesDataRepo = VehiclesRepositoryFactory.GetDataRepository();
            var AllModels = vehiclesDataRepo.GetAllVehicleMakeModel();

            model.vehicleModels = new List<ModelVM>();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            foreach (var m in AllModels)
            {
                var user = userManager.FindById(m.UserID);
                ModelVM row = new ModelVM();
                row.Make = m.VehicleMakeDesc;
                row.Model = m.VehicleModelDesc;
                row.DateAdded = m.VehicleMakeModelAddedDate.Month + "/" + m.VehicleMakeModelAddedDate.Day + "/" + m.VehicleMakeModelAddedDate.Year;
                if (user != null)
                {
                    row.Email = user.Email;
                }

                model.vehicleModels.Add(row);
            }

            model.Make = new SelectList(vehiclesDataRepo.GetAllVehicleMake(), "VehicleMakeID", "VehicleMakeDesc");
            model.newModel = new VehicleMakeModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Models(VehicleModelViewModel model)
        {
            var vehiclesDataRepo = VehiclesRepositoryFactory.GetDataRepository();

            if (ModelState.IsValid)
            {
                model.newModel.UserID = User.Identity.GetUserId();
                try
                {
                    vehiclesDataRepo.AddNewVehicleMakeModel(model.newModel);
                    return RedirectToAction("Models");
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                model.Make = new SelectList(vehiclesDataRepo.GetAllVehicleMake(), "VehicleMakeID", "VehicleMakeDesc");
                return View(model);
            }

        }

        [HttpGet]
        public ActionResult AddUser()
        {
            AddUserViewModel model = new AddUserViewModel();
            model.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser
                { UserName = model.Email,
                  Email = model.Email,
                  EmailConfirmed = true,
                  FirstName = model.FirstName,
                  LastName = model.LastName,
                  
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user.Id, model.RoleName);
                    if (result1.Succeeded)
                    {
                        return RedirectToAction("EditUser", new { id = user.Id });
                    }
                    else
                    {
                        AddErrors(result1);
                    }
                    
                }
                else
                {
                    AddErrors(result);
                }
               
            }
            
            
            model.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View(model);
            
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            EditUserViewModel model = new EditUserViewModel();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = userManager.FindById(id);

            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.RoleName = userManager.GetRoles(id).FirstOrDefault();
            model.UserId = id;

            model.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
                return View(model);
            }

            bool AnyErrors = false;

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = await userManager.FindByIdAsync(model.UserId);
            if ((user.FirstName != model.FirstName) || (user.LastName != model.LastName))
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                var r1 = await userManager.UpdateAsync(user);
                if (!r1.Succeeded)
                {
                    AnyErrors = true;
                    AddErrors(r1);
                }
            }

            var role = await userManager.GetRolesAsync(model.UserId);
            if (role.FirstOrDefault() != model.RoleName)
            {
                var r2 = await userManager.RemoveFromRoleAsync(model.UserId, role.FirstOrDefault());
                if (!r2.Succeeded)
                {
                    AnyErrors = true;
                    AddErrors(r2);
                }
                else
                {
                    var r3 = await userManager.AddToRoleAsync(model.UserId, model.RoleName);
                    if (!r3.Succeeded)
                    {
                        AnyErrors = true;
                        AddErrors(r3);
                    }
                }
            }
            
            if (!string.IsNullOrEmpty(model.Password))
            {
                var r4 = await userManager.RemovePasswordAsync(model.UserId);
                if (!r4.Succeeded)
                {
                    AnyErrors = true;
                    AddErrors(r4);
                }
                else
                {
                    var r5 = await userManager.AddPasswordAsync(model.UserId, model.Password);
                    if (!r5.Succeeded)
                    {
                        AnyErrors = true;
                        AddErrors(r5);
                    }
                }
            }


            if (AnyErrors)
            {
                model.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
                return View(model);
            }
                                 
            return RedirectToAction("Users");
         
        }

        [HttpGet]
        public ActionResult Users()
        {
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var AllUsers = (from user in context.Users
                            select new
                            {
                                UserId = user.Id,
                                firstName = user.FirstName,
                                lastName = user.LastName,
                                email = user.Email,
                                RoleNames = (from userRole in user.Roles
                                             join role in context.Roles on userRole.RoleId
                                             equals role.Id
                                             select role.Name).ToList()
                            }).ToList().Select(p => new UsersViewModel()
                            {
                                UserID = p.UserId,
                                UserFirstName = p.firstName,
                                UserLastName = p.lastName,
                                UserEmail = p.email,
                                UserRole = p.RoleNames.FirstOrDefault()

                            });
                            
                            
            
            return View(AllUsers);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            var model = new SpecialsViewModel();

            model.specials = SpecialsRepositoryFactory.GetDataRepository().GetAllSpecials();
            model.newSpecial = new Specials();

            return View(model);
        }

        [HttpPost]
        public ActionResult Specials(SpecialsViewModel model)
        {
            var repo = SpecialsRepositoryFactory.GetDataRepository();
            if (ModelState.IsValid)
            {
                try
                {
                    repo.AddNewSpecials(model.newSpecial);
                    return RedirectToAction("Specials");
                }
                catch(Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                model.specials = SpecialsRepositoryFactory.GetDataRepository().GetAllSpecials();
                model.newSpecial = new Specials();

                return View(model);
            }            
        }

        [HttpGet]
        public ActionResult DeleteSpecials(int id)
        {
            var repo = SpecialsRepositoryFactory.GetDataRepository();
            try
            {
                repo.DeleteSpecials(id);
                return RedirectToAction("Specials");
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }


}