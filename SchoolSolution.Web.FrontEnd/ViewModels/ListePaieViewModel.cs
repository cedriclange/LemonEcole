using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.FrontEnd.ViewModels
{
    public class ListePaieViewModel
    {
        public int monthId { get; set; }
        public int typeId { get; set; }
        public string status { get; set; }
        public int classId { get; set; }
        public List<Student> students { get; set; }
        public int count { get; set; }
    }
}
