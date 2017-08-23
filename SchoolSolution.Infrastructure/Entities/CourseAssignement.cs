using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class CourseAssignement
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }
    }
}
