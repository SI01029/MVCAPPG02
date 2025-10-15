using Microsoft.EntityFrameworkCore;
using Route.MVCApp.DAL.Models.Dpartments;
using Route.MVCApp.DAL.Persistance.Data.Contixts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.DAL.Persistance.Repositories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)//Ask CLR For Creating object From ApplicationDbcontext

        {
            
            
            _dbContext = dbContext;
        }
        public int Add(Department entity)
        {
            _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public Department? Get(int id)
        {
            //var department = _dbContext.Departments.Local.FirstOrDefault(D => D.Id==id);
            //if (department is null)
            //{
            //    department = _dbContext.Departments.FirstOrDefault(D => D.Id == id);
            //}
            //return department;
            return _dbContext.Departments.Find(id);
        }

        public IEnumerable<Department> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
                return _dbContext.Departments.AsNoTracking().ToList();
            return _dbContext.Departments.ToList();
        }

        public int Update(Department entity)
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
