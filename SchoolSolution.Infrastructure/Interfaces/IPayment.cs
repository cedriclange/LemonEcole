using SchoolSolution.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface IPayment :IRepository
    {
        void Add(Paiment p);
        Task<List<Paiment>> GetPayHistoric(int id);
    }
}
