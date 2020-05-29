using Dictionary.Data.Entity;
using Dictionary.Data.Implementation;
using Dictionary.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary.Repositories.Implementation
{
    public class ExplanationRepository : BaseRepository<Explanation, DictionaryDbContext>, IExplanationRepository
    {
        public ExplanationRepository(DictionaryDbContext dbContext) : base(dbContext)
        {

        }
    }
}
