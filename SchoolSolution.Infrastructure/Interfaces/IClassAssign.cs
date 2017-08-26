using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface IClassAssign :IRepository
    {
        void Add(ClassAssignement c);
        void Update(ClassAssignement c);
        void Remove(ClassAssignement c);
        Task<ClassAssignement> GetByTeacherIdAsync(int id);
        bool IfExists(int id);
    }
}
