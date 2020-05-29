using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dictionary.Data.Entity
{
    public class UkranianIdiom
    {
        [Key]
        public int Id { get; set; }
        public string UkranianEquivalent { get; set; }
        public ICollection<EnglishIdiom> EnglishIdioms { get; set; }
    }
}
