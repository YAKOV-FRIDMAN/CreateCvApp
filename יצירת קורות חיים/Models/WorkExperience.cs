using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using יצירת_קורות_חיים.ViewModels;

namespace יצירת_קורות_חיים.Models
{
    public class WorkExperience :ViewModelBase
    {
        public string Job { get; set; }
        public string Role { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime Finish { get; set; } = DateTime.Now;
    }
}
