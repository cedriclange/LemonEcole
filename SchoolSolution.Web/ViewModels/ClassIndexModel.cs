using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.ViewModels
{
    public class ClassIndexModel
    {
        public int Id { get; set; }
        public string classeName { get; set; }
        public string depName { get; set; }
        public int TotalCourses { get; set; }
    }
}
