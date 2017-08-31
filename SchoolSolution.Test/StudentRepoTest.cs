using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using SchoolSolution.Infrastructure.Data;
using System;

namespace SchoolSolution.Test
{
    [TestClass]
    public class StudentRepoTest
    {
        private static DbContextOptions<SchoolDbContext> CreateNewContextOptions()
        {
            //create fresh InMemory provider and instance
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            //create new options builder

            var builder = new DbContextOptionsBuilder<SchoolDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider);
            return builder.Options;
                
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
