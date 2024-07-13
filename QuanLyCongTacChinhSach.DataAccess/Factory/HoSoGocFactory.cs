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
        private readonly IRepository<HoSoGoc> _repository;

        public HoSoGocFactory(IRepository<HoSoGoc> iRepository)
        {
            _repository = iRepository;
        }

        public async Task<bool> AddHoSoGoc(HoSoGoc hoSoGoc)
        {
            return await _repository.Add(hoSoGoc);
        }
        public async Task<bool> UpdateHoSoGoc(HoSoGoc hoSoGoc)
        {
            return await _repository.Update(hoSoGoc);
        }
        public async Task<bool> DeleteHoSoGoc(int id)
        {
            return await _repository.Delete(id);
        }
        public async Task<HoSoGoc> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<IEnumerable<HoSoGoc>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
