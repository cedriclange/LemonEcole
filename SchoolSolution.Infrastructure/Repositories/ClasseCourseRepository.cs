using SchoolSolution.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class ClasseCourseRepository : IClasseCourse
    {
        SchoolDbContext context;
        public ClasseCourseRepository(SchoolDbContext ctx)
        {
            context = ctx;
        }
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
