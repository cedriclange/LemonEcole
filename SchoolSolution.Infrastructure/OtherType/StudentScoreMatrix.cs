using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.OtherType
{
    public class StudentScoreMatrix
    {
        public string CourseName { get; set; }
        public List<StudentMatrixData> MatrixData { get; set; }
    }
    public class StudentMatrixData
    {
        public string PeriodName { get; set; }
        public double Score { get; set; }
    }
}
