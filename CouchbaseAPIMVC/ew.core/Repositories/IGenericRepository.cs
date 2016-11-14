using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Repositories
{
    public interface IGenericRepository<T> where T : EwDocument
    {
        void AddOrUpdate(T entity);
        void Delete(string id);
        IQueryable<T> FindAll();
        List<T> GetList(List<string> ids);
        T Get(string id);
    }
}
