using System;
using System.Collections.Generic;
using CursoOnline.Domain.DTOs;
using CursoOnline.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Web.Controllers
{
    public class CourseController : Controller
    {
        public readonly CourseInserter _CourseInserter;

        public CourseController(CourseInserter courseInserter)
        {
            _CourseInserter = courseInserter;
        }

        public IActionResult Index()
        {
            var courses = new List<CourseDto>();

            return View("List",courses);
        }

        public IActionResult New()
        {
            return View("NewOrEdit", new CourseDto());
        }

        public IActionResult Save(CourseDto model)
        {
            _CourseInserter.Insert(model);
            return Ok();
        }
    }
}
