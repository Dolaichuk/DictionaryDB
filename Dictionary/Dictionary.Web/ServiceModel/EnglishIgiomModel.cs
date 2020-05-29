using Dictionary.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Web.ServiceModel
{
    public class EnglishIgiomModel
    {
        public string Phrase { get; set; }
        public LanguageOrigin LanguageOrigin { get; set; }
        public UkranianIdiom UkranianIdiom { get; set; }
        public Usage Usage { get; set; }
        public Explanation Explanation { get; set; }
    }
}
