using SchoolSolution.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SchoolSolution.Infrastructure.Entities;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class ClasseCourseRepository : IRepository
    {
        private SchoolDbContext context = new SchoolDbContext();
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Add(ClassesCourses c)
        {
            context.Add(c);
        }
    }
}
