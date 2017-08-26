using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SchoolSolution.Infrastructure.OtherType;
using SchoolSolution.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Interfaces;

namespace SchoolSolution.Infrastructure.Repositories
{
    public class MatrixRepository :IMatrix
    {
        private SchoolDbContext context;
        private StudentRepository stu;
        private CourseAssignRepository crsa; 
        public MatrixRepository(StudentRepository _stu, CourseAssignRepository _crsa, SchoolDbContext ct)
        {
            stu = _stu;
            crsa = _crsa;
            context = ct;
        }

        //get percentage by class ID
        //public async Task<List<PercentageMatrix>> GetPerfomance(int id)
        //{
        //    var students = await stu.GetAllByClassID(id);
        //    var model = (from o in context.Percentage
        //                 join s in students on o.StudentID equals s.Id
        //                 group o by o.Student.Lastname into g
        //                 select new PercentageMatrix
        //                 {
        //                     StudentName = g.Key,
        //                     MatrixData = g.Select(s =>
        //                     new PercentageMatrixData { PeriodName = s.Period.Name, Percentage = s.Percent })
        //                     .OrderBy(s => s.PeriodName)
        //                     .ToList()
        //                 });
        //    return await model.ToListAsync();
        //}
        public IEnumerable<StudentScoreMatrix> GetScoreById(int id)
        {
            if (Exist())
            {
                var model = (from s in context.Score
                             where s.StudentID == id
                             group s by s.Course.Name into g
                             select new StudentScoreMatrix
                             {
                                 CourseName = g.Key,
                                 MatrixData = g.Select(s =>
                                 new StudentMatrixData { PeriodName = s.Period.Name, Score = s.Point })
                                 .ToList()
                             });
                return model.ToList();
            }
            return null;
        }

        //get all score for each course
        // and 
        public IEnumerable<ScoreMatrix> GetAll(int classId, int courseId)
        {
            if (Exist())
            {

                var students = stu.GetFromClassId(classId);
                var model = (from s in context.Score
                             join st in students on s.StudentID equals st.Id
                             where s.ClassId == classId && s.CourseID == courseId
                             group s by st.Lastname into g

                             select new ScoreMatrix
                             {
                                 StudentName = g.Key,
                                 MatrixData = g.Select(s =>
                                 new ScoreMatrixData { PeriodName = s.Period.Name, Score = s.Point })
                                 .ToList()
                             });
                return model.ToList();



            }
            return null;
        }
        private bool Exist()
        {
            return context.Score.Any();
        }

        //get performance of course by COurse ID, related
        //to teacher Id
        //public async Task<List<ScoreMatrix>> GetScoreByCourseTeacherId(int courseId, int teacherId,int classId)
        //{
        //    //get student from classe
        //    var students = await stu.GetAllByClassID(classId);
        //}
    }
}
