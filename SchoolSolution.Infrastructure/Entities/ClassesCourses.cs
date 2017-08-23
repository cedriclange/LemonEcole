using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class ClassesCourses
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public virtual Classe Classe { get; set; }
        public virtual Course Course { get; set; }
    }
}
