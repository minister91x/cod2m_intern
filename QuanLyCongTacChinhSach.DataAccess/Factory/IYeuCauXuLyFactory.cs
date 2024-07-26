using QuanLyCongTacChinhSach.DataAccess.DTOs;
using QuanLyCongTacChinhSach.DataAccess.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyCongTacChinhSach.DataAccess.Factory
{
    public interface IYeuCauXuLyFactory
    {
        IRepository<tb_YeuCauXuLy> Repository { get; }
    }
}