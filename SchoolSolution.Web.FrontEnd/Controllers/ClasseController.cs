using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Web.FrontEnd.ViewModels;
using System.Collections.Generic;

namespace SchoolSolution.Web.FrontEnd.Controllers
{
    public class ClasseController : Controller
    {
        private ClassRepository cls = new ClassRepository();
        private DepartmentRepository dep = new DepartmentRepository();
        private StudentRepository stu = new StudentRepository();
        private CourseRepository crs = new CourseRepository();
        // GET: Classe
        public async Task<IActionResult> Index()
        {
            var model = new List<ClassIndexModel>();

            var classes = await cls.GetAllAsync();
            foreach (var item in classes)
            {
                var o = new ClassIndexModel()
                {
                    Id = item.Id,
                    classeName = item.Name,
                    depName  = item.department.Name
                };
                o.TotalCourses = crs.CourseByClassId(item.Id).Count();
                model.Add(o);
            }
            
            return View(model);
        }

        //GET: Classe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var model = new ClassDetailsModel();
            model.Students = await stu.GetAllByClassID(id.Value);
            model.NumberofStudent = model.Students.Count();
            model.Courses = crs.CourseByClassId(id.Value).ToList();
            model.Classe = cls.GetById(id.Value);
            
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        

        //// GET: Classe/Create
        public PartialViewResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(dep.DropDownList(), "Id", "Name");
            return PartialView();
        }

        //// POST: Classe/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DepartmentID")] Classe classe)
        {
            if (ModelState.IsValid)
            {
                if (!cls.IfExists(classe.Name, null))
                {
                    cls.Add(classe);
                    await cls.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
               
            }
            ViewData["DepartmentID"] = new SelectList(dep.DropDownList(), "Id", "Name", classe.DepartmentID);
            return View(classe);
        }

        //// GET: Classe/Edit/5
        public PartialViewResult Edit(int? id)
        {
            
            var classe =  cls.GetById(id.Value);
            if (classe == null)
            {
                return PartialView();
            }
            ViewData["DepartmentID"] = new SelectList(dep.DropDownList(), "Id", "Name", classe.DepartmentID);
            return PartialView(classe);
        }

        //// POST: Classe/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DepartmentID")] Classe classe)
        {
            if (id != classe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cls.Update(classe);
                    await cls.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cls.IfExists(null,classe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DepartmentID"] = new SelectList(dep.DropDownList(), "Id", "Name", classe.DepartmentID);
            return View(classe);
        }

        
    }
}
