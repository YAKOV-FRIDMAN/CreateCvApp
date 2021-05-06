using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace יצירת_קורות_חיים.Models
{
    [Serializable]
    public class Education
    {
        public string School { get; set; }
        public string TypeOfStudy { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime Finish { get; set; } = DateTime.Now;
    }
}
