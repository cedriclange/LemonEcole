using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Xunit;
using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Interfaces;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Infrastructure.Entities;
using System.Threading.Tasks;

namespace SchoolSolution.Tests
{
    public class DepartmentTest
    {
        private IDepartment GetInMemoryRepository()
        {
            DbContextOptions<SchoolDbContext> Options;
            var builder = new DbContextOptionsBuilder<SchoolDbContext>();
            builder.UseInMemoryDatabase("dbtest");
            Options = builder.Options;
            SchoolDbContext context = new SchoolDbContext(Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return new DepartmentRepository(context);
        }
        
        [Fact]
        public async Task Add_Department()
        {
            IDepartment dep = GetInMemoryRepository();
            Department o = new Department()
            {
                Id = 1,
                Name = "Lit",
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };
            dep.Add(o);
            await dep.SaveChangesAsync();
            int x = await dep.CountDepartmentAsync();
            Assert.Equal(1,x);
        }
        
    }
}
