using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Web.ViewModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Web.Controllers
{
    public class TeacherController : Controller
    {
        ITeacher th;
        IClass cls;
        ICourse crs;
        public TeacherController(ITeacher _th, IClass _cls, ICourse _crs)
        {
            th = _th;
            cls = _cls;
            crs = _crs;
        }
        public async Task<IActionResult> Index()
        {
            return View(await th.GetAllAsync());
        }
        //GET :Teacher/Create
        public PartialViewResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Firstname,Lastname,Address," +
            "Gender,CreatedDate,Email,PhoneNumber,Salary,HireDate")] Teacher model)
        {
            model.CreatedDate = DateTime.UtcNow.Date;
            model.ModifiedDate = DateTime.UtcNow.Date;
            if (ModelState.IsValid)
            {
                var o = new Teacher();
                o.Address = model.Address;
                o.CreatedDate = model.CreatedDate;
                o.ModifiedDate = model.ModifiedDate;
                o.Lastname = model.Lastname.ToUpper();
                o.Firstname = model.Firstname.ToUpper();
                o.Gender = model.Gender;
                o.Email = model.Email;
                o.PhoneNumber = model.PhoneNumber;
                o.HireDate = model.HireDate;
                o.Salary = model.Salary;
                th.Add(o);
                await th.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView(model);
            
        }

        //GET : Teacher/Details
        public async Task<ActionResult> Details(int? id )
        {

            if (id == null)
            {
                return NotFound();
            }
            var model = new TeacherDetailsModel();
            model.Teacher = th.GetById(id.Value);
            model.Courses = await crs.GetTaughtByTeacherId(id.Value);
            var cl = cls.GetByTeacherId(id.Value);
            if (cl != null)
            {
                model.Classe = cl.Name;

            }
            
            if (model == null)
            {
                return NotFound();
            }
           
            

            return View(model);

        }
        public PartialViewResult Edit(int? id)
        {
           
            var model = th.GetById(id.Value);
            return PartialView(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Teacher model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var o = th.GetById(model.Id);
                    o.Address = model.Address;

                    o.Lastname = model.Lastname.ToUpper();
                    o.Firstname = model.Firstname.ToUpper();
                    o.Gender = model.Gender;
                    o.Email = model.Email;
                    o.PhoneNumber = model.PhoneNumber;
                    o.ModifiedDate = DateTime.UtcNow.Date;
                    o.Salary = model.Salary;
                    th.Update(o);
                    await th.SaveChangesAsync();
                   
                    return RedirectToAction("Details", new RouteValueDictionary(
                        new { controller = "Teacher", action = "Details", Id = o.Id }));
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!th.IfExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(model);

            
        }


    }
}