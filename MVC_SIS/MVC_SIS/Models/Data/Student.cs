using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public decimal GPA { get; set; }
        public Address Address { get; set; }
        [Required]
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
    }
}