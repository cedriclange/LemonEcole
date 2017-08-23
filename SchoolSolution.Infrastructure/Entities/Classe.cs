using System.Collections.Generic;

namespace SchoolSolution.Infrastructure.Entities
{
    public class Classe
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int DepartmentID { get; set; }       
        
        public virtual Department department { get; set; }
        public virtual ICollection<ClassesCourses> CoursesByClasse { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        

    }
}
