using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class Department
    {
        public Department()
        {
            this.Classes = new HashSet<Classe>();
            this.Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Classe> Classes { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
