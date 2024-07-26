using QuanLyCongTacChinhSach.DataAccess.DTOs;
using QuanLyCongTacChinhSach.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongTacChinhSach.DataAccess.Factory
{
    public class YeuCauXuLyFactory : IYeuCauXuLyFactory
    {
        public IRepository<tb_YeuCauXuLy> Repository { get; private set; }

        public YeuCauXuLyFactory(IRepository<tb_YeuCauXuLy> repository)
        {
            Repository = repository;
        }
    }
}
