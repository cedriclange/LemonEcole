using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSolution.Web.ViewModels
{
    public class PaiementSuccessModel
    {
        public string Fullnames { get; set; }
        public string StudentNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
