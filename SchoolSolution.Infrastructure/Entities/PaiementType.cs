using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class PaiementType
    {
        public PaiementType()
        {
            this.Paiements = new HashSet<Paiment>();
        }
        public int Id { get; set; }
        
        public string Description { get; set; }

        public virtual ICollection<Paiment> Paiements { get; set; }
    }
}
