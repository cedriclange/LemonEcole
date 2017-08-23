using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSolution.Web.FrontEnd.ViewModels;
using Microsoft.AspNetCore.Routing;

namespace SchoolSolution.Web.FrontEnd.Controllers
{
    public class ClassAssignController : Controller
    {
        private ClassAssignRepository clsa = new ClassAssignRepository();
        private TeacherRepository th = new TeacherRepository();
        private ClassRepository cls = new ClassRepository();
        // GET: ClassAssign/Create id teacher
        public PartialViewResult Create(int id)
        {
            var model = new ClassAssignModel();
            model.Teacher = th.GetById(id);
            model.TeacherId = model.Teacher.Id;
            DropDownList(model.ClassId);
            return PartialView(model);
        }

        // POST: ClassAssign/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClassAssignModel model)
        {

            if (ModelState.IsValid)
            {
                
                    var assign = new ClassAssignement();
                    assign.ClassId = model.ClassId;
                    assign.TeacherId = model.TeacherId;
                    clsa.Add(assign);
                    await clsa.SaveChangesAsync();

                    return RedirectToAction("Details", new RouteValueDictionary(
                        new {Controller="Teacher", action="Details", Id = model.TeacherId }));
                
            }
            DropDownList(model.ClassId);
            return PartialView(model);
        }

        // GET: ClassAssign/Edit/5
        public PartialViewResult Edit(int id)
        {
            var model = new ClassAssignModel();
            var cl = new Classe();
            model.Teacher = th.GetById(id);
            cl = cls.GetByTeacherId(id);
            model.TeacherId = model.Teacher.Id;
            model.ClassId = cl.Id;
            DropDownList(model.ClassId);
            return PartialView(model);
        }

        // POST: ClassAssign/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClassAssignModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var assign = await clsa.GetByTeacherIdAsync(model.TeacherId);
                    assign.ClassId = model.ClassId;
                    assign.TeacherId = model.TeacherId;
                    clsa.Update(assign);
                    await clsa.SaveChangesAsync();

                    return RedirectToAction("Details", new RouteValueDictionary(
                        new { Controller = "Teacher", action = "Details", Id = model.TeacherId }));
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!clsa.IfExists(model.TeacherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                } 
            }
            DropDownList(model.ClassId);
            return PartialView(model);
        }

        
        private void DropDownList(int? id)
        {
            if (id == null)
            {
                ViewData["ClassId"] = new SelectList(cls.GetForDropDown(), "Id", "Name");

            }
            ViewData["ClassId"] = new SelectList(cls.GetForDropDown(), "Id", "Name",id.Value);
        }
    }
}