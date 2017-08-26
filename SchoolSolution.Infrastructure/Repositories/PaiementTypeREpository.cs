using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class PaiementTypeRepository :IPaymentType
    {
        SchoolDbContext context;
        public PaiementTypeRepository(SchoolDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<PaiementType> DropDownList()
        {
            return context.PaimentType;
        }
    }
}
