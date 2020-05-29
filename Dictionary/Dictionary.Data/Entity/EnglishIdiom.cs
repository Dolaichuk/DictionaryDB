using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dictionary.Data.Entity
{
    public class EnglishIdiom
    {
        [Key]
        public int Id { get; set; }
        public string Phrase { get; set; }
        public LanguageOrigin LanguageOrigin { get; set; }
        public UkranianIdiom UkranianIdiom { get; set; }
        public Usage Usage { get; set; } 
        public Explanation Explanation { get; set; }
    }
}
