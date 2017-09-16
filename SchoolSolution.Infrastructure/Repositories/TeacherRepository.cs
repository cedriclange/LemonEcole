using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacher
    {
        SchoolDbContext context;
        public TeacherRepository(SchoolDbContext ctx)
        {
            context = ctx;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public async Task<int> CountTeacherAsync()
        {
            return await context.People
                .OfType<Teacher>().CountAsync();
        }
        public async Task<List<Teacher>> GetAllAsync()
        {
            return await context.People
                .OfType<Teacher>()
                .ToListAsync();

        }
        
        public Teacher GetById(int id)
        {
            return context.People.OfType<Teacher>()
                .Single(e => e.Id == id);
        }
        public void Add(Teacher t)
        {
            context.Add(t);
        }
        public void Update(Teacher t)
        {
            context.Update(t);
        }
        public bool IfExists(int id)
        {
            return context.People.OfType<Teacher>()
                .Any(e => e.Id == id);
        }
    }
}
