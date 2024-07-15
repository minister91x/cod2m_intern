using QuanLyCongTacChinhSach.DataAccess.DTOs;
using QuanLyCongTacChinhSach.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongTacChinhSach.DataAccess.Factory
{
    public class HoSoGocFactory : IHoSoGocFactory
    {
        public IRepository<HoSoGoc> Repository { get; private set; }

        public HoSoGocFactory(IRepository<HoSoGoc> repository)
        {
            Repository = repository;
        }
    }
}
