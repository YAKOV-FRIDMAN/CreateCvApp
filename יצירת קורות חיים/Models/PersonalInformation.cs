using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace יצירת_קורות_חיים.Models
{
    public class PersonalInformation : ViewModels.ViewModelBase
    {
   
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adderss { get; set; }
        public string Country { get; set; }
        public string LinkGitHub { get; set; }
        public string LinkYourSite { get; set; }
        public string LinkLinkdin { get; set; }
        public string LinkFacebook { get; set; }

    }
}
