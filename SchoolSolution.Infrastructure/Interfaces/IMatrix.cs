using SchoolSolution.Infrastructure.OtherType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Interfaces
{
    public interface IMatrix
    {
        IEnumerable<StudentScoreMatrix> GetScoreById(int id);
        IEnumerable<ScoreMatrix> GetAll(int classId, int courseId);
        

    }
}
