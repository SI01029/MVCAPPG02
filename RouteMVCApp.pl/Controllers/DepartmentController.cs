using Microsoft.AspNetCore.Mvc;
using Route.MVCApp.BLL.DTOs;
using Route.MVCApp.BLL.Services.Departments;

namespace RouteMVCApp.pl.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentservice _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _enviroment;

        public DepartmentController(IDepartmentservice departmentService,ILogger<DepartmentController> logger,IWebHostEnvironment enviroment)
        {
            _departmentService = departmentService;
          
            _logger = logger;
            _enviroment = enviroment;
        }
        [HttpGet] //Get : /Department?Index
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);

        }
        [HttpPost] //POST: /Department/Create
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
            
                return View(departmentDto);

            var message = string.Empty;
            try
            {
                var result = _departmentService.CreateDepartment(departmentDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Department is not Created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(departmentDto);
                } 
            }

            catch (Exception ex)
            {
                // 1. Log Exception

                _logger.LogError(ex, ex.Message);
                // 2. Set Message
                if (_enviroment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(departmentDto);

                }
                else
                {
                    message = "Department is not Created";
                    return View("Error", message);
                }
            }

            
        }

    }   
}
