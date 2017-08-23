using System;

namespace SchoolSolution.Web.FrontEnd.ViewModels
{
    public class CreatePaiementModel
    {
        public string StudentNumber { get; set; }
        public int Type { get; set; }
        public int Period { get; set; }
        public DateTime DateofPaiement { get; set; }
        public decimal Amount { get; set; }
        public string ActionFrom { get; set; }
        public int StudentID { get; set; }
    }
}
