using Microsoft.AspNetCore.Mvc;
using Route.MVCApp.BLL.DTOs;
using Route.MVCApp.BLL.Services.Departments;
using RouteMVCApp.pl.ViewModels.Departments;
using System.Security.Policy;

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
        [HttpGet] // GET: /Department/Create
        public IActionResult Create()
        {
            return View();
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
        [HttpGet] //GET: /Department/Details
       
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound(); //404
            return View(department);
        }
        [HttpGet] // GET: /Department/Edit
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest(); //400

            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();//404

            return View(new DepartmentEditViewModel()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate
            });
        }

        [HttpPost] //POST

        public IActionResult Edit([FromRoute]int id,DepartmentEditViewModel departmentVM)
        {
            if (!ModelState.IsValid)
                return View(departmentVM);


            var message = String.Empty;
            try
            {
                var updatedDepartmentDto = new UpdatedDepartmentDto()
                {
                    Id= id,
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    CreationDate = departmentVM.CreationDate


                };

                var Updated = _departmentService.UpdateDepartment(updatedDepartmentDto) < 0;

                if (Updated)
                    return RedirectToAction(nameof(Index));
                message = "An Error Has Been Occured During Updating The Department :(";
            }
            catch (Exception ex)
            {  // 1. Log Exception

                _logger.LogError(ex, ex.Message);
                // 2. Set Message

                // message = _enviroment.IsDevelopment() ? ex.Message : "An Error Has Been Occured During" +
                //    " Updating The Department: (";
                if (_enviroment.IsDevelopment())
                {
                    message = ex.Message;


                }
                else
                {
                    message = "An Error Has Been Occured During Updating The Department: (";

                }

            }

            ModelState.AddModelError(string.Empty, message);
            return View(departmentVM);


        }

        

        

    }   
}
