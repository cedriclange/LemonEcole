using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.FrontEnd.ViewModels
{
    public class ClassDetailsModel
    {
        public List<Student> Students { get; set; }
        public int NumberofStudent { get; set; }
        public Classe Classe { get; set; }

    }
}
