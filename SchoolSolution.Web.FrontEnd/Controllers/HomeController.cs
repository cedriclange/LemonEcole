using Microsoft.AspNetCore.Mvc;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Web.FrontEnd.ViewModels;
using System.Threading.Tasks;

namespace SchoolSolution.Web.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private DepartmentRepository dep = new DepartmentRepository();
        private ClassRepository classe = new ClassRepository();
        private StudentRepository stu = new StudentRepository();
        private TeacherRepository th = new TeacherRepository();

        
        public async Task<IActionResult> Index()
        {
            OverViewModel model = new OverViewModel();
            model.DepCount = await dep.CountDepartmentAsync();
            model.ClassCount = await classe.CountClass(null);
            model.StudentCount = await stu.CountStudent();
            model.TeacherCount = await th.CountTeacherAsync();
           
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
