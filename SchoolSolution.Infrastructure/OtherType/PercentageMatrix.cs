using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.OtherType
{
    public class PercentageMatrix
    {
        public string StudentName { get; set; }
        public List<PercentageMatrixData> MatrixData { get; set; }
    }

    public class PercentageMatrixData
    {
        public string PeriodName { get; set; }
        public double Percentage { get; set; }
    }
}
