using Dictionary.Data.Entity;
using Dictionary.Repositories.Abstraction;
using Dictionary.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Services.Service
{
    public class LanguageOriginService : ILanguageOriginService
    {
        private readonly ILanguageOriginRepository _languageOriginRepository;
        public LanguageOriginService(ILanguageOriginRepository languageOriginRepository) : base()
        {
            _languageOriginRepository = languageOriginRepository;
        }
        public async Task Add(LanguageOrigin languageOrigin)
        {
            await _languageOriginRepository.CreateAsync(languageOrigin);
        }
        public async Task Delete(int id)
        {
            LanguageOrigin languageOrigin = await _languageOriginRepository.GetByIdAsync(id);
            List<LanguageOrigin> list = new List<LanguageOrigin>();
            list.Add(languageOrigin);
            await _languageOriginRepository.DeleteRangeAsync(list);
        }
        public async Task<LanguageOrigin> GetById(int id)
        {
            return await _languageOriginRepository.GetByIdAsync(id);
        }
        public async Task Update(LanguageOrigin languageOrigin)
        {
            await _languageOriginRepository.UpdateAsync(languageOrigin);
        }
    }
}
