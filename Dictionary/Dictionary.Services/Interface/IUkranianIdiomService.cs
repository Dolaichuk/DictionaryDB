using Dictionary.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Dictionary.Services.Interface
{
    public interface IUkranianIdiomService
    {
        Task Add(UkranianIdiom ukranianIdiom);
        Task<UkranianIdiom> GetById(int id);
        Task Update(UkranianIdiom ukranianIdiom);
        Task Delete(int id);
    }
}
