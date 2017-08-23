using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.FrontEnd.ViewModels
{
    public class EnrollementViewModel
    {
        public Student Student { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }
    }
}
