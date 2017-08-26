using Microsoft.AspNetCore.Mvc;
using SchoolSolution.Infrastructure.Interfaces;
using SchoolSolution.Infrastructure.Repositories;
using SchoolSolution.Web.ViewModels;
using System.Threading.Tasks;

namespace SchoolSolution.Web.Controllers
{
    public class HomeController : Controller
    {
        IDepartment dep;
        IClass classe;
        IStudent stu;
        ITeacher th;
        public HomeController(IDepartment dep, IClass classe,
            IStudent stu, ITeacher th)
        {
            this.dep = dep;
            this.classe = classe;
            this.stu = stu;
            this.th = th;
        }
        
        public async Task<IActionResult> Index()
        {
            OverViewModel model = new OverViewModel();
            model.DepCount = await dep.CountDepartmentAsync();
            model.ClassCount = await classe.CountClass(null);
            model.StudentCount = await stu.CountStudentAsync();
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
