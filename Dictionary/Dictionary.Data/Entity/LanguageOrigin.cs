using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dictionary.Data.Entity
{
    public class LanguageOrigin
    {
        [Key]
        public int Id { get; set; }
        public string Origin { get; set; }
        public ICollection<EnglishIdiom> EnglishIdioms { get; set; }
    }
}
