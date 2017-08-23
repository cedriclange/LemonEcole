using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class Percentage
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int PeriodID { get; set; }
        public double Percent { get; set; }
        public virtual Student Student { get; set; }
        public virtual Period Period { get; set; }
    }
}
