using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.FrontEnd.ViewModels
{
    public class ClasseCourseModel
    {
        public int ClassId { get; set; }
        public Classe Classe { get; set; }
        public List<Course> Courses { get; set; }
    }
}
