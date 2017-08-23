using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class Paiment
    {
        public int Id { get; set; }
        public DateTime PaidOn { get; set; }
        public int StudentID { get; set; }
        public int Type { get; set; }
        public int MonthId { get; set; }
        public decimal Amount { get; set; }

        public virtual Student Student { get; set; }
        public virtual PaiementType PType { get; set; }
        public virtual PaiementFor Month { get; set; }
    }
}
