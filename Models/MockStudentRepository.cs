using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleProject.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;

        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                new Student(){Id=1, Name="abc", Department="CSE"},
                new Student(){Id=2, Name="tamim", Department="SWE"},
                new Student(){Id=3, Name="arefin", Department="EEE"}
            };
        }

        public Student GetStudent(int Id)
        {
            return _studentList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
