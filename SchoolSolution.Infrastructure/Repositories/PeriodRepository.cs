using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class PeriodRepository
    {
        private SchoolDbContext context = new SchoolDbContext();

        public IEnumerable<Period> DropDownList()
        {
            return context.Period;
        }
    }
}
