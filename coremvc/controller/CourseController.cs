using coremvc.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coremvc.controller
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult MyView()
        {
            return View();
        }
        [HttpGet]
        public ViewResult apply()
        {
            return View();
        }
        [HttpPost]
        public ViewResult apply(student student)
        {
            if (ModelState.IsValid)// bu sonradan eklendi, validationlara bakar eğer geçen varsa devam ettirir
            {
                repo.addstudent(student);
                return View("thanks", student)
            }
            else
            {
                return View();
            }
        }
        public ViewResult list()
        {
           var liste= repo.students.Where(i => i.willattend = true);
            return View(liste);
        }
        
    }
}
