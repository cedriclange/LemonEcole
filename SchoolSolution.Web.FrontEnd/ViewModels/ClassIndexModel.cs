using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.FrontEnd.ViewModels
{
    public class ClassIndexModel
    {
        public List<Classe> classe { get; set; }
        public int TotalCourses { get; set; }
    }
}
