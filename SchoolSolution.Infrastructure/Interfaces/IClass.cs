using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface IClass : IRepository
    {
        Task<int> CountClass(int? id);
        IEnumerable<Classe> GetAll();
        Task<List<Classe>> GetAllAsync();
        Task<List<Classe>> GetAllFromDepartmentAsync(int id);
        Classe GetClassByStudentId(int id);
        IEnumerable<Classe> GetForDropDown();
        void Add(Classe c);
        void Update(Classe c);
        bool IfExists(string name, int? id);
        Classe GetById(int id);
        Classe GetByTeacherId(int id);
    }
}
