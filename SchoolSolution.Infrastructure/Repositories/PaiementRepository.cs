using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class PaiementRepository : IPayment
    {
        SchoolDbContext context;
        public PaiementRepository(SchoolDbContext ctx)
        {
            context = ctx;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Add(Paiment p)
        {
            context.Add(p);
        }
        public async Task<List<Paiment>> GetPayHistoric(int id)
        {
            return await context.Paiment.Include(e => e.Student)
                .Include(e => e.PType)
                .Include(e => e.Month)
                .Where(w => w.StudentID == id)
                .OrderByDescending(e => e.MonthId)
                .ToListAsync();
        }
    }
}
