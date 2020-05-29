using Dictionary.Data.Entity;
using Dictionary.Data.Implementation;
using Dictionary.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary.Repositories.Implementation
{
    public class EnglishIdiomRepository : BaseRepository<EnglishIdiom, DictionaryDbContext>, IEnglishIdiomRepository
    {
        public EnglishIdiomRepository(DictionaryDbContext dbContext) : base(dbContext)
        {

        }
    }
}
