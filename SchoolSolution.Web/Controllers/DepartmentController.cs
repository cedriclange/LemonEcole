using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Web.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartment dep;
        IClass cls;
        ICourse crs;
        public DepartmentController(IDepartment _dep, IClass _cls,
            ICourse _crs)
        {
            dep = _dep;
            cls = _cls;
            crs = _crs;
        }

       
        // GET: Department
        public async Task<IActionResult> Index()
        {
            var model = new List<DepatViewModel>();
            var departments = await dep.GetAllAsync();
            
            foreach (var item in departments)
            {
                DepatViewModel depart = new DepatViewModel
                {
                    Id = item.Id,
                    Name = item.Name

                };
                var totalclasse = cls.GetAll();
                var totalcours = crs.GetAll();
                depart.TotalClasses = totalclasse.Count(x=>x.DepartmentID == depart.Id);
                depart.TotalCours = totalcours.Count(x => x.DepartmentID == depart.Id);
                model.Add(depart);
            }
            return View(model);
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var model = new DepDetailViewModel();
            if (id == null)
            {
                return NotFound();
            }

            model.Department = await dep.GetByIdAsync(id.Value);
            model.numberClass = await cls.CountClass(id.Value);
            model.Classes = await cls.GetAllFromDepartmentAsync(id.Value);
            if (model.Department == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Department/Create
        public PartialViewResult Create()
        {
            return PartialView();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            department.CreatedDate = DateTime.UtcNow.Date;
            department.ModifiedDate = DateTime.UtcNow.Date;
            if (ModelState.IsValid)
            {
                if (dep.IfExists(department.Name) != true)
                {
                    dep.Add(department);
                    await dep.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                
                
            }
            return View(department);
        }
               
       
    }
}
