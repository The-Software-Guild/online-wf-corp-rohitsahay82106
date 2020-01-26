using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Exercises.Models.Data;

namespace Exercises.Models.ViewModels
{
    public class StudentVM
    {
        
        public int studentId { get; set; }
        [Required(ErrorMessage = "Please enter Student's First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Student's Last Name")]
        public string LastName { get; set; }
        public decimal GPA { get; set; }
        [Required(ErrorMessage = "Please select Student's Major")]
        public int MajorId { get; set; }
              

        public List<SelectListItem> CourseItems { get; set; }
        public List<SelectListItem> MajorItems { get; set; }
        public List<int> SelectedCourseIds { get; set; }
        

        public StudentVM()
        {
            CourseItems = new List<SelectListItem>();
            MajorItems = new List<SelectListItem>();
            SelectedCourseIds = new List<int>();
            
        }

        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                CourseItems.Add(new SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseName
                });
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            foreach (var major in majors)
            {
                MajorItems.Add(new SelectListItem()
                {
                    Value = major.MajorId.ToString(),
                    Text = major.MajorName
                });
            }
        }

        
    }
}