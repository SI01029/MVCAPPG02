using Microsoft.AspNetCore.Mvc;
using Route.MVCApp.BLL.Services.Departments;

namespace RouteMVCApp.pl.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentservice _departmentService;
        public DepartmentController(IDepartmentservice departmentservice)
        {
            _departmentService = departmentservice;

        }
        [HttpGet] //Get : /Department?Index
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);

        }

    }   
}
