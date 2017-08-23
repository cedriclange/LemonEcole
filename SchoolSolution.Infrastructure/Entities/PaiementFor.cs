using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class PaiementFor
    {
        public int Id { get; set; }
        public string Month { get; set; }

        public virtual ICollection<Paiment> Paiements { get; set; }
    }
}
