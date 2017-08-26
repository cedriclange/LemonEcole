using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface ICourse :IRepository
    {
        void Add(Course c);
        void Update(Course c);
        void Remove(Course c);
        IQueryable<Course> CourseByClassId(int id);
        bool IfExists(string name, int? id);
        List<Course> GetAll();
        Course GetById(int id);
        Task<List<Course>> GetTaughtByTeacherId(int id);
    }
}
