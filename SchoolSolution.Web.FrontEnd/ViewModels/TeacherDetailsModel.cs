using SchoolSolution.Infrastructure.Entities;
using System.Collections.Generic;

namespace SchoolSolution.Web.FrontEnd.ViewModels
{
    public class TeacherDetailsModel
    {
        public Teacher Teacher { get; set; }
        public string  Classe { get; set; }
        public List<Course> Courses { get; set; }

    }
}
