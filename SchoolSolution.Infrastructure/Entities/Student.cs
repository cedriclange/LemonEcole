using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class Student : People
    {
        public Student()
        {
            this.Paiements = new HashSet<Paiment>();
            this.Scores = new HashSet<Score>();
            this.Percentages = new HashSet<Percentage>();
        }
        public string StudentNumber { get; set; }
        public DateTime DateofBirth { get; set; }
        public byte[] Photo { get; set; }
        public bool IsEnrolled { get; set; }

        public virtual ICollection<Paiment> Paiements { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<Percentage> Percentages { get; set; }
    }
}
