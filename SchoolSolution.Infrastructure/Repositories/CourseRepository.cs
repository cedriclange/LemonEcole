﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class CourseRepository : ICourse
    {
        SchoolDbContext context;
        public CourseRepository(SchoolDbContext ctx)
        {
            context = ctx;
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Add(Course c)
        {
            context.Add(c);
        }
        public void Remove(Course c)
        {
            context.Remove(c);
        }
        public List<Course> CourseByClassId(int id)
        {
            var model = from c in context.Course
                        join cc in context.ClassesCourses
                        on c.Id equals cc.CourseId
                        where cc.ClassId == id
                        select c;
            return model.ToList();
        }
        public bool IfExists(string name, int? id)
        {
            var check = true;
            if (!string.IsNullOrEmpty(name))
            {
                check = context.Course.Any(c => c.Name == name);
            }
            if (id != null)
            {
                check = context.Course.Any(c => c.Id == id.Value);
            }
            return check;
        }
        public void Update(Course c)
        {
            context.Update(c);
        }
       
        public List<Course> GetAll()
        {
            return context.Course.OrderBy(o => o.Name)
                .Include(c => c.department)
                .ToList();
        }
       
        public Course GetById(int id)
        {
            return context.Course
                .Include(c=>c.department)
                .SingleOrDefault(c => c.Id == id);
                
        }
        public async Task<List<Course>> GetTaughtByTeacherId(int id)
        {
            var assign = context.CourseAssignement;
             var model = from cs in assign
                         join c in context.Course
                         on cs.CourseId equals c.Id
                         where cs.TeacherId == id
                         select c;
            return await model.ToListAsync();

        }
    }
}
