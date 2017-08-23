using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Data;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class EnrollementRepository : IRepository
    {
        private SchoolDbContext context = new SchoolDbContext();

        public async  Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Add(Enrollement e)
        {
            context.Add(e);
        }
        
      
       
    }
}
