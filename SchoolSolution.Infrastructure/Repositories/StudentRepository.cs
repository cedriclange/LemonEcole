using System.Collections.Generic;
using System.Linq;
using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class StudentRepository : IStudent
    {
        SchoolDbContext context;
        public StudentRepository(SchoolDbContext ctx)
        {
            context = ctx;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
       

        public async Task<int> CountStudentAsync()
        {
            return await context.People
                .OfType<Student>().CountAsync();
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await context.People
                .OfType<Student>()
                .ToListAsync();

        }
        public void Add(Student c)
        {
            context.Add(c);
            
        }
        public void Update(Student c)
        {
            context.Update(c);
        }
        public void Remove(Student c)
        {
            context.Remove(c);
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            return await context.People.OfType<Student>()
                .SingleAsync(c => c.Id == id);
        }
        public async Task<List<Student>> GetAllByClassID(int id)
        {
            var model = GetFromClassId(id);//fonction
            return await model.ToListAsync();
        }
        public async Task<List<Student>> GetAllFilter(int monthId,int typeId,int classId, string status)
        {
            //this method return a list of student according to paiement
            //filtering
            var data = GetFromClassId(classId); //return student from classId
            if (status == "Paid")
            {
                //get all students who have paid their fees
                
                
                
                var model = from st in  data 
                            join p in context.Paiment
                            on st.Id equals p.StudentID                            
                            where p.MonthId == monthId && p.Type == typeId 
                            orderby st.Lastname ascending
                            select st;
                return await model.ToListAsync();
            }
            else
            {

                var Paid = from st in data
                           join p in context.Paiment
                           on st.Id equals p.StudentID
                           where p.MonthId == monthId && p.Type == typeId
                           select st;

                return await data.Except(Paid).ToListAsync();

                            
                
            }

        }
        public IQueryable<Student> GetFromClassId(int classId)
        {
            //return student from a specific classID
            var data = from s in context.People.OfType<Student>()
                       join en in context.Enrollement
                       on s.Id equals en.StudentID
                       where en.ClassID == classId
                       orderby s.Lastname
                       select s;
            return data;

        }
        public async Task<Student> LastAdded()
        {
            return await context.People.OfType<Student>()
                .LastAsync();
        }
        public async Task<List<Student>> Search(string searchString)
        {
            
            var students = context.People.OfType<Student>();

            if (searchString.Contains("STN"))
            {
                //This is a search by student nomber
                return await students
                    .Where(w => w.StudentNumber == searchString)
                    .OrderBy(o => o.Lastname)
                    .ToListAsync();
            }
            else
            {
                searchString.ToUpper();
                return await 
                    students.Where(w => w.Firstname.Contains(searchString) || w.Lastname.Contains(searchString) )
                    .OrderBy(o => o.Lastname)
                    .ToListAsync();
            }
        }
        public bool IfExists(string studentNumber,int? id)
        {
            if (id != null)
            {
                return context.People.OfType<Student>()
                    .Any(e => e.Id == id.Value);

            }
            return context.People.OfType<Student>()
                .Any(c => c.StudentNumber == studentNumber);
        }
        public async Task<int> GetStudentId(string studentnumber)
        {
            var st = await context.People.OfType<Student>()
                .SingleAsync(e => e.StudentNumber == studentnumber);
            return st.Id;
                              
        }
    }
}
