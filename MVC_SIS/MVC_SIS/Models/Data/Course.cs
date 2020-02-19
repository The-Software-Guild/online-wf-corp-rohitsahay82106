using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.Data
{
    public class Course
    {
        [Required]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please enter Course Name")]
        public string CourseName { get; set; }
    }
}