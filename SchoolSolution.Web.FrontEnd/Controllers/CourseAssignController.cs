using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Web.FrontEnd.ViewModels;
using SchoolSolution.Infrastructure.Entities;
using Microsoft.AspNetCore.Routing;

namespace SchoolSolution.Web.FrontEnd.Controllers
{
    public class CourseAssignController : Controller
    {
        private CourseRepository crs = new CourseRepository();
        private CourseAssignRepository crsa = new CourseAssignRepository();
        private TeacherRepository th = new TeacherRepository();
        
        //GET : 
        public PartialViewResult Create(int id)
        {
            var model = new CourseAssignModel();
            model.Teacher = th.GetById(id);
            model.Courses = crs.GetAll();
            model.TeacherId = model.Teacher.Id;

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CourseAssignModel model)
        {
            try
            {
                var courses = new List<Course>();
                var teachId = model.TeacherId;
                courses = model.Courses;
                for (int i = 0; i < courses.Count(); i++)
                {
                    if (courses[i].CheckboxAnswer == true)
                    {
                        var csa = new CourseAssignement();
                        csa.CourseId = courses[i].Id;
                        csa.TeacherId = teachId;
                        crsa.Add(csa);

                    }

                }
                await crsa.SaveChangesAsync();
                return RedirectToAction("Details", new RouteValueDictionary(
                    new {controller="Teacher", action="Details", Id = model.TeacherId }));
            }
            catch (Exception)
            {

                throw;
            }

            
        }
        public PartialViewResult Edit(int id)
        {
            var model = new CourseAssignModel();
            model.Teacher = th.GetById(id);
            
            model.Courses = crs.GetAll();
            model.TeacherId = model.Teacher.Id;
            foreach (var item in model.Courses)
            {
                if (crsa.IfExists(item.Id,model.TeacherId))
                {
                    item.CheckboxAnswer = true;
                }
            }
            return PartialView(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CourseAssignModel model)
        {
            try
            {
                var courses = new List<Course>();
                var teacherId = model.TeacherId;
                courses = model.Courses;
                for (int i = 0; i < courses.Count(); i++)
                {
                    if (courses[i].CheckboxAnswer == true)
                    {
                        if (!crsa.IfExists(courses[i].Id, teacherId))
                        {
                            var csa = new CourseAssignement();
                            csa.CourseId = courses[i].Id;
                            csa.TeacherId = teacherId;
                            crsa.Add(csa); 
                        }

                    }
                    else
                    {
                        if (crsa.IfExists(courses[i].Id, teacherId))
                        {
                            var csa = await crsa.GetByIdAsync(courses[i].Id, teacherId);
                            if (csa == null)
                            {
                                return NotFound();
                            }
                            crsa.Remove(csa);
                        }
                    }

                }
                await crsa.SaveChangesAsync();
                return RedirectToAction("Details", new RouteValueDictionary(
                    new { controller = "Teacher", action = "Details", Id = model.TeacherId }));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}