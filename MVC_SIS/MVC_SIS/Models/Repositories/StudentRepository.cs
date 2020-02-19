using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.Repositories
{
    public class StudentRepository
    {
        private static List<Student> _students;

        static StudentRepository()
        {
            // sample data
            _students = new List<Student>
            {
                new Student {
                    StudentId=1,
                    FirstName="John",
                    LastName="Doe",
                    GPA=2.5M,
                    Major=new Major { MajorId=1,  MajorName="Art" },
                    Address=new Address {
                        AddressId=1,
                        Street1="123 Main St",
                        City="Akron",
                        State=new State {
                            StateAbbreviation="OH",
                            StateName="Ohio"},
                        PostalCode="44311"
                    },
                    Courses=new List<Course>
                    {
                        new Course { CourseId=1, CourseName="Art History" },
                        new Course { CourseId=8, CourseName="Photography" }
                    }
                },
                new Student {
                    StudentId=2,
                    FirstName="Jane",
                    LastName="Wicks",
                    GPA=3.5M,
                    Major=new Major { MajorId=2,  MajorName="Business" },
                    Address=new Address {
                        AddressId=2,
                        Street1="422 Oak St",
                        Street2="Apartment 305A",
                        City="Mineapolis",
                        State=new State {
                            StateAbbreviation="MN",
                            StateName="Minnesota"},
                        PostalCode="55401"
                    },
                    Courses=new List<Course>
                    {
                        new Course { CourseId=2, CourseName="Accounting 101" },
                        new Course { CourseId=4, CourseName="Business Law" },
                        new Course { CourseId=6, CourseName="Economics 101" },
                    }
                },
                new Student {
                    StudentId=3,
                    FirstName="Megan",
                    LastName="Smith",
                    Major=new Major { MajorId=3,  MajorName="Computer Science" }
                },
            };
        }

        public static IEnumerable<Student> GetAll()
        {
            return _students.OrderBy(s=> s.StudentId);
        }

        public static Student Get(int studentId)
        {
            return _students.FirstOrDefault(s => s.StudentId == studentId);
        }

        public static void Add(Student state)
        {
            state.StudentId = _students.Max(s => s.StudentId) + 1;
            _students.Add(state);
        }

        public static void Edit(Student editStudent)
        {
            Student oldStudent = Get(editStudent.StudentId);
            editStudent.Address = oldStudent.Address;

            _students.RemoveAll(s => s.StudentId == editStudent.StudentId);
            _students.Add(editStudent);
        }

        public static void UpdateAddress(Address address,int id)
        {
            Student student = Get(id);
            student.Address = address;
            student.Address.AddressId = id;

            _students.RemoveAll(s => s.StudentId == student.StudentId);
            _students.Add(student);
        }

        public static void Delete(int studentId)
        {
            _students.RemoveAll(s => s.StudentId == studentId);
        }

        public static void SaveAddress(int studentId, Address address)
        {
            var selectedStudent = _students.First(s => s.StudentId == studentId);
            selectedStudent.Address = address;
        }
    }
}