using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace יצירת_קורות_חיים.Models
{
    public class ProfessionalKnowledge 
    {
        public IEnumerable<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public IEnumerable<Technology> Technologys { get; set; }
        public IEnumerable<DesignPattern> DesignPatterns { get; set; }
        public IEnumerable<IDE> IDEs { get; set; }
     
        
    }
}
