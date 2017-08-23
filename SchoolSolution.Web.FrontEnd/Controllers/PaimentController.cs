using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Web.FrontEnd.ViewModels;
using Microsoft.AspNetCore.Routing;

namespace SchoolSolution.Web.FrontEnd.Controllers
{
    public class PaimentController : Controller
    {
        private StudentRepository stu = new StudentRepository();
        private PaiementTypeRepository Pmtype = new PaiementTypeRepository();
        private PaiementForRepository PmFor = new PaiementForRepository();
        private PaiementRepository Pmt = new PaiementRepository();
        private ClassRepository cls = new ClassRepository();

        // GET: Paiment
        public async Task<IActionResult> Index(ListePaieViewModel model)
        {
            if (model.status == null)
            {
                ViewBag.message = "Filter";
                InitializeDropdownList(model.monthId, model.typeId, model.classId, 3);
                return View();
            }
            model.students = await stu.GetAllFilter(model.monthId, model.typeId, model.classId, model.status);
            if (model.students == null)
            {
                ViewBag.message = "None";
                InitializeDropdownList(model.monthId, model.typeId, model.classId, 3);
                return View();
            }
            ViewBag.message = "Found";
            model.count = model.students.Count();
            InitializeDropdownList(model.monthId, model.typeId, model.classId, 3);
            return View(model);
        }
        
        //// GET: Paiment/Create
        public async Task<PartialViewResult> Create(int? id)
        {
            var model = new CreatePaiementModel();
            
            if (id != null)
            {
                var student = await stu.GetByIdAsync(id.Value);
                model.StudentNumber = student.StudentNumber;
                model.ActionFrom = "Student";
                model.StudentID = student.Id;
            }
            else
            {
                model.ActionFrom = "Paiement";
            }
            
            model.DateofPaiement = DateTime.UtcNow.Date;
            InitializeDropdownList(null, null, null,2);

            return PartialView(model);
        }


        //// POST: Paiment/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePaiementModel paiment)
        {
            if (ModelState.IsValid)
            {
                var model = new Paiment();
                if (paiment.ActionFrom == "Paiement")
                {
                    model.StudentID = await stu.GetStudentId(paiment.StudentNumber);
                    model.MonthId = paiment.Period;
                    model.Type = paiment.Type;
                    model.PaidOn = paiment.DateofPaiement;
                    model.Amount = paiment.Amount;
                    Pmt.Add(model);
                    await Pmt.SaveChangesAsync();
                    return RedirectToAction("PayHistoric", new RouteValueDictionary(
                        new { Controller = "Paiment", action = "PayHistoric", Id = paiment.StudentID }));

                }
                else
                {
                    model.StudentID = paiment.StudentID;
                    model.MonthId = paiment.Period;
                    model.Type = paiment.Type;
                    model.PaidOn = paiment.DateofPaiement;
                    model.Amount = paiment.Amount;
                    Pmt.Add(model);
                    await Pmt.SaveChangesAsync();
                    return RedirectToAction("PayHistoric", new RouteValueDictionary(
                        new { Controller = "Paiment", action = "PayHistoric", Id = paiment.StudentID }));

                }
                
                
            }
            InitializeDropdownList(paiment.Period, paiment.Type, null,2);
            
            return View(paiment);
        }
        
        public async Task<ActionResult> PayHistoric(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var st = await stu.GetByIdAsync(id.Value);
            var model = new PayHistoricModel();
            model.Paiements = await Pmt.GetPayHistoric(id.Value);
            model.Student = st.FullName;
            model.StudentID = st.Id;
            
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        private void InitializeDropdownList(int? monthId, int? typeId, int? classId, int n)
        {
            if (n == 2)
            {
                ViewData["MonthId"] = new SelectList(PmFor.DropDownList(), "Id", "Month", monthId);
                ViewData["Type"] = new SelectList(Pmtype.DropDownList(), "Id", "Description", typeId);
                
            }
            else
            {
                ViewData["MonthId"] = new SelectList(PmFor.DropDownList(), "Id", "Month", monthId);
                ViewData["Type"] = new SelectList(Pmtype.DropDownList(), "Id", "Description", typeId);
                ViewData["ClassID"] = new SelectList(cls.GetForDropDown(), "Id", "Name", classId);
            }
        }
        
    }
}
