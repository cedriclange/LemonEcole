using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSolution.Infrastructure.Entities;

namespace SchoolSolution.Web.ViewModels
{
    public class CourseAssignModel
    {
        public Teacher Teacher { get; set; }
        public List<Course> Courses { get; set; }
        public int TeacherId { get; set; }
    }
}
