using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class PaiementForRepository
    {
        private SchoolDbContext context = new SchoolDbContext();

        public IEnumerable<PaiementFor> DropDownList()
        {
            return context.PaiementFor;
        }
    }
}
