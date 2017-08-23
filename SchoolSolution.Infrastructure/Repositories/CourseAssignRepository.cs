using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using System;
using System.Linq;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class CourseAssignRepository : IRepository
    {
        private SchoolDbContext context = new SchoolDbContext();
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Add(CourseAssignement c)
        {
            context.Add(c);
        }
        public void Update(CourseAssignement c)
        {
            context.Update(c);
        }
        public void Remove(CourseAssignement c)
        {
            context.Remove(c);
        }
        public bool IfExists(int courseId, int teacherId)
        {
            return context.CourseAssignement
                .Any(e => e.CourseId == courseId && e.TeacherId == teacherId);
        }
        public async Task<CourseAssignement> GetByIdAsync(int courseId,int teacherId)
        {
            return await context.CourseAssignement.SingleAsync(e => e.CourseId == courseId && e.TeacherId == teacherId);
        }
    }
}
