using System;

namespace SchoolSolution.Infrastructure.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public int PeriodID { get; set; }
        public int ClassId { get; set; }
        public double Point { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual Classe Classe { get; set; }
        public virtual Period Period { get; set; }

    }
}
