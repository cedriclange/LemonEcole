using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.FrontEnd.ViewModels
{
    public class CreateStudentViewModel
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DateofBirth { get; set; }
        public string StudentNumber { get; set; }
        public int ClassId { get; set; }

    }
}
