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

        public Student Add(Student student)
        {
            student.Id = _studentList.Max(e => e.Id) + 1;
            _studentList.Add(student);
            return student;
        }

        public void Delete(Student student)
        {
            _studentList.Remove(student);
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _studentList;
        }

        public Student GetStudent(int Id)
        {
            return _studentList.FirstOrDefault(e => e.Id == Id);
        }

        public Student Update(Student student)
        {
            //_studentList[_studentList.Find(ind => ind.Equals(student))] = student;
            _studentList[student.Id - 1] = student;
            return student;
        }
    }
}
