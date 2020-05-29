using Dictionary.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Services.Interface
{
    public interface IExplanationService
    {
        Task Add(Explanation explanation);
        Task<Explanation> GetById(int id);
        Task Update(Explanation explanation);
        Task Delete(int id);
    }
}
