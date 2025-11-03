using Route.MVCApp.BLL.DTOs;
using Route.MVCApp.BLL.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDetailsDto? GetEmployeeById(int Id);
        int CreateEmployee(CreatedEmployeeDto EmployeeDto);
        int UpdateEmployee(UpdatedEmployeeDto EmployeeDto);
        bool DeleteEmployee(int Id);
    }
}
