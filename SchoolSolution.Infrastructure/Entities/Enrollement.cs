using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class Enrollement
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        
        public DateTime EnrollementDate { get; set; }
    }
}
