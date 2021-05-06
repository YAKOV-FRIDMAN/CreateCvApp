using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using יצירת_קורות_חיים.ViewModels;
namespace יצירת_קורות_חיים.Models
{
    [Serializable]
    public class ProgrammingProject : ViewModelBase
    {
        public string Descritpion { get; set; }
        public string Role { get; set; }
        public DateTime StartProject { get; set; } = DateTime.Now;
        public DateTime FinishProject { get; set; } = DateTime.Now;
        public ObservableCollection<object> ProgrammingLanguges { get; set; } = new ObservableCollection<object>();
        private ObservableCollection<object> technologys;

        public ObservableCollection<object> Technologys
        {
            get { return technologys; }
            set
            {
                technologys = value;
                OnPropertyChanged();
            }
        }

        //  public ObservableCollection<object> Technologys { get; set; } = new ObservableCollection<object>();
        public ObservableCollection<object> DesignPatterns { get; set; } = new ObservableCollection<object>();
        public ProgrammingProject()
        {
            Technologys = new ObservableCollection<object>();
        }
    
    }
}
