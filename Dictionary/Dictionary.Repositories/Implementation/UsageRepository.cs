using Dictionary.Data.Entity;
using Dictionary.Data.Implementation;
using Dictionary.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary.Repositories.Implementation
{
    public class UsageRepository : BaseRepository<Usage, DictionaryDbContext>, IUsageRepository
    {
        public UsageRepository(DictionaryDbContext dbContext) : base(dbContext)
        {

        }
    }
}
