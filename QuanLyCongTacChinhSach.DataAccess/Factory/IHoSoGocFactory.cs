using QuanLyCongTacChinhSach.DataAccess.DTOs;
using QuanLyCongTacChinhSach.DataAccess.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyCongTacChinhSach.DataAccess.Factory
{
    public interface IHoSoGocFactory
    {
        IRepository<HoSoGoc> Repository { get; }
    }
}