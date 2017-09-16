using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class PaiementForRepository : IPaymentFor
    {
        SchoolDbContext context;
        public PaiementForRepository(SchoolDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<PaiementFor> DropDownList()
        {
            return context.PaiementFor;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
