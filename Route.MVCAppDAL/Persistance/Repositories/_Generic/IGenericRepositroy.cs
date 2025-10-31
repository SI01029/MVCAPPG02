using Route.MVCApp.DAL.Models.Dpartments;
using Route.MVCApp.DAL.Persistance.Data.Contixts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.DAL.Persistance.Repositories._Generic
{
    public interface IGenericRepositroy<T> where T:ModelBase
    {
        T? Get(int id);
        IEnumerable<T> GetAll(bool withAsNoTracking = true);
        IQueryable<T> GetAllAsIQuerable();
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);

    }
}
