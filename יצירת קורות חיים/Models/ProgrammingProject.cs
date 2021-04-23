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
        
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public Technology Technology { get; set; }
        public string Descritpion { get; set; }

        private ObservableCollection<object> toSelectedItem1;
        public ObservableCollection<object> ToSelectedItem1
        {
            get { return toSelectedItem1; }
            set
            {
                toSelectedItem1 = value;
                OnPropertyChanged();
            }
        }

        public ProgrammingProject()
        {
            ToSelectedItem1 = new ObservableCollection<object>();
        }

    }
}
