using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class EnrollementRepository : IEnrollement
    {
        SchoolDbContext context;
        public EnrollementRepository(SchoolDbContext ctx)
        {
            context = ctx;
        }

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
