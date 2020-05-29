

using Dictionary.Data.Entity;
using Dictionary.Repositories.Abstraction;
using Dictionary.Repositories.Implementation;
using Dictionary.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Services.Service
{
    public class ExplanationService : IExplanationService
    {
        private readonly IExplanationRepository _explanationRepository;
        
        public ExplanationService( IExplanationRepository explanationRepository) :base()
        {
            _explanationRepository = explanationRepository;
        }
        public async Task Add(Explanation explanation)
        {
            await _explanationRepository.CreateAsync(explanation);
        }
        public async Task Delete (int id)
        {
            Explanation explanation = await _explanationRepository.GetByIdAsync(id);
            List<Explanation> list = new List<Explanation>();
            list.Add(explanation);
            await _explanationRepository.DeleteRangeAsync(list);
        }
        public async Task<Explanation> GetById(int id)
        {
            return await _explanationRepository.GetByIdAsync(id);
        }
        public async Task Update (Explanation explanation)
        {
            await _explanationRepository.UpdateAsync(explanation);
        }
    }
}
