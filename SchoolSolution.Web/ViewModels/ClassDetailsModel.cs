using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.ViewModels
{
    public class ClassDetailsModel
    {
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public int NumberofStudent { get; set; }
        public Classe Classe { get; set; }

    }
}
