using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SchoolSolution.Infrastructure.Data;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class CommonRepository
    {
        SchoolDbContext context = new SchoolDbContext();
        public bool IfExists<T>(string name) where T : class
        {
            return true;
        }
    }
}
