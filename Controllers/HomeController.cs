using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleProject.Models;
using ExampleProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //[Route("~/Home")]
        //[Route("~/")]
        public ViewResult Index()
        {
            var students = _studentRepository.GetAllStudent();
            return View(students);
        }

        //[Route("{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                student = _studentRepository.GetStudent(id??1),
                PageTitle = "Page Title = Student Details"
            };

            return View(homeDetailsViewModel);
        }

        //[Route("~/home/create")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        //[Route("~/home/create")]
        [HttpPost]
        public RedirectToActionResult Create(Student student)
        {
            Student newStudent = _studentRepository.Add(student);
            return RedirectToAction("details", new { id = newStudent.Id });
        }

        //[Route("~/home/update/{id}")]
        [HttpGet]
        public ViewResult Update(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                student = _studentRepository.GetStudent(id),
                PageTitle = "Page Title = Student Update"
            };

            return View(homeDetailsViewModel);
        }

        //[Route("~/home/update")]
        [HttpPost]
        public RedirectToActionResult Update(Student student, int id)
        {
            Student newStudent = _studentRepository.Update(student);
            return RedirectToAction("details", new { id = newStudent.Id });
        }

        //[Route("~/home/delete/{id}")]
        public RedirectToActionResult Delete(int id)
        {

            Student student = _studentRepository.GetStudent(id);
            _studentRepository.Delete(student);
            return RedirectToAction("");
        }
    }
}
