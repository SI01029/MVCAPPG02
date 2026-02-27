using Route.MVCApp.DAL.Models.Employees;
using Route.MVCApp.DAL.Persistance.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.DAL.Persistance.Repositories.Employees
{
    public interface IEmployeeRepository:IGenericRepositroy<Employee>
    {
        

    }
}
