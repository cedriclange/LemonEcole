using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class Period
    {
        public Period()
        {
            this.Scores = new HashSet<Score>();
            this.Percentages = new HashSet<Percentage>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<Percentage> Percentages { get; set; }
    }
}
