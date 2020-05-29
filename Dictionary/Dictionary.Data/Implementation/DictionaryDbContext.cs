using Dictionary.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary.Data.Implementation
{
    public class DictionaryDbContext : DbContext
    {

        public DictionaryDbContext()
        {

        }

        public DictionaryDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<DictionaryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<EnglishIdiom> EnglishIdioms { get; set; }
        public virtual DbSet<Explanation> Explanations { get; set; }
        public virtual DbSet<LanguageOrigin> LanguageOrigins { get; set; }
        public virtual DbSet<UkranianIdiom> UkranianIdioms { get; set; }
        public virtual DbSet<Usage> Usages { get; set; }
    }
}
