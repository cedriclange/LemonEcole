using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSolution.Infrastructure.Interfaces;
using SchoolSolution.Infrastructure.Entities;

namespace SchoolSolution.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/CourseAPI")]
    public class CourseAPIController : Controller
    {
        ICourse crs;
        public CourseAPIController(ICourse crs)
        {
            this.crs = crs;
        }
        [HttpGet]
        [Route("api/CourseAPI/GetCourseList")]
        public List<Course> GetCourseList(int id)
        {
            var model = crs.CourseByClassId(id);
            return model;
        }
    }
}