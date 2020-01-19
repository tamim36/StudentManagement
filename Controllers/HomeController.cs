using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Controllers
{
    public class HomeController : Controller
    {
        private IStudentRepository _studentRepository;

        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public string index()
        {
            return _studentRepository.GetStudent(1).Name;
        }
    }
}
