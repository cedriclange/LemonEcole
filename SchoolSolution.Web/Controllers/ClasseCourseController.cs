using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSolution.Web.ViewModels;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Repositories;
using Microsoft.AspNetCore.Routing;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Web.Controllers
{
    public class ClasseCourseController : Controller
    {
        IClasseCourse cc;        
        IClass cls;    
        ICourse crs;
        public ClasseCourseController(ICourse _crs, IClass _cls
            , IClasseCourse _cc)
        {
            cls = _cls;
            cc = _cc;
            crs = _crs;
           
        }

        public PartialViewResult Create(int id)
        {
            var model = new ClasseCourseModel();
            model.Classe = cls.GetById(id);
            model.ClassId = model.Classe.Id;
            model.Courses = crs.GetAll();
            return PartialView(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClasseCourseModel model)
        {
            try
            {
                var courses = new List<Course>();
                var ClassId = model.ClassId;
                courses = model.Courses;
                for (int i = 0; i < courses.Count(); i++)
                {
                    if (courses[i].CheckboxAnswer == true)
                    {
                        var cca = new ClassesCourses();
                        cca.CourseId = courses[i].Id;
                        cca.ClassId = ClassId;
                        cc.Add(cca);

                    }

                }
                await cc.SaveChangesAsync();
                return RedirectToAction("Index", "Classe");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}