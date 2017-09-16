using SchoolSolution.Infrastructure.Entities;
using SchoolSolution.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface IDepartment : IRepository
    {
        Task<int> CountDepartmentAsync();
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
        void Add(Department dep);
        bool IfExists(string name);
        IEnumerable<Department> DropDownList();
    }
}
