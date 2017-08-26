using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Infrastructure.OtherType;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSolution.Web.FrontEnd.ViewModels;
using SchoolSolution.Infrastructure.Entities;

namespace SchoolSolution.Web.FrontEnd.Controllers
{
    public class ScoreController : Controller
    {
        private MatrixRepository mx = new MatrixRepository();
        private ClassRepository cls = new ClassRepository();
        private StudentRepository stu = new StudentRepository();
        private PeriodRepository pr = new PeriodRepository();
        private CourseRepository crs = new CourseRepository();
        private ScoreRepository sr = new ScoreRepository();



        public async Task<IActionResult> StudentScore(int id)
        {

            var model = new StudentScoreViewModel();
            model.Student = await stu.GetByIdAsync(id);
            model.SSM = mx.GetScoreById(id);
                      
            if (model == null)
            {
                ViewBag.message = "null";
                return View();
            }
            return View(model);
        }

        public IActionResult Index(int? classId, int? courseId)
        {
            var model = new AllScoreViewModel();
            if (classId != null)
            {
                ViewData["CourseId"] = new SelectList(crs.CourseByClassId(classId.Value), "Id", "Name");             
                model.SM = mx.GetAll(classId.Value, courseId.Value);
                if (model == null)
                {
                    return NotFound();
                }

                
                
            }
            ViewData["ClassId"] = new SelectList(cls.GetForDropDown(), "Id", "Name");
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create(ScoreViewModel myModel )
        {
            var model = new ScoreViewModel();
            var aModel = new List<StudentScore>();
            
            if (myModel.ClassId != null)
            {
                model.Students = await stu.GetAllByClassID(myModel.ClassId.Value);
                //assign students values to StudentsSubmit
                foreach (var item in model.Students)
                {
                    var st = new StudentScore() { StudentId = item.Id, FullName = item.FullName, Score = 0 };
                    aModel.Add(st);
                }
                model.StudentSubmit = aModel;
                ViewData["CourseId"] = new SelectList(crs.CourseByClassId(myModel.ClassId.Value), "Id", "Name");

            }
            
            InitializeDropdownlist();
            return View(model);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Encodage(ScoreViewModel myModel)
        {
            if (ModelState.IsValid)
            {
                var o = myModel.StudentSubmit;
                foreach (var item in o)
                {
                    var data = new Score()
                    {
                        ClassId = myModel.ClassId.Value,
                        CourseID = myModel.CourseId,
                        StudentID = item.StudentId,
                        PeriodID = myModel.PeriodId,
                        Point = item.Score,
                        CreatedDate = DateTime.UtcNow.Date,
                        ModifiedDate = DateTime.UtcNow.Date
                    };
                    sr.Add(data);
                }
                await sr.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            InitializeDropdownlist();
            return View(myModel);
        }

       
        private void InitializeDropdownlist()
        {
            ViewData["ClassId"] = new SelectList(cls.GetForDropDown(), "Id", "Name");
            ViewData["PeriodId"] = new SelectList(pr.DropDownList(), "Id", "Name");

        }
    }
}