using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.FrontEnd.ViewModels
{
    public class ScoreViewModel
    {
        public int? ClassId { get; set; }
        public int CourseId { get; set; }
        public int PeriodId { get; set; }
        public List<Student> Students { get; set; }
        public List<StudentScore> StudentSubmit { get; set; }
    }
    public class StudentScore
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public double Score { get; set; }
    }
}
