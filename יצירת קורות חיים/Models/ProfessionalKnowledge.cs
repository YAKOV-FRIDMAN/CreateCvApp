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
        public ObservableCollection<object> ProgrammingLanguages { get; set; } = new ObservableCollection<object>();
        public ObservableCollection<Technology> Technologys { get; set; } = new ObservableCollection<Technology>();
        public ObservableCollection<DesignPattern> DesignPatterns { get; set; } = new ObservableCollection<DesignPattern>();
        public ObservableCollection<IDE> IDEs { get; set; } = new ObservableCollection<IDE>();
     
        
    }
}
