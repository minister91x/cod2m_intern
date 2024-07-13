using QuanLyCongTacChinhSach.DataAccess.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyCongTacChinhSach.DataAccess.Factory
{
    public interface IHoSoGocFactory
    {
        Task<bool> AddHoSoGoc(HoSoGoc hoSoGoc);
        Task<bool> DeleteHoSoGoc(int id);
        Task<IEnumerable<HoSoGoc>> GetAll();
        Task<HoSoGoc> GetById(int id);
        Task<bool> UpdateHoSoGoc(HoSoGoc hoSoGoc);
    }
}