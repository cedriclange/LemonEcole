using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Infrastructure.OtherType;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSolution.Web.ViewModels;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Web.Controllers
{
    public class ScoreController : Controller
    {
        IMatrix mx;
        IClass cls;
        IStudent stu;
        IPeriod pr;
        ICourse crs;
        IScore sr;
        public ScoreController(IMatrix mx, IClass cls, IStudent stu, IPeriod pr, IScore sr, ICourse crs)
        {
            this.mx = mx;
            this.cls = cls;
            this.stu = stu;
            this.pr = pr;
            this.crs = crs;
            this.sr = sr;

        }


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
        [HttpGet]
        public IActionResult Index(int? classId, int? courseId)
        {
            var model = new AllScoreViewModel();
            if (classId != null && courseId != null)
            {
                
                model.SM = mx.GetAll(classId.Value, courseId.Value);
                if (model == null)
                {
                    return NotFound();
                }
            }
            var classes = new List<Classe>();
            classes = cls.GetForDropDown().ToList();
            classes.Insert(0,new Classe{Id=0,Name="Selectionner"});
            ViewData["ClassId"] = new SelectList(classes,"Id","Name",0);
            return View(model);
        }
        [HttpGet]
        public ActionResult GetCourses(int id)
        {
            
            var model = crs.CourseByClassId(id);
            
            
            return Json(model);

        }
        [HttpGet]
        public async Task<IActionResult> Create(ScoreViewModel myModel)
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