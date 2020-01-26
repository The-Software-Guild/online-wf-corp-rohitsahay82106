using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    student.Courses.Add(CourseRepository.Get(id));

                student.Major = MajorRepository.Get(studentVM.MajorId);
                student.FirstName = studentVM.FirstName;
                student.LastName = studentVM.LastName;
                student.GPA = studentVM.GPA;

                StudentRepository.Add(student);

                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View(studentVM);
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editVM = new EditVM();
            editVM.StudentVM = new StudentVM();
            
            editVM.StudentVM.SetCourseItems(CourseRepository.GetAll());
            editVM.StudentVM.SetMajorItems(MajorRepository.GetAll());
            Student student = StudentRepository.Get(id);

            editVM.StudentVM.studentId = student.StudentId;
            editVM.StudentVM.FirstName = student.FirstName;
            editVM.StudentVM.LastName = student.LastName;
            editVM.StudentVM.GPA = student.GPA;
            editVM.StudentVM.MajorId = student.Major.MajorId;

            if (student.Courses != null)
            {
                foreach (var c in student.Courses)
                    editVM.StudentVM.SelectedCourseIds.Add(c.CourseId);
            }

            editVM.AddressVM = new AddressVM();
            editVM.AddressVM.studentid = student.StudentId;
            editVM.AddressVM.SetStateItems(StateRepository.GetAll());
            if (student.Address != null)
            {
                editVM.AddressVM.Street1 = student.Address.Street1;
                editVM.AddressVM.Street2 = student.Address.Street2;
                editVM.AddressVM.City = student.Address.City;
                editVM.AddressVM.PostalCode = student.Address.PostalCode;

                if (student.Address.State != null)
                {
                    editVM.AddressVM.StateAbbrv = student.Address.State.StateAbbreviation;
                }
            }

            
            


            return View(editVM);

        }

        [HttpPost]
        public ActionResult Edit(EditVM editVM)
        {
            StudentVM studentVM = editVM.StudentVM;
            AddressVM addressVM = editVM.AddressVM;
            
            if (ModelState.IsValid)
            {
                Student student = new Student();
                student.StudentId = studentVM.studentId;
                student.Courses = new List<Course>();
                foreach (var id in studentVM.SelectedCourseIds)
                    student.Courses.Add(CourseRepository.Get(id));
           
                student.Major = MajorRepository.Get(studentVM.MajorId);
                student.FirstName = studentVM.FirstName;
                student.LastName = studentVM.LastName;
                student.GPA = studentVM.GPA;

                StudentRepository.Edit(student);

                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                addressVM.SetStateItems(StateRepository.GetAll());
                

                editVM.StudentVM = studentVM;
                editVM.AddressVM = addressVM;
                return View(editVM);
            }
            
        }

        [HttpPost]
        public ActionResult UpdateAddress(EditVM editVM)
        {
            AddressVM addressVM = editVM.AddressVM;
            StudentVM studentVM = editVM.StudentVM;
            
            if (ModelState.IsValid)
            {
                Address address = new Address();
                address.AddressId = addressVM.studentid;
                address.Street1 = addressVM.Street1;
                address.Street2 = addressVM.Street2;
                address.City = addressVM.City;
                address.State = StateRepository.Get(addressVM.StateAbbrv);
                address.PostalCode = addressVM.PostalCode;
                StudentRepository.UpdateAddress(address, addressVM.studentid);

                return RedirectToAction("List");
            }
            else
            {
                addressVM.SetStateItems(StateRepository.GetAll());
                Student student = StudentRepository.Get(addressVM.studentid);
                              

                if (student.Courses != null)
                {
                  foreach (var c in student.Courses)
                         studentVM.SelectedCourseIds.Add(c.CourseId);
                }

                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                
                editVM.StudentVM = studentVM;
                editVM.AddressVM = addressVM;
                return View("Edit",editVM);
            }
            
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }


        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}