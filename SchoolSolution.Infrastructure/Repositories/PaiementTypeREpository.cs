using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class PaiementTypeRepository
    {
        private SchoolDbContext context = new SchoolDbContext();

        public IEnumerable<PaiementType> DropDownList()
        {
            return context.PaimentType;
        }
    }
}
