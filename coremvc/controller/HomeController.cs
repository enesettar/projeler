using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coremvc.models;


namespace coremvc.controller
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var course = new Course();
            course.ID = 1;
            course.Name = "asp net core";
            return View(course);
        }
    }
}
