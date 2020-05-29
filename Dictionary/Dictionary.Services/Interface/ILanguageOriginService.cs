using Dictionary.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Services.Interface
{
    public interface ILanguageOriginService
    {
        Task Add(LanguageOrigin languageOrigin);
        Task<LanguageOrigin> GetById(int id);
        Task Update(LanguageOrigin languageOrigin);
        Task Delete(int id);
    }
}
