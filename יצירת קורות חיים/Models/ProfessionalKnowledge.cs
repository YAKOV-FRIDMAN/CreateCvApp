using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace יצירת_קורות_חיים.Models
{
    [Serializable]
    public class ProfessionalKnowledge 
    {
        public ObservableCollection<object> ProgrammingLanguages { get; set; } = new ObservableCollection<object>();
        public ObservableCollection<object> Technologys { get; set; } = new ObservableCollection<object>();
        public ObservableCollection<object> DesignPatterns { get; set; } = new ObservableCollection<object>();
        public ObservableCollection<object> IDEs { get; set; } = new ObservableCollection<object>();
     
        
    }
}
