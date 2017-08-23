using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Repositories
{
    public interface IRepository
    {
         Task SaveChangesAsync();
    }
}
