using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.OtherType
{
    public class ScoreMatrix
    {
        public string StudentName { get; set; }
        public List<ScoreMatrixData> MatrixData { get; set; }
    }
    public class ScoreMatrixData
    {
        public string PeriodName { get; set; }
        public double Score { get; set; }
    }
}
