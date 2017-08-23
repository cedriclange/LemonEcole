using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class DepartmentRepository : IRepository
    {
        private  SchoolDbContext context = new SchoolDbContext();

        public async Task<int> CountDepartmentAsync()
        {
            return await context.Department.CountAsync();
        }
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await context.Department
                .OrderBy(c => c.Name)                
                .ToListAsync();
                    
        }
        public  async Task<Department> GetByIdAsync(int id)
        {
            return await context.Department
                .FirstAsync(c => c.Id == id);
                               
        }


        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Add(Department dep)
        {
            context.Add(dep);
        }
        public bool IfExists(string name)
        {
            return context.Department.Any(n => n.Name == name);
        }
        public IEnumerable<Department> DropDownList()
        {
            return context.Department.OrderBy(o => o.Name);
        }
            

            
    }
}
