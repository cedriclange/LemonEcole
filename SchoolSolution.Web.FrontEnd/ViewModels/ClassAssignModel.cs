using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.FrontEnd.ViewModels
{
    public class ClassAssignModel
    {
        public  Teacher Teacher { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
    }
}
