using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.OtherType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.ViewModels
{
    public class StudentScoreViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<StudentScoreMatrix> SSM { get; set; }
      
    }
}
