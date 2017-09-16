using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.ViewModels
{
    public class DepDetailViewModel
    {
        public Department Department { get; set; }
        public List<Classe> Classes { get; set; }
        public int numberClass { get; set; }
    }
}
