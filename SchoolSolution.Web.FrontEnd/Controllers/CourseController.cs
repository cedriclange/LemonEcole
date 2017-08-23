using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Infrastructure.Entities;

namespace SchoolSolution.Web.FrontEnd.Controllers
{
    public class CourseController : Controller
    {
        private CourseRepository cr = new CourseRepository();
        private DepartmentRepository dep = new DepartmentRepository();

        

        // GET: Course
        public IActionResult Index()
        {
            
            return View( cr.GetAll());
        }
       
        // GET: Course/Create
        public PartialViewResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(dep.DropDownList(), "Id", "Name");
            return PartialView();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TotalAverage,DepartmentID")] Course course)
        {
            if (ModelState.IsValid)
            {
                if (! cr.IfExists(course.Name, null))
                {
                    cr.Add(course);
                    await cr.SaveChangesAsync();
                    return RedirectToAction("Index"); 
                }
            }
            ViewData["DepartmentID"] = new SelectList(dep.DropDownList(), "Id", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Course/Edit/5
        public PartialViewResult Edit(int? id)
        {
           
            var course =  cr.GetById(id.Value);
            
            ViewData["DepartmentID"] = new SelectList(dep.DropDownList(), "Id", "Name", course.DepartmentID);
            return PartialView(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TotalAverage,DepartmentID")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cr.Update(course);
                    await cr.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cr.IfExists(null,course.Id))
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
            ViewData["DepartmentID"] = new SelectList(dep.DropDownList(), "Id", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Course/Delete/5
        public PartialViewResult Delete(int? id)
        {
            
            var course =  cr.GetById(id.Value);           
            return PartialView(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course =  cr.GetById(id);
            cr.Remove(course);
            await cr.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}