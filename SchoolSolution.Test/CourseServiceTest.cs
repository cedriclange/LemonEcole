using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SchoolSolution.Infrastructure.Data;
using System.Linq;

namespace SchoolSolution.Test
{
    [TestClass]
    public class CourseServiceTest
    {
        private static DbContextOptions<SchoolDbContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<SchoolDbContext>();
            builder.UseInMemoryDatabase().UseInternalServiceProvider(serviceProvider);
            return builder.Options;
            

        }
        [TestMethod]
        public void Add_Course_service_test()
        {
            //initialize context
            var options = new CreateNewContextOptions();
            using(var context = new SchoolDbContext(options))
            {
                var courseRepo = new CourseRepository(context);
                //initialize courze
                var o = new Course(){Name="math",TotalAverage=20,DepartmentID=1};
                courseRepo.Add(o);
            }
            //testting 
            using(var context = new SchoolDbContext(options))
            {
                Assert.AreEqual(1,context.Course.Count());
            }
        }
    }
}
