using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class ClassAssignRepository : IRepository
    {
        private SchoolDbContext context = new SchoolDbContext();
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Add(ClassAssignement c)
        {
            context.Add(c);
        }
        public void Update(ClassAssignement c)
        {
            context.Update(c);
        }
        public void Remove(ClassAssignement c)
        {
            context.Remove(c);
        }
        //get Class Assigned by teacher id
        public async Task<ClassAssignement> GetByTeacherIdAsync(int id)
        {
            return await context.ClassAssignement.SingleAsync(e => e.TeacherId == id);
        }
        public bool IfExists(int id)
        {
            return context.ClassAssignement.Any(e => e.TeacherId == id);
        }
    }
}
