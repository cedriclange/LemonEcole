using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class ClassRepository : IRepository
    {
        private SchoolDbContext context = new SchoolDbContext();

        //count nu;ber of classes in the database
        public async Task<int> CountClass(int? id)
        {
            //return number of classes from department
            if (id != null)
            {
                return await context.Classe
                    .Where(c => c.DepartmentID == id.Value)
                    .CountAsync();
            }

            return await context.Classe.CountAsync();
        }
        //get all classes
        public IEnumerable<Classe> GetAll()
        {
            return context.Classe.OrderBy(o=> o.Name)
                .Include(i=>i.department)
                .ToList();
        }
        public async Task<List<Classe>> GetAllAsync()
        {
            return await context.Classe.OrderBy(o => o.Name)
                .Include(i => i.department)
                .ToListAsync();
        }
        //get classes from department id
        public async Task<List<Classe>> GetAllFromDepartmentAsync(int id)
        {
            return await context.Classe.Where(c => c.DepartmentID == id)
                .OrderBy(o=>o.Name)
                .ToListAsync();
        }
        //get classe by student id
        public Classe GetClassByStudentId(int id)
        {
            var model = from e in context.Enrollement
                        join c in context.Classe
                        on e.ClassID equals c.Id
                        where e.StudentID == id
                        select c;
            return model.Single();
        }
        //dropdownlist
        public IEnumerable<Classe> GetForDropDown()
        {
            return  context.Classe;
        }
        public void Add(Classe c)
        {
            context.Add(c);
        }
        public void Update(Classe c)
        {
            context.Update(c);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        //chechk if any class exist by id or name
        public bool IfExists(string name, int? id)
        {
            var check = true;
            if (!string.IsNullOrEmpty(name))
            {
                check = context.Classe.Any(c => c.Name == name);
            }
            if (id != null)
            {
                check = context.Classe.Any(c => c.Id == id.Value);
            }
            return check;
            
        }
        //get class by id
        public Classe GetById(int id)
        {
            return  context.Classe.Include(e=>e.department)
                .First(c => c.Id == id);
        }
        //get class by teahcer id 
        public Classe GetByTeacherId(int id)
        {

            if (context.ClassAssignement.Any(e=>e.TeacherId == id))
            {
                var model = from c in context.ClassAssignement
                            join s in context.Classe
                            on c.ClassId equals s.Id
                            where c.TeacherId == id
                            select s;
                return model.Single(); 
            }
            return null;


        }
    }
}
