using System;
using System.Collections.Generic;

namespace SchoolSolution.Infrastructure.Entities
{
    public class Teacher : People
    {
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        
        public decimal Salary { get; set; }
       
        public ICollection<CourseAssignement> CourseAssigned { get; set; }
        


    }
}
