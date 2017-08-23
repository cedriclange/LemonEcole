using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Web.FrontEnd.ViewModels;

namespace SchoolSolution.Web.FrontEnd.Controllers
{
    public class EnrollementController : Controller
    {
        private EnrollementRepository enr = new EnrollementRepository();
        private ClassRepository cls = new ClassRepository();
        private StudentRepository stu = new StudentRepository();
      
       
        
        // GET: Enrollement/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }


        //    return View();
        //}

        //// POST: Enrollement/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,StudentID,ClassID,EnrollementDate")] Enrollement enrollement)
        //{
        //    if (id != enrollement.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
                   
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
                    
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(enrollement);
        //}

       
       
    }
}
