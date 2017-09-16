using SchoolSolution.Infrastructure.Data;
using SchoolSolution.Infrastructure.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class PeriodRepository : IPeriod
    {
        SchoolDbContext context;
        public PeriodRepository(SchoolDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Period> DropDownList()
        {
            return context.Period;
        }
    }
}
