using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface IStudent :IRepository
    {
        Task<int> CountStudentAsync();
        Task<IEnumerable<Student>> GetAllAsync();
        void Add(Student c);
        void Update(Student c);
        void Remove(Student c);
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetAllByClassID(int id);
        Task<List<Student>> GetAllFilter(int monthId, int typeId, int classId, string status);
        IQueryable<Student> GetFromClassId(int classId);
        Task<Student> LastAdded();
        Task<List<Student>> Search(string searchString);
        bool IfExists(string studentNumber, int? id);
        Task<int> GetStudentId(string studentnumber);


    }
}
