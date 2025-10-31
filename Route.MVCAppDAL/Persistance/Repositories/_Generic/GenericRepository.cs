using Microsoft.EntityFrameworkCore;
using Route.MVCApp.DAL.Models.Dpartments;
using Route.MVCApp.DAL.Persistance.Data.Contixts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.DAL.Persistance.Repositories._Generic
{
    public class GenericRepository<T> : IGenericRepositroy<T> where T:ModelBase
    {
        private protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)//Ask CLR For Creating object From ApplicationDbcontext

        {


            _dbContext = dbContext;
        }
        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public T? Get(int id)
        {
            //var department = _dbContext.Set<T>().Local.FirstOrDefault(D => D.Id==id);
            //if (department is null)
            //{
            //    department = _dbContext.Set<T>().FirstOrDefault(D => D.Id == id);
            //}
            //return department;
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
                return _dbContext.Set<T>().AsNoTracking().ToList();
            return _dbContext.Set<T>().ToList();
        }

        public IQueryable<T> GetAllAsIQuerable()
        {
            return _dbContext.Set<T>();
        }

        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
