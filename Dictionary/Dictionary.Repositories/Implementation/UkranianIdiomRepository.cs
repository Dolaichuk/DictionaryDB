using Dictionary.Repositories.Abstraction;
using Dictionary.Data.Entity;
using Dictionary.Data.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary.Repositories.Implementation
{
    public class UkranianIdiomRepository : BaseRepository<UkranianIdiom, DictionaryDbContext>, IUkranianIdiomRepository
    {
        public UkranianIdiomRepository(DictionaryDbContext dbContext) : base(dbContext)
        {

        }
    }
}
