using Dictionary.Data.Entity;
using Dictionary.Repositories.Abstraction;
using Dictionary.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Services.Service
{
    public class UkranianIdiomService : IUkranianIdiomService
    {
        private readonly IUkranianIdiomRepository _ukranianIdiomRepository;
        public UkranianIdiomService(IUkranianIdiomRepository ukranianIdiomRepository) : base()
        {
            _ukranianIdiomRepository = ukranianIdiomRepository;
        }
        public async Task Add(UkranianIdiom explanation)
        {
            await _ukranianIdiomRepository.CreateAsync(explanation);
        }
        public async Task Delete(int id)
        {
            UkranianIdiom ukranianIdiom = await _ukranianIdiomRepository.GetByIdAsync(id);
            List<UkranianIdiom> list = new List<UkranianIdiom>();
            list.Add(ukranianIdiom);
            await _ukranianIdiomRepository.DeleteRangeAsync(list);
        }
        public async Task<UkranianIdiom> GetById(int id)
        {
            return await _ukranianIdiomRepository.GetByIdAsync(id);
        }
        public async Task Update(UkranianIdiom ukranianIdiom)
        {
            await _ukranianIdiomRepository.UpdateAsync(ukranianIdiom);
        }
    }
}
