using SchoolSolution.Infrastructure.OtherType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.ViewModels
{
    public class AllScoreViewModel
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public IEnumerable<ScoreMatrix> SM { get; set; }
    }
}
