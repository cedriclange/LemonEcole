using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSolution.Infrastructure.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PeriodAverage { get; set; }
        public double ExamAverage { get; set; }  
        public double TotalAverage { get; set; }
        public int DepartmentID { get; set; }

        public bool CheckboxAnswer { get; set; }

        public virtual Department department { get; set; }
        public virtual ICollection<CourseAssignement> CourseAssigned { get; set; }
        public virtual ICollection<ClassesCourses> CoursesInClass { get; set; }
        
    }
}
