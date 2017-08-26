using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface IRepository
    {
        Task SaveChangesAsync();
    }
}
