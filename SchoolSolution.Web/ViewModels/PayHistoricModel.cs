using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.ViewModels
{
    public class PayHistoricModel
    {
        public string Student { get; set; }
        public int StudentID { get; set; }
        public List<Paiment> Paiements { get; set; }

    }
}
