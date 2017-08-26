using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface ITeacher :IRepository
    {
        Task<int> CountTeacherAsync();
        Task<List<Teacher>> GetAllAsync();
        Teacher GetById(int id);
        void Add(Teacher t);
        void Update(Teacher t);
        bool IfExists(int id);
    }
}
