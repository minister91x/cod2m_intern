using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongTacChinhSach.DataAccess.IRepositories
{
    public interface IRepository<T> where T : class, new()
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(object id);
        Task<T> GetById(object id);
        Task<IEnumerable<T>> GetAll();
        Task<(IEnumerable<dynamic> Items, int TotalRecords)> Search(string searchTerm, int pageIndex, int pageSize);
    }
}
