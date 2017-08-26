using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class ScoreRepository : IScore
    {
        
        private readonly SchoolDbContext context;
        public ScoreRepository(SchoolDbContext options)
        {
            context = options;
        }
       
           

        
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
