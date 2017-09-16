using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Infrastructure.Entities;
using System.Security.Cryptography;
using SchoolSolution.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Web.Controllers
{
    public class StudentController : Controller
    {
        IStudent stu;
        IClass cls;

        IEnrollement enr;
        public StudentController(IStudent _stu, IClass _cls, IEnrollement _enr)
        {
            stu = _stu;
            cls = _cls;
            enr = _enr;
        }


        public ActionResult Index()
        {
            return View();
        }
        // GET: Student
        public async Task<IActionResult> Search(string searchString)
        {
            if (searchString == null)
            {
                return NotFound();
            }
            var model = await stu.Search(searchString);

            ViewBag.count = model.Count();

            return View(model);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new StudentDetailsModel();
            model.Student = await stu.GetByIdAsync(id.Value);
            var clse = cls.GetClassByStudentId(id.Value);
            model.className = clse.Name;
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        //// GET: Student/Create
        public PartialViewResult Create()
        {
            var model = new CreateStudentViewModel();
            model.StudentNumber = GetUniqueNumber();
            ViewData["ClassId"] = new SelectList(cls.GetForDropDown(), "Id", "Name");
            return PartialView(model);
        }

        //// POST: Student/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,Address,Gender,StudentNumber,DateofBirth,ClassId")] CreateStudentViewModel model)
        {
            model.CreatedDate = DateTime.UtcNow.Date;
            model.ModifiedDate = DateTime.UtcNow.Date;
            model.StudentNumber = "STN" + DateTime.Now.Year.ToString() + model.StudentNumber;
            if (!stu.IfExists(model.StudentNumber, null))
            {


                if (ModelState.IsValid)
                {
                    var _student = new Student();
                    _student.Lastname = model.Lastname.ToUpper();
                    _student.Firstname = model.Firstname.ToUpper();
                    _student.Gender = model.Gender;
                    _student.Address = model.Address;
                    _student.CreatedDate = model.CreatedDate;
                    _student.ModifiedDate = model.ModifiedDate;
                    _student.StudentNumber = model.StudentNumber;
                    _student.DateofBirth = model.DateofBirth;
                    _student.IsEnrolled = true;
                    stu.Add(_student);
                    await stu.SaveChangesAsync();
                    var en = new Enrollement();
                    en.StudentID = _student.Id;
                    en.ClassID = model.ClassId;
                    en.EnrollementDate = DateTime.UtcNow.Date;
                    enr.Add(en);
                    await enr.SaveChangesAsync();
                    return RedirectToAction("Index");

                }

                return PartialView(model);
            }

            return PartialView(model);
        }


        //// GET: Student/Edit/5
        public async Task<PartialViewResult> Edit(int? id)
        {
            var student = await stu.GetByIdAsync(id.Value);
            return PartialView(student);
        }

        //// POST: Student/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,Address,Gender,DateofBirth")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var model = await stu.GetByIdAsync(student.Id);
                    model.Firstname = student.Firstname.ToUpper();
                    model.Lastname = student.Lastname.ToUpper();
                    model.Gender = student.Gender;
                    model.Address = student.Address.ToUpper();
                    model.DateofBirth = student.DateofBirth;
                    stu.Update(model);
                    await stu.SaveChangesAsync();
                    return RedirectToAction("Details", new RouteValueDictionary(
                        new { controller = "Student", action = "Details", Id = student.Id }));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!stu.IfExists(null, student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return PartialView(student);
        }

        //// GET: Student/Delete/5
        public async Task<PartialViewResult> Delete(int? id)
        {
            var student = await stu.GetByIdAsync(id.Value);
            return PartialView(student);
        }

        //// POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await stu.GetByIdAsync(id);
            stu.Remove(student);
            await stu.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }




        private string GetUniqueNumber()
        {
            // generate a unique number
            var bytes = new byte[8];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 1000000000;
            return string.Format("{0:D8}", random);
        }
    }
}
