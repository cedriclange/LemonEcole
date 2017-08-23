using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class ScoreRepository : IRepository
    {
        private SchoolDbContext context = new SchoolDbContext();
        public async Task SaveChangesAsync()
        {
           await  context.SaveChangesAsync();
        }
        public void Add(Score c)
        {
            context.Add(c);
        }
    }
}
