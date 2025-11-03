using Microsoft.AspNetCore.Mvc;
using Route.MVCApp.BLL.DTOs.Employees;
using Route.MVCApp.BLL.Services.Employees;


namespace RouteMVCApp.pl.Controllers
{
    public class EmployeeController : Controller
    {
        #region Services
        private readonly EmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IWebHostEnvironment _enviroment;

        public EmployeeController(EmployeeService EmployeeService, ILogger<EmployeeController> logger, IWebHostEnvironment enviroment)
        {
            _employeeService = EmployeeService;

            _logger = logger;
            _enviroment = enviroment;
        }
        #endregion

        #region Index
        [HttpGet] //Get : /Employee?Index
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);

        }
        #endregion

        #region Create
        [HttpGet] // GET: /Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //POST: /Employee/Create
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)

                return View(employeeDto);

            var message = string.Empty;
            try
            {
                var result = _employeeService.CreateEmployee(employeeDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Employee is not Created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(employeeDto);
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
                    return View(employeeDto);

                }
                else
                {
                    message = "Employee is not Created";
                    return View("Error", message);
                }

            }


        }
        #endregion


        #region Details

        [HttpGet] //GET: /Employee/Details

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null)
                return NotFound(); //404
            return View(employee);
        }
        #endregion

        #region Edit

        //[HttpGet] // GET: /Employee/Edit
        //public IActionResult Edit(int? id)
        //{
        //    if (!id.HasValue)
        //        return BadRequest(); //400

        //    var employee = _employeeService.GetEmployeeById(id.Value);

        //    if (employee is null)
        //        return NotFound();//404

        //    return View(new EmployeeEditViewModel()
        //    {
        //        Id = employee.Id,
        //        Code = employee.Code,
        //        Name = employee.Name,
        //        Description = employee.Description,
        //        CreationDate = employee.CreationDate
        //    });
        //}

        //[HttpPost] //POST

        //public IActionResult Edit([FromRoute] int id, EmployeeEditViewModel employeeDto)
        //{
        //    if (!ModelState.IsValid)
        //        return View(employeeDto);


        //    var message = String.Empty;
        //    try
        //    {
        //        var updatedEmployee = new UpdatedEmployeeDto()
        //        {
        //            Id = id,
        //            Code = employeeDto.Code,
        //            Name = employeeDto.Name,
        //            Description = employeeDto.Description,
        //            CreationDate = employeeDto.CreationDate


        //        };

        //        var Updated = _employeeService.UpdateEmployee(updatedEmployee) < 0;

        //        if (Updated)
        //            return RedirectToAction(nameof(Index));
        //        message = "An Error Has Been Occured During Updating The Employee :(";
        //    }
        //    catch (Exception ex)
        //    {  // 1. Log Exception

        //        _logger.LogError(ex, ex.Message);
        //        // 2. Set Message

        //        // message = _enviroment.IsDevelopment() ? ex.Message : "An Error Has Been Occured During" +
        //        //    " Updating The Employee: (";
        //        if (_enviroment.IsDevelopment())
        //        {
        //            message = ex.Message;


        //        }
        //        else
        //        {
        //            message = "An Error Has Been Occured During Updating The Employee: (";

        //        }

        //    }

        //    ModelState.AddModelError(string.Empty, message);
        //    return View(employeeDto);


        //}
        #endregion

        #region Delete

        //[HttpGet] //Get: /Employee/Delete/id

        //public IActionResult Delete (int? id)
        //{
        //    if (!id.HasValue)
        //        return BadRequest(); //400
        //    var Employee = _EmployeeService.GetEmployeeById(id.Value);

        //    if (Employee is null)
        //        return NotFound();

        //    return View(Employee);

        //}

        [HttpPost] //POST: /Employee/Delete/id

        public IActionResult Delete([FromRoute] int id)
        {
            var message = string.Empty;

            try
            {
                var deleted = _employeeService.DeleteEmployee(id);

                if (deleted)
                    return RedirectToAction(nameof(Index));

                message = "An Error Has Been Occured During Updating The Employee: (";
            }
            catch (Exception ex)
            {

                // 1. Log Exception

                _logger.LogError(ex, ex.Message);
                // 2. Set Message

                message = _enviroment.IsDevelopment() ? ex.Message : "An Error Has Been Occured During" +
                   " Deleting The Employee: (";
            }
            return RedirectToAction(nameof(Delete), new { id });
        }
        #endregion


    }
}
