using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using יצירת_קורות_חיים.ViewModels;
namespace יצירת_קורות_חיים.Models
{
    public class ProgrammingProject : ViewModelBase
    {
        public string Descritpion { get; set; }
        public string Role { get; set; }
        public DateTime StartProject { get; set; } = DateTime.Now;
        public DateTime FinishProject { get; set; } = DateTime.Now;
        public ObservableCollection<object> ProgrammingLanguges { get; set; } = new ObservableCollection<object>();
        public ObservableCollection<object> Technologys { get; set; } = new ObservableCollection<object>();
        public ObservableCollection<object> DesignPatterns { get; set; } = new ObservableCollection<object>();
    }
}
