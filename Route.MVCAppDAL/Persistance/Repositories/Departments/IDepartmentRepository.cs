using Route.MVCApp.DAL.Models.Dpartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.DAL.Persistance.Repositories.Departments
{
    public interface IDepartmentRepository
    {
        Department? Get(int id);
       IEnumerable<Department> GetAll(bool withAsNoTracking = true);
        IQueryable<Department> GetAllAsIQuerable();
       int Add(Department entity);
        int Update(Department entity);
        int Delete(Department entity);

    }
}
