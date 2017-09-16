using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface ICourseAssignement :IRepository
    {
        void Add(CourseAssignement c);
        void Update(CourseAssignement c);
        void Remove(CourseAssignement c);
        bool IfExists(int courseId, int teacherId);
        Task<CourseAssignement> GetByIdAsync(int courseId, int teacherId);

    }
}
